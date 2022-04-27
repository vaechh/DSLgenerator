using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OntologyCreator.Attributes;
using OntologyCreator.Concepts;
using System.Text.RegularExpressions;

namespace OntologyCreator.Forms
{
    public partial class PropertyForm : Form
    {
        private int Id = -1;
        private bool ExitCheck;
        private int Mode;
        private int OntologyId;
        private Concept parent;
        private Property property;
        private Regex rgxInteger = new Regex(@"(?<!\S)([-]?\b(([1-9]\d*))|([0]))\b(?!\S)");
        private Regex rgxDouble = new Regex(@"(?<!\S)-?\d+(?:\.\d+)?(?!\S)");

        public PropertyForm(int mode, int ontologyId, Concept concept = null, Property attribute = null)
        {
            InitializeComponent();
            ExitCheck = false;
            Mode = mode;
            parent = concept;
            OntologyId = ontologyId;
            if (Mode == 1)
            {
                Text = "Создание атрибута для " + parent.Name;
                ButtonEnable();
                lblInterview.Text = "Введите характеристики для свойства, которым обладает сущность " + parent.Name + 
                     ". Поля со звёздочкой - обязательные.";
            }
            else if (Mode == 2)
            {
                Text = "Редактирование атрибута " + attribute.Name;
                tbName.Text = attribute.Name;
                tbDescript.Text = attribute.Description;
                cbType.SelectedItem = cbType.Items[(int)attribute.ValueType - 1];
                tbValue.Text = attribute.Value.ToString();
                Id = attribute.ID;
                property = attribute;
                btnAction.Text = "Сохранить";
                btnBack.Text = "Отмена";
                lblInterview.Text = "Для сохранения данных нажмите на кнопку \"Сохранить\".";
            }
            else if (Mode == 3)
            {
                Text = "Атрибут " + attribute.Name;
                Id = attribute.ID;
                property = attribute;
                DeactivateFields();
                Text = attribute.Name;
                tbName.Text = attribute.Name;
                tbDescript.Text = attribute.Description;
                cbType.SelectedItem = cbType.Items[(int)attribute.ValueType - 1];
                tbValue.Text = attribute.Value.ToString();
                btnAction.Text = "Редактировать";
                lblInterview.Text = "Здесь Вы можете изменить характеристики свойства " + attribute.Name + " сущности " +
                   parent.Name + "Для изменения характеристик свойства нажмите на кнопку \"Редактировать\".";
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (NameExists(Id, tbName.Text, parent.Properties))
            {
                MessageBox.Show("Свойство с таким названием уже существует у данной сущности", @"Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            switch (cbType.SelectedIndex + 1)
            {
                case 1:
                    if (!rgxInteger.IsMatch(tbValue.Text))
                    {
                        MessageBox.Show("Значение свойства не соответствует его типу данных", @"Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        tbValue.Text = "";
                        return;
                    }
                    break;
                case 2:
                    if (!rgxDouble.IsMatch(tbValue.Text))
                    {
                        MessageBox.Show("Значение свойства не соответствует его типу данных", @"Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        tbValue.Text = "";
                        return;
                    }
                    break;
            }
            if (Mode == 1)
            {
                try
                {
                    Property attribute = new Property(parent.ID, OntologyId);
                    attribute.Name = tbName.Text;
                    attribute.Description = tbDescript.Text;
                    attribute.ValueType = (Property.TypeEnum)(cbType.SelectedIndex + 1);
                    attribute.Value = tbValue.Text;
                    parent.Properties.Add(attribute);
                    MessageBox.Show("Свойство успешно добавлено", @"Сообщение",
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
                    parent.Properties.Find(p => p.ID == Id).Name = tbName.Text;
                    parent.Properties.Find(p => p.ID == Id).Description = tbDescript.Text;
                    parent.Properties.Find(p => p.ID == Id).ValueType = (Property.TypeEnum)(cbType.SelectedIndex + 1);
                    parent.Properties.Find(p => p.ID == Id).Value = tbValue.Text;
                    MessageBox.Show("Характеристики свойства успешно отредактированы", @"Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: не правильно введены данные.\nИсточник ошибки: " + ex.Message, @"Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                DeactivateFields();
                Text = "Атрибут " + property.Name;
                Mode = 3;
                btnAction.Text = "Редактировать";
                btnBack.Text = "Назад";
                lblInterview.Text = "Здесь Вы можете изменить характеристики свойства " + property.Name + " сущности " +
                   parent.Name + ". Для сохранения данных нажмите на кнопку \"Сохранить\".";
            }
            else if (Mode == 3)
            {
                ActivateFields();
                Text = "Редактирование атрибута " + property.Name;
                btnAction.Text = "Сохранить";
                btnBack.Text = "Отмена";
                Mode = 2;
                lblInterview.Text = "Для изменения характеристик свойства " + property.Name + " сущности " +
                   parent.Name + " нажмите на кнопку \"Редактировать\".";
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
                lblInterview.Text = "Здесь Вы можете изменить характеристики свойства " + property.Name + " сущности " +
                   parent.Name + ". Для сохранения данных нажмите на кнопку \"Сохранить\"."; 
                Text = "Атрибут " + property.Name;
            }
            else
            {
                ExitCheck = true;
                if (Mode == 1)
                {
                    if ((tbName.Text.Trim() == "") && (tbDescript.Text.Trim() == "") && (tbValue.Text.Trim() == "")
                        && (cbType.SelectedIndex == -1))
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
            if ((tbName.Text.Trim() != "") && (tbValue.Text.Trim() != "") && (cbType.SelectedIndex != -1))
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

        private void ValueEnable()
        {
            if (cbType.SelectedIndex != -1)
            {
                tbValue.Enabled = true;
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            ButtonEnable();
        }

        private void tbValue_TextChanged(object sender, EventArgs e)
        {
            ButtonEnable();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValueEnable();
            if ((property != null) && (cbType.SelectedIndex + 1 != (int)property.ValueType))
                tbValue.Text = "";
            ButtonEnable();
        }

        public void DeactivateFields()
        {
            foreach (Control tb in Controls)
                if (tb is TextBox)
                    ((TextBox)tb).ReadOnly = true;
            cbType.Enabled = false;
            tbName.Text = property.Name;
            tbDescript.Text = property.Description;
            cbType.SelectedItem = cbType.Items[(int)property.ValueType - 1];
            tbValue.Text = property.Value.ToString();
        }

        public void ActivateFields()
        {
            foreach (Control tb in Controls)
                if (tb is TextBox)
                    ((TextBox)tb).ReadOnly = false;
            cbType.Enabled = true;
        }

        private void PropertyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ExitCheck)
            {
                if (Mode == 1)
                {
                    if ((tbName.Text.Trim() == "") && (tbDescript.Text.Trim() == "") && (tbValue.Text.Trim() == "")
                        && (cbType.SelectedIndex == -1))
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

        private bool NameExists(int id, string name, List<Property> properties)
        {
            bool answer = false;
            if ((properties != null) && (properties.Count > 0))
                foreach (Property p in properties)
                {
                    if (string.Compare(p.Name, name, true) == 0 && p.ID != id)
                        answer = true;
                }
            return answer;
        }
    }
}
