using OntologyCreator.Concepts;
using OntologyCreator.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml;

namespace OntologyCreator.Forms
{
    public partial class DSL_Form : Form
    {
        private OntologyManager om = OntologyManager.getManager();
        private Ontology currentOntology;
        private Ontology languagesOntology;
        private Ontology metaOntology;
        private Ontology resultOntology;
        bool saveRelations = false;
        private Concept languageConcept;

        DataGridViewComboBoxColumn ProjectionCombobox = new DataGridViewComboBoxColumn();
        private BindingList<string> ds = new BindingList<string>();

        public void LoadOntologyDialog()
        {
            DialogResult load = MessageBox.Show(
                "Выбрать текущую онтологию в качестве онтологии предметной области?",
                "Генератор",
                MessageBoxButtons.YesNo);

            if (load == DialogResult.No)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Multiselect = false,
                    DefaultExt = "*.owl; *.xml",
                    Filter = @"All Files (*.owl, *.xml) | *.owl; *.xml",
                    Title = @"Выберите онтологию в формате OWL или XML",
                    InitialDirectory = path + @"\\"
                };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var ext = ofd.FileName.Split('.').Last().ToUpperInvariant();
                        switch (ext)
                        {
                            case "XML":
                                DataContractSerializer ser = new DataContractSerializer(typeof(Ontology));
                                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                                {
                                    XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                                    var ontology = (Ontology)ser.ReadObject(reader, true);
                                    om.Add(ontology);
                                    reader.Close();
                                    fs.Close();
                                }
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@"Ошибка: не удалось считать файл с диска. Источник ошибки: " + ex.Message, @"Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }
        public DSL_Form()
        {
            InitializeComponent();
            LoadOntologyDialog();
            currentOntology = om.GetCurrentOntology();
            CreateFlp();
        }
        private void CreateFlp()
        {
            dgvProjection.Rows.Clear();

            ProjectionCombobox.HeaderText = "Проекция";
            ProjectionCombobox.Name = "Projections";
            dgvProjection.Columns.Add(ProjectionCombobox);
        }
        private void FillFlp()
        {
            dgvProjection.Rows.Clear();

            //List<Concept> concepts = getConcepts(currentOntology.Concepts);
            List<Concept> concepts = currentOntology.Concepts;
            List<Relation> relations = currentOntology.Relations;
            List<string> rl = new List<string>();

            foreach (var elem in relations)
                if (!rl.Contains(elem.Name) && elem.RelationType != "Наследование")
                    rl.Add(elem.Name);

            foreach (var elem in concepts)
                dgvProjection.Rows.Add(elem.Name, "Класс");

            foreach (var r in rl)
                dgvProjection.Rows.Add(r, "Связь");
        }
        private List<Concept> getConcepts(List<Concept> ct)
        {
            List<Concept> result = new List<Concept>();
            foreach (Concept head in ct)
            {
                result.Add(head);
                result.AddRange(getConcepts(head.Child));
            }
            return result;
        }
        private void btnChooseOntology_Click(object sender, EventArgs e)
        {
            LanguageOntologySelectionForm f = new LanguageOntologySelectionForm();
            f.ShowDialog();
            string path = f.resultPath;

            try
            {
                var ext = path.Split('.').Last().ToUpperInvariant();
                switch (ext)
                {
                    case "XML":
                        DataContractSerializer ser = new DataContractSerializer(typeof(Ontology));
                        using (FileStream fs = new FileStream(path, FileMode.Open))
                        {
                            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                            var ontology = (Ontology)ser.ReadObject(reader, true);
                            om.Add(ontology);
                            reader.Close();
                            fs.Close();
                        }
                        break;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(@"Ошибка: не удалось считать файл с диска. Источник ошибки: " + ex.Message, @"Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            languagesOntology=om.GetCurrentOntology();
            CreateLanguagesTree(languagesOntology.Concepts);
        }
        private void CreateLanguagesTree(List<Concept> concepts, TreeNode parent = null)
        {
            if ((concepts != null) && (concepts.Count > 0))
            {
                if (parent == null)
                    foreach (var c in concepts)
                    {
                        if (c.Description != "")
                        {
                            TreeNode treeNode = new TreeNode(c.Name);
                            tvOntologyLanguage.Nodes.Add(treeNode);
                            CreateLanguagesTree(c.Child, treeNode);
                        }
                    }
                else
                    foreach (var c in concepts)
                    {
                        if (c.Description != "")
                        {
                            TreeNode treeNode = new TreeNode(c.Name);
                            parent.Nodes.Add(treeNode);
                            CreateLanguagesTree(c.Child, treeNode);
                        }
                    }
            }
        }
        private void tvOntologyDsls_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnSelectLanguage.Enabled = false;

            var t = tvOntologyLanguage.SelectedNode;

            List<Concept> concepts = getConcepts(languagesOntology.Concepts);
            foreach (var elem in concepts)
                if (t.Text == elem.Name && elem.Description == "language")
                    btnSelectLanguage.Enabled = true;
        }
        private void CreateMetalanguageOntology(Concept mainConcept)
        {
            List<Concept> concepts = getConcepts(mainConcept.Child);

            List<Relation> relations = new List<Relation>();

            foreach (var elem in languagesOntology.Relations)
                if (concepts.Contains(elem.MainConcept) && concepts.Contains(elem.SecondaryConcept))
                    relations.Add(elem);

            metaOntology = new Ontology(mainConcept.Name, mainConcept.Description);
            om.Add(metaOntology);
            metaOntology.Relations = relations;
            metaOntology.Concepts = concepts;
        }
        private void fillLanguageTree(List<Concept> concepts, TreeView tree, TreeNode parent = null)
        {
            if ((concepts != null) && (concepts.Count > 0))
            {
                if (parent == null)
                    foreach (var c in concepts)
                    {
                        TreeNode treeNode = new TreeNode(c.Name);
                        tree.Nodes.Add(treeNode);
                        fillLanguageTree(c.Child, tree,treeNode);
                    }
                else
                    foreach (var c in concepts)
                    {
                        TreeNode treeNode = new TreeNode(c.Name);
                        parent.Nodes.Add(treeNode);
                        fillLanguageTree(c.Child, tree,treeNode);
                    }
            }
        }
        private void btnSelectLanguage_Click(object sender, EventArgs e)
        {
            var t = tvOntologyLanguage.SelectedNode;
            List<Concept> concepts = getConcepts(languagesOntology.Concepts);

            Concept mainConcept=null;

            foreach (var elem in concepts)
                if (t.Text == elem.Name && elem.Description == "language")
                    mainConcept=elem;

            languageConcept = mainConcept;
            CreateMetalanguageOntology(mainConcept);
            tvOntologyLanguage.Nodes.Clear();
            fillLanguageTree(metaOntology.Concepts,tvOntologyLanguage);
            fillLanguageTree(currentOntology.Concepts, tvOntologyDomain);

            btnChooseOntology.Visible = false;
            btnSelectLanguage.Visible = false;

            FillFlp();
            try
            {
                concepts = getConcepts(mainConcept.Child);
                ds.Clear();
                foreach (var elem in concepts)
                    ds.Add(elem.Name);
                ProjectionCombobox.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Ошибка: Не удалось выбрать язык в качестве основы. Источник ошибки: " + ex.Message, @"Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void IncludeInMetalanguageOntology()
        {
            foreach(var rl in languagesOntology.Relations)
                if(rl.SecondaryConcept == languageConcept)
                {
                    Concept newLanguageConcept = new Concept(languagesOntology.Id, rl.MainConcept.ID);
                    newLanguageConcept.Name = rl.MainConcept.Name + " для " + currentOntology.Name;

                    rl.MainConcept.Child.Add(newLanguageConcept);

                    languagesOntology.Relations.Add(new Relation(languagesOntology.Id, rl.MainConcept, newLanguageConcept) { RelationType="Наследование"});


                    foreach (var cncpt in resultOntology.Concepts)
                    {
                        //Concept newElem = new Concept(languagesOntology.Id, newLanguageConcept.ID);
                        //newElem = (Concept)cncpt.Clone(languagesOntology.Id, newElem.ID, newLanguageConcept.ID);
                        //newElem.Name = newElem.Name;
                        //newLanguageConcept.Child.Add(newElem);

                        Concept newElem;
                        newElem = (Concept)cncpt.Clone(languagesOntology.Id, Utils.FindMaxConceptId(languagesOntology.Concepts), newLanguageConcept.ID);
                        newElem.Name = newElem.Name+"_Copy";
                        newLanguageConcept.Child.Add(newElem);
                    }

                    foreach (var rltn in languagesOntology.Relations)
                    {
                        if (rltn.MainConcept == languageConcept)
                        {
                            foreach (var c in newLanguageConcept.Child)
                            {
                                languagesOntology.Relations.Add((Relation)rltn.Clone(languagesOntology.Id, newLanguageConcept, c));
                            }
                            break;
                        }
                    }

                    foreach (var reltn in resultOntology.Relations)
                    {
                        Concept c1 = getConceptByName(languagesOntology, reltn.MainConcept.Name);
                        Concept c2 = getConceptByName(languagesOntology, reltn.SecondaryConcept.Name);

                        foreach (var bc in newLanguageConcept.Child)
                        {
                            if (c1.Name + "_Copy" == bc.Name )
                                c1 = bc;
                            if (c2.Name + "_Copy" == bc.Name )
                                c2 = bc;
                        }

                        languagesOntology.Relations.Add((Relation)reltn.Clone(languagesOntology.Id, c1, c2));
                    }

                    break;
                }
            try
            {
                var sfd = new SaveFileDialog();
                sfd.Filter = "XML File|*.xml";
                sfd.Title = "Сохранить онтологию в формате XML";
                sfd.FileName = languagesOntology.Name+" Расширенная";
                sfd.RestoreDirectory = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var dcss = new DataContractSerializerSettings { PreserveObjectReferences = true };
                    var dcs = new DataContractSerializer(typeof(Ontology), dcss);

                    using (Stream fStream = new FileStream(sfd.FileName,
                        FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        dcs.WriteObject(fStream, languagesOntology);
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
        private void rdyBtn_Click(object sender, EventArgs e)
        {
            //Если некоторые связи были спроецированы на сущности, для удобства сразу преобразуем их в классы
            FindAndReplaceRelations();

            //Алгоритм генерации новой DSL онтологии
            GenerateDSL();

            //Сохранение получившейся онтологии
            try
            {
                var sfd = new SaveFileDialog();
                sfd.Filter = "XML File|*.xml";
                sfd.Title = "Сохранить онтологию в формате XML";
                sfd.FileName = resultOntology.Name;
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
            //IncludeInMetalanguageOntology();
        }
        private bool ContainThisConcept(Ontology ontology, Concept concept)
        {
            List<Concept> Concepts = getConcepts(ontology.Concepts);

            foreach(var c in Concepts)
                if (c.Name == concept.Name)
                    return true;

            return false;
        }
        private Concept getConceptByName(Ontology ontology,string name)
        {
            foreach (var c in getConcepts(ontology.Concepts))
                if (c.Name == name)
                    return c;

            return null;
        }
        private void CopyInheritance(Concept concept)
        {
            if (concept.Child.Count == 0)
                return;
            
            foreach(var child in concept.Child)
            {
                Relation nasledovanie = new Relation(resultOntology.Id, concept, child);
                nasledovanie.RelationType = "Наследование";
                resultOntology.Relations.Add(nasledovanie);
                CopyInheritance(child);
            }
        }
        private void GenerateDSL()
        {
            //получаем все связи из онтологии предметной области
            List<Relation> domainRelations = currentOntology.Relations;

            //получаем все связи и классы из онтологии базового языка
            List<Concept> metalanguageConcepts = getConcepts(metaOntology.Concepts);
            List<Relation> metalanguageRelations = metaOntology.Relations;

            //создаем новую пустую онтологию
            resultOntology= new Ontology("custom_"+metaOntology.Name,"new dsl ontology");
            om.Add(resultOntology);

            //копируем классы из базового языка в новую онтологию
            foreach (var c in metalanguageConcepts)
            {
                if (!ContainThisConcept(resultOntology, c))
                {
                    Concept concept = new Concept(resultOntology.Id);
                    concept = (Concept)c.Clone(resultOntology.Id, concept.ID);

                    OntologyCreator.Attributes.Property pr = new Attributes.Property(concept.ID, resultOntology.Id, "Абстрактный", "Класс является абстрактным", Attributes.Property.TypeEnum.String, "Абстрактный");
                    concept.Properties.Add(pr);

                    resultOntology.Concepts.Add(concept);
                }
            }

            //копируем связи из базового языка в новую онтологию
            if(!saveRelations)
            foreach (var r in metalanguageRelations)
            {
                Concept c1 = getConceptByName(resultOntology,r.MainConcept.Name);
                Concept c2 = getConceptByName(resultOntology, r.SecondaryConcept.Name);

                resultOntology.Relations.Add((Relation)r.Clone(resultOntology.Id, c1, c2));
            }

            //Первый проход: проецирование классов
            //Для каждого класса предметной онтологии:
            for (int i = 0; i < dgvProjection.Rows.Count; i++)
            {
                try
                {
                    string name = dgvProjection.Rows[i].Cells["Names"].Value.ToString();
                    string projection = dgvProjection.Rows[i].Cells["Projections"].Value?.ToString();
                    string type = dgvProjection.Rows[i].Cells["Type"].Value.ToString();

                    //Добавляем каждому классу базового языка соответсвующие подклассы, которые были спроецированы пользователем
                    if (type == "Класс" && projection!=null)
                    {
                        if (!ContainThisConcept(resultOntology, getConceptByName(currentOntology, name)))
                        {
                            Concept father = getConceptByName(resultOntology, projection);
                            Concept newSon = new Concept(resultOntology.Id);
                            newSon=(Concept)getConceptByName(currentOntology, name).Clone(resultOntology.Id, newSon.ID);

                            father.Child.Add(newSon);

                            Relation nasledovanie = new Relation(resultOntology.Id, father, newSon);
                            nasledovanie.RelationType = "Наследование";
                            resultOntology.Relations.Add(nasledovanie);

                            //        public Property(int parentId, int ontologyId, string name, string description, TypeEnum type, object value)


                            CopyInheritance(newSon);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Возникла ошибка при проецировании класса. Информация: " + ex.Message, @"Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }

            //Второй проход: добавление связей
            //На данном этапе возможно разветвление на два варианта:

            //1. Связи, указанные в онтологии предметной области не учитываются.
            //в этом случае, делать ничего не нужно, созданные подклассы наследуют связи родителя.
            //Этот вариант подходит например при расширении одного класса

            //2. Связи, указанные в онтологии предметной области будут учитываться

            if(saveRelations)
            {
                foreach(var relation in domainRelations)
                {
                    Concept c1 = getConceptByName(resultOntology, relation.MainConcept.Name);
                    Concept c2 = getConceptByName(resultOntology, relation.SecondaryConcept.Name);


                    if(c1!=null && c2!=null && relation.RelationType!="Наследование")
                        resultOntology.Relations.Add((Relation)relation.Clone(resultOntology.Id, c1, c2));
                }
            }    

        }
        private void FindAndReplaceRelations()
        {
            List<Relation> domainRelations = currentOntology.Relations;
            List<Concept> metalanguageConcepts = getConcepts(metaOntology.Concepts);

            for (int i = 0; i < dgvProjection.Rows.Count; i++)
            {
                try
                {
                    string name = dgvProjection.Rows[i].Cells["Names"].Value.ToString();
                    string projection = dgvProjection.Rows[i].Cells["Projections"].Value?.ToString();
                    string type = dgvProjection.Rows[i].Cells["Type"].Value.ToString();

                    List<Relation> toDelete = new List<Relation>();
                    List<Relation> toAdd = new List<Relation>();

                    foreach (var concept in metalanguageConcepts)
                        if (type == "Связь" && concept.Name == projection)
                        {
                            foreach (var rl in domainRelations)
                                if (rl.Name == name)
                                {
                                    dgvProjection.Rows[i].Cells["Type"].Value = "Класс";
                                    toDelete.Add(rl);
                                    toAdd.AddRange(ReplaceRelationByConcept(rl));
                                }
                        }

                    foreach (var td in toDelete)
                        currentOntology.Relations.Remove(td);
                    foreach (var ta in toAdd)
                        currentOntology.Relations.Add(ta);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Возникла ошибка при проецировании. Информация: " + ex.Message, @"Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
        private List<Relation> ReplaceRelationByConcept(Relation relation)
        {
            Concept newConcept = new Concept(currentOntology.Id);

            Concept fstConcept= relation.MainConcept;
            Concept secConcept = relation.SecondaryConcept;

            newConcept.Name = relation.Name;
            newConcept.Description = relation.Description;

            Relation rl1 = new Relation(currentOntology.Id, fstConcept, newConcept);
            rl1.RelationType = relation.RelationType;
            Relation rl2 = new Relation(currentOntology.Id, newConcept, secConcept);
            rl2.RelationType = relation.RelationType;

            currentOntology.Concepts.Add(newConcept);

            return new List<Relation>() { rl1, rl2 };
        }
        private void chbSaveRelations_CheckedChanged(object sender, EventArgs e)
        {
            saveRelations = chbSaveRelations.Checked;
        }
    }
}
