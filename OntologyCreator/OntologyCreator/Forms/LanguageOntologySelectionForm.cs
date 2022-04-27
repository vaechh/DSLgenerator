using System;
using System.Windows.Forms;

namespace OntologyCreator.Forms
{
    public partial class LanguageOntologySelectionForm : Form
    {
        public string resultPath;
        public LanguageOntologySelectionForm()
        {
            InitializeComponent();
        }

        private void btnMethood_Click(object sender, EventArgs e)
        {
            resultPath = "E:\\!учеба\\DSM\\Generator DSL\\Ontologies\\БезСуперНаследования.xml";
            this.Close();
        }

        private void btnMission_Click(object sender, EventArgs e)
        {
            resultPath = "E:\\!учеба\\DSM\\Generator DSL\\Ontologies\\Классификация языков моделирования по задачам.xml";
            this.Close();
        }
    }
}
