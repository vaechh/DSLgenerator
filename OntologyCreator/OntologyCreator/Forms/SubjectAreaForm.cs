using System;
using System.Windows.Forms;
using OntologyCreator.Forms;

namespace OntologyCreator
{
    public partial class SubjectAreaForm : Form
    {
        private bool ExitCheck;
        private int Mode; // 1 - создание, 2 - активное редактирование, 3 - возможность редактирования
        private OntologyManager om = OntologyManager.getManager();
        private Ontology ontology;

        public SubjectAreaForm(int mode, int ontologyId)
        {
            InitializeComponent();
            ExitCheck = false;
            Mode = mode;
            ontology = om.GetById(ontologyId);
            if (Mode == 1)
            {
                ButtonEnable();
                lblInterview.Text = "На данном этапе нужно заполнить данные о предметной области. " +
                    "Для полноты сведений лучше ответить на все вопросы. Вопрос со звёздочкой - обязательный.";
            }
            else if (Mode == 3)
            {
                DeactivateFields();
                tbName.Text = ontology.subjectArea.Name;
                tbGoal.Text = ontology.subjectArea.Goals;
                tbUser.Text = ontology.subjectArea.User;
                btnNext.Text = "Редактировать";
                lblInterview.Text = "Здесь Вы можете изменить данные о предметной области. " +
                    "Для изменения данных нажмите на кнопку \"Редактировать\".";
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Mode == 1)
            {
                try
                {
                    SubjectArea subject = new SubjectArea(tbName.Text, tbGoal.Text, tbUser.Text);
                    ontology.subjectArea = subject;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: не правильно введены данные.\nИсточник ошибки: " + ex.Message, @"Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                var NextForm = new MainForm(ontology.Id);
                Hide();
                NextForm.Show();
                NextForm.Closed += MainForm_Closed;
            }
            else if (Mode == 2)
            {
                try
                {
                    SubjectArea subject = new SubjectArea(tbName.Text, tbGoal.Text, tbUser.Text);
                    ontology.subjectArea = subject;
                    MessageBox.Show("Данные о предметной области успешно отредактированы", @"Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: не правильно введены данные.\nИсточник ошибки: " + ex.Message, @"Ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                DeactivateFields();
                Mode = 3;
                btnNext.Text = "Редактировать";
                btnBack.Text = "Назад";
                lblInterview.Text = "Здесь Вы можете изменить данные о предметной области. " +
                    "Для изменения данных нажмите на кнопку \"Редактировать\".";
            }
            else if (Mode == 3)
            {
                ActivateFields();
                btnNext.Text = "Сохранить";
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
                btnNext.Text = "Редактировать";
                btnBack.Text = "Назад";
                lblInterview.Text = "Здесь Вы можете изменить данные о предметной области. " +
                    "Для изменения данных нажмите на кнопку \"Редактировать\".";
            }
            else
            {
                ExitCheck = true;
                if (Mode == 1)
                {
                    if ((tbName.Text.Trim() == "") && (tbGoal.Text.Trim() == "") && (tbUser.Text.Trim() == ""))
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
            if (tbName.Text.Trim() != "")
            {
                btnNext.Enabled = true;
                btnNext.Text = Mode == 1 ? "Далее" : "Сохранить";
            }
            else
            {
                btnNext.Enabled = false;
                btnNext.Text = "Необходимо название предметной области";
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            ButtonEnable();
        }

        private void SubjectArea_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ExitCheck)
            {
                if (Mode == 1)
                {
                    if ((tbName.Text.Trim() == "") && (tbGoal.Text.Trim() == "") && (tbUser.Text.Trim() == ""))
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

        public void DeactivateFields()
        {
            foreach (Control tb in Controls)
                if (tb is TextBox)
                    ((TextBox)tb).ReadOnly = true;
            var onto = om.GetCurrentOntology();
            tbName.Text = onto.subjectArea.Name;
            tbGoal.Text = onto.subjectArea.Goals;
            tbUser.Text = onto.subjectArea.User;
        }

        public void ActivateFields()
        {
            foreach (Control tb in Controls)
                if (tb is TextBox)
                    ((TextBox)tb).ReadOnly = false;
        }

        private void MainForm_Closed(object sender, EventArgs e)
        {
            ExitCheck = true;
            Close();
        }
    }
}
