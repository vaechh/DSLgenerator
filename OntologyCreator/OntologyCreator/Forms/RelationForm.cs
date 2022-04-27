using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OntologyCreator.Concepts;
using OntologyCreator.Relations;

namespace OntologyCreator.Forms
{
    public partial class RelationForm : Form
    {
        private int Id = -1;
        private bool ExitCheck;
        private int Mode;
        private Concept parent;
        private Relation relation;
        private Ontology ontology;

        public RelationForm(int mode, int ontologyId, Concept concept = null, Relation relat = null)
        {
            InitializeComponent();
            ExitCheck = false;
            Mode = mode;
            ontology = OntologyManager.getManager().GetById(ontologyId);
            parent = concept;
            if (Mode == 1)
            {
                Text = "Создание связи для " + parent.Name;
                ButtonEnable();
                lblInterview.Text = "Введите характеристики для связи между " + parent.Name + " и выбранным Вами классом" +
                     ". Поля со звёздочкой - обязательные.";
                MakeATbList(ontology.Concepts, parent);
            }
            else if (Mode == 2)
            {
                Id = relat.ID;
                relation = relat;
                cbClasses.Enabled = false;
                Text = "Редактирование связи " + relation.Name;
                tbName.Text = relation.Name;
                tbDescription.Text = relation.Description;
                if (relation.MainConcept == parent)
                {
                    cbClasses.Items.Add(relation.SecondaryConcept.Name);
                    cbClasses.SelectedIndex = 0;
                }
                else
                {
                    cbClasses.Items.Add(relation.SecondaryConcept.Name);
                    cbClasses.SelectedIndex = 0;
                }
                tbRelationType.Text = relation.RelationType;
                btnAction.Text = "Сохранить";
                btnBack.Text = "Отмена";
                lblInterview.Text = "Для сохранения данных нажмите на кнопку \"Сохранить\".";
            }
            else if (Mode == 3)
            {
                Id = relat.ID;
                relation = relat;
                cbClasses.Enabled = false;              
                Text = "Связь " + relation.Name;
                tbName.Text = relation.Name;
                tbDescription.Text = relation.Description;
                if (relation.MainConcept == parent)
                {
                    cbClasses.Items.Add(relation.SecondaryConcept.Name);
                    cbClasses.SelectedIndex = 0;
                }
                else
                {
                    cbClasses.Items.Add(relation.SecondaryConcept.Name);
                    cbClasses.SelectedIndex = 0;
                }
                DeactivateFields();
                tbRelationType.Text = relation.RelationType;
                btnAction.Text = "Редактировать";
                lblInterview.Text = "Здесь Вы можете изменить настройки связи" + relation.Name + 
                    "Для изменения характеристик связи нажмите на кнопку \"Редактировать\".";
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (Utils.RelationNameExists(Id, tbName.Text, ontology.Relations))
            {
                MessageBox.Show("Связь с таким названием уже существует", @"Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (tbName.Text.Trim() == "Наследование" || tbName.Text.Trim() == "наследование")
            {
                MessageBox.Show("Данный тип связи можно устанавливать только путём добавления подклассов к классу", @"Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (Mode == 1)
            {
                try
                {
                    Relation connect = new Relation(ontology.Id, parent, Utils.FindConceptByName(cbClasses.Text, ontology.Concepts));
                    connect.Name = tbName.Text;
                    connect.Description = tbDescription.Text;
                    connect.RelationType = tbRelationType.Text;
                    ontology.Relations.Add(connect);
                    MessageBox.Show("Связь успешно добавлена", @"Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: не правильно введены данные.\nИсточник ошибки: " + ex.Message, @"Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                ExitCheck = true;
                Close();
            }
            else if (Mode == 2)
            {
                try
                {
                    ontology.Relations.Find(r => r.ID == Id).Name = tbName.Text;
                    ontology.Relations.Find(r => r.ID == Id).Description = tbDescription.Text;
                    ontology.Relations.Find(r => r.ID == Id).RelationType = tbRelationType.Text;
                    MessageBox.Show("Характеристики связи успешно отредактированы", @"Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: не правильно введены данные.\nИсточник ошибки: " + ex.Message, @"Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                DeactivateFields();
                Text = "Связь " + relation.Name;
                Mode = 3;
                btnAction.Text = "Редактировать";
                btnBack.Text = "Назад";
                lblInterview.Text = "Здесь Вы можете изменить настройки связи" + relation.Name +
                    "Для изменения характеристик связи нажмите на кнопку \"Редактировать\".";
            }
            else if (Mode == 3)
            {
                ActivateFields();
                Text = "Редактирование связи " + relation.Name;
                btnAction.Text = "Сохранить";
                btnBack.Text = "Отмена";
                Mode = 2;
                lblInterview.Text = "Для сохранения данных нажмите на кнопку \"Сохранить\".";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Mode == 2)
            {
                DeactivateFields();
                Mode = 3;
                btnAction.Text = "Редактировать";
                btnBack.Text = "Назад";
                lblInterview.Text = "Здесь Вы можете изменить характеристики связи " + relation.Name + ". Для сохранения данных нажмите на кнопку \"Сохранить\".";
                Text = "Связь " + relation.Name;
            }
            else
            {
                ExitCheck = true;
                if (Mode == 1)
                {
                    if ((tbName.Text.Trim() == "") && (tbDescription.Text.Trim() == "") && (tbRelationType.Text.Trim() == "")
                        && (cbClasses.SelectedIndex == -1))
                        Close();
                    else
                    {
                        DialogResult result = MessageBox.Show("При переходе назад все введённые данные будут утеряны\n" +
                            "Вы уверены, что хотите вернутся назад?", @"Предупреждение",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                            Close();
                    }
                }
                else if (Mode == 3)
                {
                    Close();
                }
                ExitCheck = false;
            }
        }

        private void ButtonEnable() 
        {
            if ((tbName.Text.Trim() != "") && (tbRelationType.Text.Trim() != "") && (cbClasses.SelectedIndex != -1))
            {
                btnAction.Enabled = true;
                if (Mode == 1)
                    btnAction.Text = "Добавить";
                else
                    btnAction.Text = "Сохранить";
            }
            else
            {
                btnAction.Enabled = false;
                btnAction.Text = "Необходимо заполнить поля";
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            ButtonEnable();
        }

        private void cbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClasses.SelectedIndex != -1)
                tbRelationType.Enabled = true;
            ButtonEnable();
        }

        private void MakeATbList(List<Concept> concepts, Concept composite)
        {
            if ((concepts != null) && (concepts.Count > 0))
                foreach (var c in concepts)
                {
                    if (ontology.Relations.Find(r => ((r.MainConcept.Name == parent.Name
                        && r.SecondaryConcept.Name == c.Name) || (r.SecondaryConcept.Name == parent.Name && r.MainConcept.Name == c.Name))) == null)
                        if (!cbClasses.Items.Contains(c.Name))
                            //if (c.Name != parent.Name)
                                cbClasses.Items.Add(c.Name);
                    MakeATbList(c.Child, composite);
                }
        }

        public void DeactivateFields()
        {
            tbName.Enabled = false;
            tbDescription.Enabled = false;
            tbRelationType.Enabled = false;
            tbName.Text = relation.Name;
            tbDescription.Text = relation.Description;
            tbRelationType.Text = relation.RelationType;
        }

        public void ActivateFields()
        {
            tbName.Enabled = true;
            tbDescription.Enabled = true;
            tbRelationType.Enabled = true;
        }

        private void RelationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ExitCheck)
            {
                if (Mode == 1)
                {
                    if ((tbName.Text.Trim() == "") && (tbDescription.Text.Trim() == "") && (tbRelationType.Text.Trim() == "")
                        && (cbClasses.SelectedIndex == -1))
                        e.Cancel = false;
                    else
                    {
                        DialogResult result = MessageBox.Show("При переходе назад все введённые данные будут утеряны\n" +
                        "Вы уверены, что хотите вернутся назад?", @"Предупреждение",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                            e.Cancel = false;
                        else
                            e.Cancel = true;
                    }
                }
                else if (Mode == 3)
                    e.Cancel = false;
            }
            else
                e.Cancel = false;
        }
    }
}
