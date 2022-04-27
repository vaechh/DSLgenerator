using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OntologyCreator.Concepts;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using OntologyCreator.Relations;
using OwlDotNetApi;
using OntologyCreator.Attributes;

namespace OntologyCreator.Forms
{
    public partial class CombineOntologyForm : Form
    {
        private OntologyManager om = OntologyManager.getManager();
        private Ontology currentOntology;
        private Ontology secondOntology;
        private Ontology resultOntology;
        private OwlGraph owlGraph;

        public CombineOntologyForm()
        {
            InitializeComponent();
            FillOntologiesList();
            currentOntology = om.GetCurrentOntology();
            lblCurrentOntologyName.Text = currentOntology.Name;
            CreateTree(tvCurrentOntology, currentOntology.Concepts);
            tvCurrentOntology.ExpandAll();
        }

        #region Tree View
        private void tvCurrent_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblCurrentConcept.Text = tvCurrentOntology.SelectedNode.Text;
            if (tvCurrentOntology.SelectedNode != null && tvSecondOntology.SelectedNode != null)
                CombineButtonsEnabled(true);
        }

        private void tvSecondOntology_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblSecondConcept.Text = tvSecondOntology.SelectedNode.Text;
            if (tvCurrentOntology.SelectedNode != null && tvSecondOntology.SelectedNode != null)
                CombineButtonsEnabled(true);
        }
        #endregion

        #region Buttons
        private void btnCurrentInfo_Click(object sender, EventArgs e)
        {
            var ontology = new OntologyForm(3, currentOntology.Id);
            this.Enabled = false;
            ontology.Show();
            ontology.Closed += ChildForm_Closed;
        }

        private void btnResultSettings_Click(object sender, EventArgs e)
        {
            var ontology = new OntologyForm(3, resultOntology.Id);
            this.Enabled = false;
            ontology.Show();
            ontology.Closed += ChildForm_Closed;
        }

        private void btnOpenSecondOntology_Click(object sender, EventArgs e)
        {
            if (secondOntology != null)
            {
                DialogResult result = MessageBox.Show(@"Если Вы не сохранили открытую онтологию, то она будет утеряна. Открыть другую онтлогию?", @"Предупреждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.No)
                    return;
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = false,
                DefaultExt = "*.owl;*.xml",
                Filter = @"All Files (*.owl, *.xml) | *.owl; *.xml",
                Title = @"Выберите онтологию в формате OWL или XML",
                InitialDirectory = path + @"\\"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataContractSerializer ser = new DataContractSerializer(typeof(Ontology));
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                    {
                        XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                        secondOntology = (Ontology)ser.ReadObject(reader, true);
                        lblSecondOntologyName.Text = secondOntology.Name;
                        tvSecondOntology.Nodes.Clear();
                        CreateTree(tvSecondOntology, secondOntology.Concepts);
                        tvSecondOntology.ExpandAll();
                        btnCombineNoConnect.Enabled = true;
                        btnCombineExisting.Enabled = true;
                        reader.Close();
                        fs.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Ошибка: не удалось считать файл с диска. Источник ошибки: " + ex.Message, @"Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btnResultClear_Click(object sender, EventArgs e)
        {
            ClearResult();
        }

        private void btnSaveResultXml_Click(object sender, EventArgs e)
        {
            if (!IsInfoFilled())
            {
                MessageBox.Show("Перед сохранением заполните поле \"Наименование предметно области\"\nв разделе \"Настройки онтологии\"", @"Ошибка",
                         MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            try
            {
                var sfd = new SaveFileDialog();
                sfd.Filter = "XML File|*.xml";
                sfd.Title = "Сохранить онтологию в формате XML";
                sfd.FileName = currentOntology.Name;
                sfd.RestoreDirectory = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var dcss = new DataContractSerializerSettings { PreserveObjectReferences = true };
                    var dcs = new DataContractSerializer(typeof(Ontology), dcss);

                    using (Stream fStream = new FileStream(sfd.FileName,
                        FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        dcs.WriteObject(fStream, resultOntology);
                    }
                    MessageBox.Show("Онтология успешно сохранена в формате XML", @"Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка при сохранении онтологии в формате XML. Информация: " + ex.Message, @"Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnSaveResultOwl_Click(object sender, EventArgs e)
        {
            if (!IsInfoFilled())
            {
                MessageBox.Show("Перед сохранением заполните поле \"Наименование предметно области\"\nв разделе \"Настройки онтологии\"", @"Ошибка",
                         MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            try
            {
                var sfd = new SaveFileDialog();
                sfd.Filter = "OWL File|*.owl";
                sfd.Title = "Сохранить онтологию в формате OWL";
                sfd.FileName = resultOntology.Name;
                sfd.RestoreDirectory = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    owlGraph = new OwlGraph();
                    owlGraph.NameSpaces["xmlns:" + OwlNamespaceCollection.OwlNamespacePrefix] = OwlNamespaceCollection.OwlNamespace;
                    owlGraph.NameSpaces["xmlns:" + OwlNamespaceCollection.RdfSchemaNamespacePrefix] = OwlNamespaceCollection.RdfSchemaNamespace;
                    owlGraph.NameSpaces["xmlns:daml"] = "http://www.daml.org/2001/03/daml+oil#";
                    owlGraph.NameSpaces["xmlns:dc"] = "http://purl.org/dc/elements/1.1/";
                    owlGraph.NameSpaces["xmlns"] = "http://www.owl-ontologies.com/" + resultOntology.Name + ".owl#";
                    owlGraph.NameSpaces["xml:base"] = "http://www.owl-ontologies.com/" + resultOntology.Name + ".owl";

                    string baseUri = "http://www.owl-ontologies.com/" + resultOntology.Name + ".owl#";

                    AddNodesToOWL(resultOntology.Concepts, baseUri);
                    AddRelationsToOWL(resultOntology.Relations, baseUri);

                    IOwlGenerator generator = new OwlXmlGenerator();
                    generator.GenerateOwl(owlGraph, sfd.FileName);

                    MessageBox.Show("Онтология успешно сохранена в формате OWL", @"Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка при сохранении онтологии в формате OWL. Информация: " + ex.Message, @"Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnCombineNoConnect_Click(object sender, EventArgs e)
        {
            ClearResult();
            om.Add(new Ontology($"{currentOntology.Name} + {secondOntology.Name}", $"Объединение двух онтологий {currentOntology.Name} и {secondOntology.Name}"));
            resultOntology = om.GetCurrentOntology();

            foreach (var concept in currentOntology.Concepts)
            {
                resultOntology.Concepts.Add((Concept)concept.Clone(resultOntology.Id, Utils.GetConceptIdFromOntology(resultOntology.Id)));
            }

            foreach (var concept in secondOntology.Concepts)
            {
                resultOntology.Concepts.Add((Concept)concept.Clone(resultOntology.Id, Utils.GetConceptIdFromOntology(resultOntology.Id)));
            }

            foreach (var relation in currentOntology.Relations)
            {
                var mainConcept = Utils.FindConceptByName(relation.MainConcept.Name, resultOntology.Concepts);
                var secondaryConcept = Utils.FindConceptByName(relation.SecondaryConcept.Name, resultOntology.Concepts);
                resultOntology.Relations.Add((Relation)relation.Clone(resultOntology.Id, mainConcept, secondaryConcept));
            }

            foreach (var relation in secondOntology.Relations)
            {
                var mainConcept = Utils.FindConceptByName(relation.MainConcept.Name, resultOntology.Concepts);
                var secondaryConcept = Utils.FindConceptByName(relation.SecondaryConcept.Name, resultOntology.Concepts);
                resultOntology.Relations.Add((Relation)relation.Clone(resultOntology.Id, mainConcept, secondaryConcept));
            }

            CreateTree(tvResultOntology, resultOntology.Concepts);
            tvResultOntology.ExpandAll();
            SettingsButtonsEnabled(true);
        }

        private void btnCombineNew_Click(object sender, EventArgs e)
        {
            if (currentOntology == null || secondOntology == null || tvCurrentOntology.SelectedNode == null || tvSecondOntology.SelectedNode == null)
            {
                MessageBox.Show("Ошибка объединения. Отсутствует вторая онтология или не выбраны концепты", @"Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            ClearResult();
            om.Add(new Ontology($"{currentOntology.Name} + {secondOntology.Name}", $"Объединение двух онтологий {currentOntology.Name} и {secondOntology.Name}"));
            resultOntology = om.GetCurrentOntology();

            var concept = new ConceptForm(1, resultOntology.Id);
            this.Enabled = false;
            concept.Show();
            concept.Closed += ResultConcept_Closed;
        }

        private void btnCombineExisting_Click(object sender, EventArgs e)
        {
            if (currentOntology == null || secondOntology == null)
            {
                MessageBox.Show("Ошибка объединения. Отсутствует вторая онтология или не выбраны концепты", @"Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            ClearResult();
            om.Add(new Ontology($"{currentOntology.Name} + {secondOntology.Name}", $"Объединение двух онтологий {currentOntology.Name} и {secondOntology.Name}"));
            resultOntology = om.GetCurrentOntology();

            var commonConceptForm = new CommonConceptForm(currentOntology, secondOntology, resultOntology);
            SwitchSettings();
            commonConceptForm.Show();
            commonConceptForm.Closed += CommonForm_Closed;
        }
        #endregion

        #region Utils
        private void CreateTree(TreeView treeView, List<Concept> concepts, TreeNode parent = null)
        {
            if ((concepts != null) && (concepts.Count > 0))
            {
                if (parent == null)
                    foreach (var c in concepts)
                    {
                        TreeNode treeNode = new TreeNode(c.Name);
                        treeView.Nodes.Add(treeNode);
                        CreateTree(treeView, c.Child, treeNode);
                    }
                else
                    foreach (var c in concepts)
                    {
                        TreeNode treeNode = new TreeNode(c.Name);
                        parent.Nodes.Add(treeNode);
                        CreateTree(treeView, c.Child, treeNode);
                    }
            }
        }

        private void FillOntologiesList()
        {
            cbExistingOntologies.Items.Clear();

            foreach (var onto in om._ontologies)
            {
                cbExistingOntologies.Items.Add(onto.Name);
            }
        }

        private void ChildForm_Closed(object sender, EventArgs e)
        {
            this.Enabled = true;
            lblCurrentOntologyName.Text = currentOntology.Name;
        }

        private void ResultConcept_Closed(object sender, EventArgs e)
        {
            this.Enabled = true;

            if (resultOntology.Concepts.Count == 0)
                ClearResult();
            else
            {
                var currentConcept = Utils.FindConceptByName(tvCurrentOntology.SelectedNode.Text, currentOntology.Concepts);
                var secondConcept = Utils.FindConceptByName(tvSecondOntology.SelectedNode.Text, secondOntology.Concepts);
                var resultConcept = resultOntology.Concepts[0];

                resultConcept.Child.Add((Concept)currentConcept.Clone(resultOntology.Id, Utils.GetConceptIdFromOntology(resultOntology.Id)));
                resultConcept.Child.Add((Concept)secondConcept.Clone(resultOntology.Id, Utils.GetConceptIdFromOntology(resultOntology.Id)));

                foreach (var child in resultConcept.Child)
                {
                    Utils.CreateFamilyRelationsDown(resultConcept, child, resultOntology.Id);
                }

                CreateTree(tvResultOntology, resultOntology.Concepts);
                tvResultOntology.ExpandAll();
                SettingsButtonsEnabled(true);
            }
        }

        private void ClearResult()
        {
            if (resultOntology != null)
            {
                om.Delete(resultOntology.Id);
                resultOntology = null;
                tvResultOntology.Nodes.Clear();
                SettingsButtonsEnabled(false);
            }
        }

        private void cbUseExistingOntologies_CheckedChanged(object sender, EventArgs e)
        {
            if (btnOpenSecondOntology.Enabled)
            {
                btnOpenSecondOntology.Enabled = false;
                cbExistingOntologies.Enabled = true;
            }
            else
            {
                cbExistingOntologies.Enabled = false;
                btnOpenSecondOntology.Enabled = true;
            }
            secondOntology = null;
            cbExistingOntologies.SelectedIndex = -1;
            lblSecondConcept.Text = "не выбран";
            lblSecondOntologyName.Text = "Онтология отсутствует";
            tvSecondOntology.Nodes.Clear();
            CombineButtonsEnabled(false);
        }

        private void cbExistingOntologies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbExistingOntologies.SelectedIndex != -1)
            {
                var secondOntologyId = om.Open(cbExistingOntologies.Text);
                secondOntology = om.GetById(secondOntologyId);
                lblSecondOntologyName.Text = secondOntology.Name;
                tvSecondOntology.Nodes.Clear();
                CreateTree(tvSecondOntology, secondOntology.Concepts);
                tvSecondOntology.ExpandAll();
                btnCombineNoConnect.Enabled = true;
                btnCombineExisting.Enabled = true;
            }
        }

        private void CombineButtonsEnabled(bool enabled)
        {
            btnCombineExisting.Enabled = enabled;
            btnCombineNew.Enabled = enabled;
            btnCombineNoConnect.Enabled = enabled;
        }

        private void SettingsButtonsEnabled(bool enabled)
        {
            btnResultClear.Enabled = enabled;
            btnResultSettings.Enabled = enabled;
            btnSaveResultOwl.Enabled = enabled;
            btnSaveResultXml.Enabled = enabled;
        }

        private bool IsInfoFilled()
        {
            if (String.IsNullOrEmpty(resultOntology.subjectArea.Name))
                return false;
            return true;
        }

        private void AddNodesToOWL(List<Concept> concepts, string baseUri)
        {
            if ((concepts != null) && (concepts.Count > 0))
            {
                foreach (var c in concepts)
                {
                    OwlClass owlCls = new OwlClass(baseUri + c.Name);
                    owlGraph.Nodes.Add(owlCls);
                    foreach (Property p in c.Properties)
                    {
                        OwlObjectProperty prop = new OwlObjectProperty(baseUri + p.Name);
                        owlGraph.Nodes.Add(prop);
                        OwlEdge onPropertyRelation = new OwlEdge(OwlNamespaceCollection.OwlNamespace + "onProperty");
                        onPropertyRelation.AttachParentNode(owlCls);
                        onPropertyRelation.AttachChildNode(prop);
                        owlGraph.Edges.Add(onPropertyRelation);
                    }
                    AddNodesToOWL(c.Child, baseUri);
                }
            }
        }

        private void AddRelationsToOWL(List<Relation> relations, string baseUri)
        {
            if ((relations != null) && (relations.Count > 0))
            {
                foreach (Relation r in relations.Where(r => r.RelationType == "Наследование"))
                {
                    OwlEdge subClassOfRelation = new OwlEdge(OwlNamespaceCollection.RdfSchemaNamespace + "subClassOf");
                    subClassOfRelation.AttachParentNode(owlGraph.Nodes[baseUri + r.MainConcept.Name]);
                    subClassOfRelation.AttachChildNode(owlGraph.Nodes[baseUri + r.SecondaryConcept.Name]);
                    owlGraph.Edges.Add(subClassOfRelation);
                }
            }
        }

        private void SwitchSettings()
        {
            if (Visible)
                Hide();
            else
                Show();
        }

        private void CommonForm_Closed(object sender, EventArgs e)
        {
            this.Enabled = true;
            SwitchSettings();
            tvResultOntology.Nodes.Clear();
            if (resultOntology != null && resultOntology.Concepts.Count > 0)
            {
                CreateTree(tvResultOntology, resultOntology.Concepts);
                tvResultOntology.ExpandAll();
            }
            FillOntologiesList();
            SettingsButtonsEnabled(true);
        }
        #endregion
    }
}
