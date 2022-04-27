using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using OwlDotNetApi;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;

namespace OntologyCreator.Forms
{
    public partial class Welcome : Form
    {
        private OntologyManager om = OntologyManager.getManager();

        public Welcome()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var NextForm = new Metadata();
            SwitchSettings();
            NextForm.Show();
            NextForm.Closed += NextForm_Closed;
        }

        private void btnOpen_Click(object sender, EventArgs e)
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
                        case "OWL":
                            ParseOWL(ofd.FileName);
                            break;
                    }
                    var NextForm = new MainForm(om.GetCurrentOntology().Id);
                    SwitchSettings();
                    NextForm.Show();
                    NextForm.Closed += NextForm_Closed;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Ошибка: не удалось считать файл с диска. Источник ошибки: " + ex.Message, @"Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программное средство для создания многоаспектных онтологий на основе интервьюирования экспертов.\nВыпускная квалификационная работа студента ПИ-17-1 Василюка Василия (4 курс).\n" +
                "Программа предназначена для создания формализации и структуризации любой области знаний посредством создания иерархической онтологии." +
                " Модифицирована для генерации DSL студентом Ермаковым Иваном ПМИ-2019-1 (3 курс)." +
                "\nВсе функции кнопок в главном меню соответсвуют их названиям.\n" +
                "2022, Пермь.", "Справка",
               MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
        }

        private void ParseOWL(string fileName)
        {
            var parser = new OwlXmlParser();
            var graph = parser.ParseOwl(fileName);

            IDictionaryEnumerator nEnumerator = (IDictionaryEnumerator)graph.Nodes.GetEnumerator();
            while (nEnumerator.MoveNext())
            {
                List<OwlNode> notAnonymousNodes = new List<OwlNode>();
                OwlNode node = (OwlNode)graph.Nodes[(nEnumerator.Key).ToString()];
                if (!node.IsAnonymous())
                    notAnonymousNodes.Add(node);
                var a = 1;
            }
        }
    }
}
 