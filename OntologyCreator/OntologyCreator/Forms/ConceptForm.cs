using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OntologyCreator.Concepts;
using OntologyCreator.Relations;
using OntologyCreator.Attributes;
using System.Linq;

namespace OntologyCreator.Forms
{
    public partial class ConceptForm : Form
    {
        private int Id = -1;
        private bool ExitCheck;
        private int Mode; // 1 -создание, 2 - редактирование, 3 - просмотр, 4 - создание подкласса
        private Concept parent;
        private Ontology ontology;

        public ConceptForm(int mode, int ontologyId, Concept concept = null, Concept activeConcept = null)
        {
            InitializeComponent();
            ExitCheck = false;
            Mode = mode;
            ontology = OntologyManager.getManager().GetById(ontologyId);
            if (Mode == 1)
            {
                Text = "Добавление класса онтологии";
                ButtonEnable();
                lblInterview.Text = "Введите название создаваемой сущности. " +
                    "При желании можете ввести её описание.";
            }
            else if (Mode == 2)
            {
                Text = "Редактирование класса " + concept.Name;
                tbName.Text = concept.Name;
                tbDescript.Text = concept.Description;
                Id = concept.ID;
                btnAction.Text = "Сохранить";
                btnBack.Text = "Отмена";
                lblInterview.Text = "Здесь Вы можете изменить название и описание сущности " + concept.Name + "." +
                    "Для сохранения данных нажмите на кнопку \"Сохранить\".";
            }
            else if (Mode == 4)
            {
                parent = activeConcept;
                cbProperties.Enabled = true;
                Text = "Добавление подкласса к " + parent.Name;
                ButtonEnable();
                lblInterview.Text = "Введите название создаваемой сущности. " +
                    "При желании можете ввести её описание. Данный класс будет являться подклассом " + parent.Name + ".";
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (Utils.ConceptNameExists(Id, tbName.Text, ontology.Concepts))
            {
                MessageBox.Show("Класс с таким именем уже существует в онтологии", @"Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            if (Mode == 1)
            {
                try
                {
                    var concept = new Concept(ontology.Id);
                    concept.Name = tbName.Text;
                    concept.Description = tbDescript.Text;
                    ontology.Concepts.Add(concept);
                    MessageBox.Show("Класс успешно добавлен в онтологию", @"Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: не правильно введены данные.\nИсточник ошибки: " + ex.Message, @"Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else if (Mode == 2)
            {
                try
                {
                    Utils.FindConceptByID(Id, ontology.Concepts).Name = tbName.Text;
                    Utils.FindConceptByID(Id, ontology.Concepts).Description = tbDescript.Text;
                    MessageBox.Show("Класс успешно изменён", @"Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: не правильно введены данные.\nИсточник ошибки: " + ex.Message, @"Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else if (Mode == 4)
            {
                try
                {
                    var concept = new Concept(ontology.Id);
                    concept.ParentID = parent.ID;
                    concept.Name = tbName.Text;
                    concept.Description = tbDescript.Text;
                    if (cbProperties.Checked)
                    {
                        var propertyId = 1;
                        concept.Properties = Utils.FindConceptByID(parent.ID, ontology.Concepts).Properties.Select(p => (Property)p.Clone(propertyId++, concept.ID, ontology.Id)).ToList();
                    }
                    Utils.FindConceptByID(parent.ID, ontology.Concepts).Add(concept);
                    Utils.CreateFamilyRelationsUp(parent, concept, ontology.Id);
                    MessageBox.Show("Подкласс успешно добавлен к классу " + parent.Name + ".", @"Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: не правильно введены данные.\nИсточник ошибки: " + ex.Message, @"Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            ExitCheck = true;
            Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ExitCheck = true;
            if ((Mode == 1) || (Mode == 4))
            {
                if ((tbName.Text.Trim() == "") && (tbDescript.Text.Trim() == ""))
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
            else if (Mode == 2)
            {
                Close();
            }
            ExitCheck = false;
        }

        private void ButtonEnable()
        {
            if (tbName.Text.Trim() != "")
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
                btnAction.Text = "Необходимо ввести название";
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            ButtonEnable();
        }

        private void ConceptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ExitCheck)
            {
                if ((Mode == 1) || (Mode == 4))
                {
                    if ((tbName.Text.Trim() == "") && (tbDescript.Text.Trim() == ""))
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
                else if (Mode == 2)
                {
                    e.Cancel = false;
                }
            }
            else
                e.Cancel = false;
        }
    }
}
