using System;
using System.Windows.Forms;

namespace OntologyCreator.Forms
{
    public partial class OntologyForm : Form
    {
        private int Mode;
        private Ontology ontology;
        private OntologyManager om = OntologyManager.getManager();

        public OntologyForm(int mode, int ontologyId)
        {
            InitializeComponent();
            Mode = mode;
            ontology = om.GetById(ontologyId);
            if (Mode == 3)
            {
                DeactivateFields();
                tbName.Text = ontology.Name;
                tbDescript.Text = ontology.Description;
                tbSubject.Text = ontology.subjectArea.Name;
                btnAction.Text = "Редактировать";
                btnCancel.Text = "Назад";
                lblInterview.Text = "Здесь Вы можете изменить метаданные об онтологии. " +
                    "Для изменения данных нажмите на кнопку \"Редактировать\".";
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (Mode == 2)
            {
                try
                {
                    ontology.Name = tbName.Text;
                    ontology.Description = tbDescript.Text;
                    MessageBox.Show("Метаданные онтологии успешно отредактированы", @"Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: не правильно введены данные.\nИсточник ошибки: " + ex.Message, @"Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                DeactivateFields();
                Mode = 3;
                btnAction.Text = "Редактировать";
                btnCancel.Text = "Назад";
                lblInterview.Text = "Здесь Вы можете изменить метаданные онтологии. " +
                    "Для изменения данных нажмите на кнопку \"Редактировать\".";
            }
            else if (Mode == 3)
            {
                ActivateFields();
                btnAction.Text = "Сохранить";
                btnCancel.Text = "Отмена";
                Mode = 2;
                lblInterview.Text = "Для сохранения данных нажмите на кнопку \"Сохранить\".";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Mode == 2)
            {
                DeactivateFields();
                Mode = 3;
                btnAction.Text = "Редактировать";
                btnCancel.Text = "Назад";
                lblInterview.Text = "Здесь Вы можете изменить метаданные онтологии. " +
                    "Для изменения данных нажмите на кнопку \"Редактировать\".";
            }
            else if (Mode == 3)
            {
                Close();
            }
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            var subjectArea = new SubjectAreaForm(3, ontology.Id);
            this.Enabled = false;
            subjectArea.Show();
            subjectArea.Closed += SubjectArea_Closed;
        }

        public void DeactivateFields()
        {
            tbName.ReadOnly = true;
            tbDescript.ReadOnly = true;
            tbName.Text = ontology.Name;
            tbDescript.Text = ontology.Description;
        }

        public void ActivateFields()
        {
            tbName.ReadOnly = false;
            tbDescript.ReadOnly = false;
        }

        private void SubjectArea_Closed(object sender, EventArgs e)
        {
            this.Enabled = true;
            tbSubject.Text = ontology.subjectArea.Name;
        }

        private void ButtonEnable()
        {
            if (tbName.Text.Trim() != "")
            {
                btnAction.Enabled = true;
                btnAction.Text = "Сохранить";
            }
            else
            {
                btnAction.Enabled = false;
                btnAction.Text = "Необходимо название онтологии";
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            ButtonEnable();
        }
    }
}
