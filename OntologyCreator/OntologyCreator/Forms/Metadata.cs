using System;
using System.Windows.Forms;

namespace OntologyCreator
{
    public partial class Metadata : Form
    {
        private bool ExitCheck;
        private OntologyManager om = OntologyManager.getManager();

        public Metadata()
        {
            InitializeComponent();
            ButtonEnable();
            ExitCheck = false;
            lblInterview.Text = "Для начала необходмо ввести метаданные онтологии, то есть её название и краткое описание " +
                "(чтобы потом было легче понять, что представляет данная онтология)";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                om.Add(new Ontology(tbOntName.Text, tbOntDescript.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: не правильно введены данные.\nИсточник ошибки: " + ex.Message, @"Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            var NextForm = new SubjectAreaForm(1, om.GetCurrentOntology().Id);
            SwitchSettings();
            NextForm.Show();
            NextForm.Closed += NextForm_Closed;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ExitCheck = true;
            if ((tbOntName.Text.Trim() == "") && (tbOntDescript.Text.Trim() == ""))
                Close();
            else
            {
                DialogResult result = MessageBox.Show("При возврате в главное меню все введённые данные будут утеряны\n" +
                    "Вы уверены, что хотите вернутся в главное меню?", @"Предупреждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                    Close();
            }
            ExitCheck = false;
        }

        private void ButtonEnable()
        {
            if (tbOntName.Text.Trim() != "")
            {
                btnNext.Enabled = true;
                btnNext.Text = "Далее";
            }
            else
            {
                btnNext.Enabled = false;
                btnNext.Text = "Введите хотя бы название онтологии";
            }
        }

        private void Metadata_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ExitCheck)
            {
                if ((tbOntName.Text.Trim() == "") && (tbOntDescript.Text.Trim() == ""))
                    e.Cancel = false;
                else
                {
                    DialogResult result = MessageBox.Show("При возврате в главное меню введённые данные будут утрачены\n" +
                        "Вы уверены, что хотите вернутся в главное меню?", @"Предупреждение",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                        e.Cancel = false;
                    else
                        e.Cancel = true;
                }
            }
            else
                e.Cancel = false;
        }

        private void tbOntoName_TextChanged(object sender, EventArgs e)
        {
            ButtonEnable();
        }

        private void SwitchSettings()
        {
            if (Visible)
                Hide();
            else
                Show();
        }

        private void NextForm_Closed(object sender, EventArgs e)
        {
            SwitchSettings();
            if (om.GetCurrentOntology().Name == "")
            {
                OntologyManager.Clear();
                tbOntName.Text = "";
                tbOntDescript.Text = "";
            }
            else
            {
                ExitCheck = true;
                Close();
            }
        }
    }
}
