using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using OntologyCreator.Concepts;
using OntologyCreator.Attributes;
using OntologyCreator.Relations;
using QuickGraph;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;
using OwlDotNetApi;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace OntologyCreator.Forms
{
    public partial class MainForm : Form
    {
        private bool ExitCheck;
        private OntologyManager om = OntologyManager.getManager();
        private int currentOntologyId;
        private Ontology currentOntology;
        Concept activeConcept = null;
        AdjacencyGraph<string, TaggedEdge<string, string>> dgOntology = new AdjacencyGraph<string, TaggedEdge<string, string>>();
        private OwlGraph owlGraph;

        public MainForm(int ontologyId)
        {
            InitializeComponent();
            currentOntologyId = ontologyId;
            currentOntology = om.GetById(ontologyId);
            this.Text = $"Ontology Interviewer - {currentOntology.Name}";
            FillOntologiesList();
            panel1.Controls.Add(pbOntology);
            ClassesCheck();
            CreateTree(currentOntology.Concepts);
        }

        #region Classes

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            var concept = new ConceptForm(1, currentOntologyId);
            this.Enabled = false;
            concept.Show();
            concept.Closed += ChildForm_Closed;
        }

        private void btnAddSubclass_Click(object sender, EventArgs e)
        {
            var concept = new ConceptForm(4, currentOntologyId, null, activeConcept);
            this.Enabled = false;
            concept.Show();
            concept.Closed += ChildForm_Closed;
        }

        private void btnEditClass_Click(object sender, EventArgs e)
        {
            var concept = new ConceptForm(2, currentOntologyId, activeConcept);
            this.Enabled = false;
            concept.Show();
            concept.Closed += ChildForm_Closed;
        }

        private void btnDelClass_Click(object sender, EventArgs e)
         {
            DialogResult result = MessageBox.Show("При удалении класса удалятся также все свзанные с ним отношения.\n" +
                    "Вы уверены, что хотите удалить класс " + activeConcept.Name + "?", @"Предупреждение",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (activeConcept.ParentID == -1)
                    {
                        Concept concept = currentOntology.Concepts.Find(c => c.ID == activeConcept.ID);
                        for (int i = 0; i < currentOntology.Relations.Count; i++)
                        {
                            if ((currentOntology.Relations[i].MainConcept == concept) || (currentOntology.Relations[i].SecondaryConcept == concept))
                            {
                                currentOntology.Relations.Remove(currentOntology.Relations[i]);
                                i--;
                            }
                        }
                        currentOntology.Concepts.Remove(concept);
                    }
                    else
                    {
                        var parent = Utils.FindConceptByID(activeConcept.ParentID, currentOntology.Concepts);
                        parent.Child.Remove(activeConcept);
                        for (int i = 0; i < currentOntology.Relations.Count; i++)
                        {
                            if ((currentOntology.Relations[i].MainConcept == activeConcept) || (currentOntology.Relations[i].SecondaryConcept == activeConcept))
                            {
                                currentOntology.Relations.Remove(currentOntology.Relations[i]);
                                i--;
                            }
                        }
                    }
                    MessageBox.Show("Класс " + activeConcept.Name + " был успешно удален", @"Сообщение",
                       MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    activeConcept = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка:" + ex.Message, @"Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            tvOntology.Nodes.Clear();
            CreateTree(currentOntology.Concepts);
            tvOntology.ExpandAll();
            ClassesCheck();       
        }

        private void ClassesCheck()
        {
            if (activeConcept == null)
            {
                gbAttributes.Visible = false;
                gbRelations.Visible = false;
                btnAddAttribute.Visible = false;
                btnAddRelation.Visible = false;
                btnAddSubclass.Enabled = false;
                btnEditClass.Enabled = false;
                btnDelClass.Enabled = false;
            }
            else
            {
                gbAttributes.Visible = true;
                btnAddAttribute.Visible = true;
                btnAddSubclass.Enabled = true;
                btnEditClass.Enabled = true;
                btnDelClass.Enabled = true;
                AttributesEnable();
                if (Utils.CountConcept(currentOntology.Concepts) > 1)
                    gbRelations.Visible = true;
                if (currentOntology.Concepts.Count > 1)
                    btnAddRelation.Visible = true;
                RelationsEnable();
            }
        }

        private void tvOntology_MouseUp(object sender, MouseEventArgs e)
        {
            ClassesCheck();
            FillTheWindow();
            AttributesEnable();
            RelationsEnable();
        }

        private void tvOntology_AfterSelect(object sender, TreeViewEventArgs e)
        {
            activeConcept = Utils.FindConceptByName(tvOntology.SelectedNode.Text, currentOntology.Concepts);
            ClassesCheck();
            FillTheWindow();
            AttributesEnable();
            RelationsEnable();
        }

        #endregion

        #region Attributes

        private void btnAddAttribute_Click(object sender, EventArgs e)
        {
            var property = new PropertyForm(1, currentOntology.Id, activeConcept);
            this.Enabled = false;
            property.Show();
            property.Closed += ChildForm_Closed;
        }

        private void btnEditAttribute_Click(object sender, EventArgs e)
        {
            Property prop = activeConcept.Properties.Find(p => p.ID == (int)dgvAttributes.SelectedRows[0].Cells["PropertyID"].Value);
            var property = new PropertyForm(2, currentOntology.Id, activeConcept, prop);
            this.Enabled = false;
            property.Show();
            property.Closed += ChildForm_Closed;
        }

        private void btnDelAttribute_Click(object sender, EventArgs e)
        {
            Property prop = activeConcept.Properties.Find(p => p.ID == (int)dgvAttributes.SelectedRows[0].Cells["PropertyID"].Value);
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить данное свойство " + activeConcept.Name + "?", @"Предупреждение",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                try
                {
                    activeConcept.Properties.Remove(prop);
                    MessageBox.Show("Свойство сущности " + activeConcept.Name + " был успешно удален", @"Сообщение",
                       MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    activeConcept = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка:" + ex.Message, @"Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            tvOntology.Nodes.Clear();
            CreateTree(currentOntology.Concepts);
            tvOntology.ExpandAll();
            ClassesCheck();
        }

        private void dgvAttributes_SelectionChanged(object sender, EventArgs e)
        {
            if ((dgvAttributes.SelectedRows.Count != 0) && (dgvAttributes.SelectedRows[0].Cells["PropertyID"].Value != null))
            AttributesEnable();
        }

        private void dgvAttributes_MouseDown(object sender, MouseEventArgs e)
        {
            if ((dgvAttributes.SelectedRows.Count != 0) && (dgvAttributes.SelectedRows[0].Cells["PropertyID"].Value != null))
            AttributesEnable();
        }

        #endregion

        #region Relations

        private void btnAddRelation_Click(object sender, EventArgs e)
        {
            var relation = new RelationForm(1, currentOntologyId, activeConcept);
            this.Enabled = false;
            relation.Show();
            relation.Closed += ChildForm_Closed;
        }


        private void btnDelRelation_Click(object sender, EventArgs e)
        {
            Relation relation = currentOntology.Relations.Find(r => r.ID == (int)dgvRelations.SelectedRows[0].Cells["RelationID"].Value);
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить данное свойство " + activeConcept.Name + "?", @"Предупреждение",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                try
                {
                    currentOntology.Relations.Remove(relation);
                    MessageBox.Show("Связь была успешно удалена", @"Сообщение",
                       MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    activeConcept = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка:" + ex.Message, @"Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            tvOntology.Nodes.Clear();
            CreateTree(currentOntology.Concepts);
            tvOntology.ExpandAll();
            ClassesCheck();
        }

        private void dgvRelations_SelectionChanged(object sender, EventArgs e)
        {
            if ((dgvRelations.SelectedRows.Count != 0) && (dgvRelations.SelectedRows[0].Cells["RelationID"].Value != null))
            RelationsEnable();
        }

        private void dgvRelations_MouseDown(object sender, MouseEventArgs e)
        {
            if ((dgvRelations.SelectedRows.Count != 0) && (dgvRelations.SelectedRows[0].Cells["RelationID"].Value != null))
            RelationsEnable();
        }

        #endregion

        #region Diagram

        private void CreateDiagram()
        {
            if (currentOntology.Concepts.Count > 0)
            {
                try
                {
                    dgOntology.Clear();
                    File.Delete("graph.png");
                    AddConceptsToDiagram(currentOntology.Concepts);
                    AddEdgesToDiagram(currentOntology.Relations);
                    var graphViz = new GraphvizAlgorithm<string, TaggedEdge<string, string>>(dgOntology, @".", GraphvizImageType.Png);
                    graphViz.FormatVertex += FormatVertex;
                    graphViz.FormatEdge += FormatEdge;
                    graphViz.Generate(new FileDotEngine(), "graph.dot");
                    while (!File.Exists("graph.png"))
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                    pbOntology.Image = Image.FromFile("graph.png");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Невозможно отобразить изображение.\nПерезапстите программу или перезайдите в раздел.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddConceptsToDiagram(List<Concept> concepts)
        {
            if ((concepts != null) && (concepts.Count > 0))
            {
                foreach (var c in concepts)
                {
                    //if (c.Properties.Count == 0)
                    //{
                    //    dgOntology.AddVertex(c.Name);
                    //    AddConceptsToDiagram(c.Child);
                    //    continue;
                    //}

                    //bool show = true;
                    //foreach (var pr in c.Properties)
                    //    if (pr.Name == "Абстрактный")
                    //        show = false;

                    //if (show)
                    //{
                    //    dgOntology.AddVertex(c.Name);
                    //    AddConceptsToDiagram(c.Child);
                    //}
                    //else
                    //    AddConceptsToDiagram(c.Child);

                    dgOntology.AddVertex(c.Name);
                    AddConceptsToDiagram(c.Child);
                }
            }
        }

        private void AddEdgesToDiagram(List<Relation> relations)
        {
            //foreach (Relation r in relations)
            //{
            //    if (r.MainConcept.Properties.Count == 0 && r.SecondaryConcept.Properties.Count == 0)
            //    {
            //        dgOntology.AddEdge(new TaggedEdge<string, string>(r.MainConcept.Name, r.SecondaryConcept.Name, r.RelationType));
            //    }
            //    else if (r.MainConcept.Properties[0].Name != "Абстрактный" && r.SecondaryConcept.Properties[0].Name != "Абстрактный")
            //        dgOntology.AddEdge(new TaggedEdge<string, string>(r.MainConcept.Name, r.SecondaryConcept.Name, r.RelationType));
            //}

            foreach (Relation r in relations)
            {
                dgOntology.AddEdge(new TaggedEdge<string, string>(r.MainConcept.Name, r.SecondaryConcept.Name, r.RelationType));
            }
        }

        private static void FormatVertex(object sender, FormatVertexEventArgs<string> e)
        {
            e.VertexFormatter.Label = e.Vertex;
            e.VertexFormatter.Shape = GraphvizVertexShape.Box;
            e.VertexFormatter.StrokeColor = GraphvizColor.Black;
            e.VertexFormatter.Font = new GraphvizFont("Calibri", 11);
        }

        private static void FormatEdge(object sender, FormatEdgeEventArgs<string, TaggedEdge<string, string>> e)
        {
            e.EdgeFormatter.Label.Value = e.Edge.Tag;
            e.EdgeFormatter.Font = new GraphvizFont("Calibri", 8);
            e.EdgeFormatter.FontGraphvizColor = GraphvizColor.Black;
            e.EdgeFormatter.StrokeGraphvizColor = GraphvizColor.Black;
        }

        private void tcClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcClass.SelectedTab == tpShow)
            {
                CreateDiagram();
                msSavePicture.Enabled = true;
            }
            else
            {
                if (pbOntology.Image != null)
                {
                    pbOntology.Image.Dispose();
                    pbOntology.Image = null;
                }
                msSavePicture.Enabled = false;
                FillTheWindow();
            }
        }

        private void msSavePicture_Click(object sender, EventArgs e)
        {
            if (pbOntology.Image != null) //если в pictureBox есть изображение
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.FileName = currentOntology.Name;
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pbOntology.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region OWL

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
                    subClassOfRelation.AttachChildNode(owlGraph.Nodes[baseUri + r.MainConcept.Name]);
                    subClassOfRelation.AttachParentNode(owlGraph.Nodes[baseUri + r.SecondaryConcept.Name]);
                    owlGraph.Edges.Add(subClassOfRelation);
                }
            }
        }

        #endregion

        #region ConceptData

        private void CreateTree(List<Concept> concepts, TreeNode parent = null)
        {
            if ((concepts != null) && (concepts.Count > 0))
            {
                if (parent == null)
                    foreach (var c in concepts)
                    {
                        TreeNode treeNode = new TreeNode(c.Name);
                        tvOntology.Nodes.Add(treeNode);
                        CreateTree(c.Child, treeNode);
                    }
                else
                    foreach (var c in concepts)
                    {
                        TreeNode treeNode = new TreeNode(c.Name);
                        parent.Nodes.Add(treeNode);
                        CreateTree(c.Child, treeNode);
                    }
            }
        }

        private void FillTheWindow()
        {
            if (activeConcept != null)
            {
                dgvAttributes.Rows.Clear();
                foreach (var p in activeConcept.Properties)
                {
                    int rowNumber = dgvAttributes.Rows.Add();
                    dgvAttributes.Rows[rowNumber].Cells["PropertyID"].Value = p.ID;
                    dgvAttributes.Rows[rowNumber].Cells["PropertyName"].Value = p.Name;
                    dgvAttributes.Rows[rowNumber].Cells["PropertyValue"].Value = p.Value;
                }
                dgvAttributes.ClearSelection();
                dgvRelations.Rows.Clear();
                foreach (var r in currentOntology.Relations)
                {
                    if ((r.MainConcept == activeConcept) || (r.SecondaryConcept == activeConcept))
                    {
                        int rowNumber = dgvRelations.Rows.Add();
                        dgvRelations.Rows[rowNumber].Cells["RelationID"].Value = r.ID;
                        dgvRelations.Rows[rowNumber].Cells["RelationName"].Value = r.Name;
                        if (r.MainConcept == activeConcept)
                            dgvRelations.Rows[rowNumber].Cells["RelationWith"].Value = r.SecondaryConcept.Name;
                        else
                            dgvRelations.Rows[rowNumber].Cells["RelationWith"].Value = r.MainConcept.Name;
                        dgvRelations.Rows[rowNumber].Cells["RelationType"].Value = r.RelationType;
                    }
                }
                dgvRelations.ClearSelection();
            }
        }

        private void AttributesEnable()
        {
            if ((activeConcept != null) && (dgvAttributes.SelectedRows.Count != 0))
            {
                btnEditAttribute.Enabled = true;
                btnDelAttribute.Enabled = true;
            }
            else
            {
                btnEditAttribute.Enabled = false;
                btnDelAttribute.Enabled = false;
            }
        }

        private void RelationsEnable()
        {
            if ((activeConcept != null) && (dgvRelations.SelectedRows.Count != 0))
            {
                if ((dgvRelations.SelectedRows[0].Cells["RelationType"].Value != null) && (dgvRelations.SelectedRows[0].Cells["RelationType"].Value.ToString() == "Наследование"))
                {
                    btnEditRelation.Enabled = false;
                    btnDelRelation.Enabled = false;
                }
                else
                {
                    btnEditRelation.Enabled = true;
                    btnDelRelation.Enabled = true;
                }
            }
            else
            {
                btnEditRelation.Enabled = false;
                btnDelRelation.Enabled = false;
            }
        }


        #endregion

        #region MenuStrip

        private void msFileCreate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(@"Если Вы не сохранили открытую онтологию, то она будет утеряна. Создать новую онтлогию?", @"Предупреждение",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                ExitCheck = true;
                Close();
            }
        }

        private void msFileOpen_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(@"Если Вы не сохранили открытую онтологию, то она будет утеряна. Открыть другую онтлогию?", @"Предупреждение",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
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
                            var ontology = (Ontology)ser.ReadObject(reader, true);
                            om.Add(ontology);
                            currentOntologyId = ontology.Id;
                            currentOntology = om.GetById(currentOntologyId);
                            this.Text = $"Ontology Interviewer - {currentOntology.Name}";
                            ClassesCheck();
                            tvOntology.Nodes.Clear();
                            CreateTree(currentOntology.Concepts);
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
            ClassesCheck();
            tvOntology.Nodes.Clear();
            CreateTree(currentOntology.Concepts);
        }

        private void msFileSaveOWL_Click(object sender, EventArgs e)
        {
            try
            {
                var sfd = new SaveFileDialog();
                sfd.Filter = "OWL File|*.owl";
                sfd.Title = "Сохранить онтологию в формате OWL";
                sfd.FileName = currentOntology.Name;
                sfd.RestoreDirectory = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    owlGraph = new OwlGraph();
                    owlGraph.NameSpaces["xmlns:" + OwlNamespaceCollection.OwlNamespacePrefix] = OwlNamespaceCollection.OwlNamespace;
                    owlGraph.NameSpaces["xmlns:" + OwlNamespaceCollection.RdfSchemaNamespacePrefix] = OwlNamespaceCollection.RdfSchemaNamespace;
                    owlGraph.NameSpaces["xmlns:daml"] = "http://www.daml.org/2001/03/daml+oil#";
                    owlGraph.NameSpaces["xmlns:dc"] = "http://purl.org/dc/elements/1.1/";
                    owlGraph.NameSpaces["xmlns"] = "http://www.owl-ontologies.com/" + currentOntology.Name + ".owl#";
                    owlGraph.NameSpaces["xml:base"] = "http://www.owl-ontologies.com/" + currentOntology.Name + ".owl";

                    string baseUri = "http://www.owl-ontologies.com/" + currentOntology.Name + ".owl#";

                    AddNodesToOWL(currentOntology.Concepts, baseUri);
                    AddRelationsToOWL(currentOntology.Relations, baseUri);

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

        private void msSaveXML_Click(object sender, EventArgs e)
        {
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
                        dcs.WriteObject(fStream, currentOntology);
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

        private void msInfo_Click(object sender, EventArgs e)
        {
            var ontology = new OntologyForm(3, currentOntologyId);
            this.Enabled = false;
            ontology.Show();
            ontology.Closed += ChildForm_Closed;
        }

        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ExitCheck)
            {
                DialogResult result = MessageBox.Show(@"Вы уверены, что хотите выйти?", @"Предупреждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                    e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void ChildForm_Closed(object sender, EventArgs e)
        {
            this.Enabled = true;
            activeConcept = null;
            ClassesCheck();
            tvOntology.Nodes.Clear();
            CreateTree(currentOntology.Concepts);
            tvOntology.ExpandAll();
            AttributesEnable();
            RelationsEnable();
            FillOntologiesList();
        }

        private void CombiningForm_Closed(object sender, EventArgs e)
        {
            SwitchSettings();
            activeConcept = null;
            ClassesCheck();
            tvOntology.Nodes.Clear();
            currentOntology = om.GetCurrentOntology();
            CreateTree(currentOntology.Concepts);
            tvOntology.ExpandAll();
            AttributesEnable();
            RelationsEnable();
            FillOntologiesList();
        }

        private void msExistingOntologies_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            currentOntologyId = om.Open(e.ClickedItem.Text);
            currentOntology = om.GetById(currentOntologyId);
            this.Text = $"Ontology Interviewer - {currentOntology.Name}";
            ClassesCheck();
            tvOntology.Nodes.Clear();
            CreateTree(currentOntology.Concepts);
        }

        private void FillOntologiesList()
        {
            msExistingOntologies.DropDownItems.Clear();
            foreach(var onto in om._ontologies)
            {
                msExistingOntologies.DropDownItems.Add(onto.Name);
            }
        }

        private void combineOntologiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var combineForm = new CombineOntologyForm();
            SwitchSettings();
            combineForm.Show();
            combineForm.Closed += CombiningForm_Closed;
        }

        private void SwitchSettings()
        {
            if (Visible)
                Hide();
            else
                Show();
        }

        private void toolStripMenuDSL_Click(object sender, EventArgs e)
        {
            var DSLgenerationForm = new DSL_Form();
            SwitchSettings();
            DSLgenerationForm.Show();
            DSLgenerationForm.Closed += CombiningForm_Closed;
        }
    }

    public sealed class FileDotEngine : IDotEngine
    {
        public string Run(GraphvizImageType imageType, string dot, string outputFileName)
        {
            string output = outputFileName;
            System.IO.File.WriteAllText(output, dot);
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"graphs\dot.exe";
            startInfo.Arguments = @"dot -T png graph.dot -o graph.png";
            Process.Start(startInfo);
            return output;
        }
    }
}
