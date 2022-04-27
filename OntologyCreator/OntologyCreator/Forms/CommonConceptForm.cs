using OntologyCreator.Concepts;
using OntologyCreator.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OntologyCreator.Forms
{
    public partial class CommonConceptForm : Form
    {
        private OntologyManager om = OntologyManager.getManager();
        private Ontology CurrentOntology;
        private Ontology SecondOntology;
        private Ontology ResultOntology;
        Concept currentConcept;
        Concept secondConcept;

        public CommonConceptForm(Ontology currentOntology, Ontology secondOntology, Ontology resultOntology)
        {
            InitializeComponent();
            CurrentOntology = currentOntology;
            SecondOntology = secondOntology;
            ResultOntology = resultOntology;
            gbCurrentOntology.Text = CurrentOntology.Name;
            gbSecondOntology.Text = SecondOntology.Name;
            CreateTree(tvCurrentOntology, CurrentOntology.Concepts);
            CreateTree(tvSecondOntology, SecondOntology.Concepts);
            rbCurrentOntology.Text = CurrentOntology.Name;
            rbSecondOntology.Text = SecondOntology.Name;
            gbCurrentConcept.Text = $"Концепт онтологии \"{CurrentOntology.Name}\"";
            gbSecondConcept.Text = $"Концепт онтологии \"{SecondOntology.Name}\"";
        }

        #region Utils
        private void CreateTree(TreeView treeView, List<Concept> concepts, TreeNode parent = null)
        {
            if ((concepts != null) && (concepts.Count > 0))
            {
                if (parent == null)
                    foreach (var c in concepts)
                    {
                        TreeNode treeNode = new TreeNode(c.Name);
                        treeNode.Name = c.Name;
                        treeView.Nodes.Add(treeNode);
                        CreateTree(treeView, c.Child, treeNode);
                    }
                else
                    foreach (var c in concepts)
                    {
                        TreeNode treeNode = new TreeNode(c.Name);
                        treeNode.Name = c.Name;
                        parent.Nodes.Add(treeNode);
                        CreateTree(treeView, c.Child, treeNode);
                    }
            }
            treeView.ExpandAll();
        }

        private void tvCurrentOntology_AfterSelect(object sender, TreeViewEventArgs e)
        {
            currentConcept = Utils.FindConceptByName(tvCurrentOntology.SelectedNode.Text, CurrentOntology.Concepts);
            FillCurrentConceptWindow();
            CheckConceptsSelected();
            ClearCheckingResults();
        }

        private void tvSecondOntology_AfterSelect(object sender, TreeViewEventArgs e)
        {
            secondConcept = Utils.FindConceptByName(tvSecondOntology.SelectedNode.Text, SecondOntology.Concepts);
            FillSecondConceptWindow();
            CheckConceptsSelected();
            ClearCheckingResults();
        }

        private void CheckConceptsSelected()
        {
            if (currentConcept != null && secondConcept != null)
                ButtonsEnable(true);
        }

        private void ButtonsEnable(bool enabled)
        {
            btnCheckAttributes.Enabled = enabled;
            btnCheckChildAttributes.Enabled = enabled;
            btnCheckChildNames.Enabled = enabled;
            btnCombine.Enabled = enabled;
        }

        private void ClearCheckingResults()
        {
            pbAttributes.Image = null;
            pbChildAttrubites.Image = null;
            pbChildNames.Image = null;
        }

        private void RefreshTrees()
        {
            tvCurrentOntology.Nodes.Clear();
            CreateTree(tvCurrentOntology, CurrentOntology.Concepts);
            tvSecondOntology.Nodes.Clear();
            CreateTree(tvSecondOntology, SecondOntology.Concepts);
        }
        #endregion


        private void FillCurrentConceptWindow()
        {
            lblCurrentConcept.Text = currentConcept.Name;
            dgvCurrentAttributes.Rows.Clear();
            foreach (var p in currentConcept.Properties)
            {
                int rowNumber = dgvCurrentAttributes.Rows.Add();
                dgvCurrentAttributes.Rows[rowNumber].Cells["PropertyID1"].Value = p.ID;
                dgvCurrentAttributes.Rows[rowNumber].Cells["PropertyName1"].Value = p.Name;
                dgvCurrentAttributes.Rows[rowNumber].Cells["PropertyValue1"].Value = p.Value;
            }
            dgvCurrentAttributes.ClearSelection();
        }

        private void FillSecondConceptWindow()
        {
            lblSecondConcept.Text = secondConcept.Name;
            dgvSecondAttributes.Rows.Clear();
            foreach (var p in secondConcept.Properties)
            {
                int rowNumber = dgvSecondAttributes.Rows.Add();
                dgvSecondAttributes.Rows[rowNumber].Cells["PropertyID2"].Value = p.ID;
                dgvSecondAttributes.Rows[rowNumber].Cells["PropertyName2"].Value = p.Name;
                dgvSecondAttributes.Rows[rowNumber].Cells["PropertyValue2"].Value = p.Value;
            }
            dgvSecondAttributes.ClearSelection();
        }

        #region Buttons

        private void btnCheckAttributes_Click(object sender, EventArgs e)
        {
            var success = false;
            RefreshTrees();
            if (currentConcept.Properties.Count != secondConcept.Properties.Count)
            {
                MessageBox.Show($"Концепты {currentConcept.Name} и {secondConcept.Name} имеют разное количество свойств", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                success = Utils.CompareProperties(currentConcept.Properties, secondConcept.Properties);
                if (success)
                    MessageBox.Show($"Концепты {currentConcept.Name} и {secondConcept.Name} имеют идентичный набор свойств", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Концепты {currentConcept.Name} и {secondConcept.Name} имеют различия в свойствах", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            pbAttributes.Image = success ? new Bitmap(Properties.Resources.check) : new Bitmap(Properties.Resources.close);
        }

        private void btnCheckChildNames_Click(object sender, EventArgs e)
        {
            var success = false;
            RefreshTrees();
            if (Utils.CountConcept(currentConcept.Child) != Utils.CountConcept(secondConcept.Child))
            {
                MessageBox.Show($"Концепты {currentConcept.Name} и {secondConcept.Name} имеют разное количество дочерних концептов", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var result = rbCurrentOntology.Checked ? Utils.CompareConceptNameLists(secondConcept.Child, currentConcept.Child) :
                            Utils.CompareConceptNameLists(currentConcept.Child, secondConcept.Child);
                var tv = rbCurrentOntology.Checked ? tvSecondOntology : tvCurrentOntology;
                var currentName = rbCurrentOntology.Checked ? secondConcept.Name : currentConcept.Name;
                var tnc = tv.Nodes.Find(currentName, true).First().Nodes;
                foreach (var c in result)
                {
                    var tn = tnc.Find(c.Name, true);
                    if (tn.Count() != 0)
                        tn.First().BackColor = c.color;
                }
                success = result.Count == 0;
                if (success)
                    MessageBox.Show($"Имена дочерних концептов у {currentConcept.Name} и {secondConcept.Name} идентичны", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Концепты {currentConcept.Name} и {secondConcept.Name} имеют различия в именах дочерних концептов", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            pbChildNames.Image = success ? new Bitmap(Properties.Resources.check) : new Bitmap(Properties.Resources.close);
        }

        private void btnCheckChildAttributes_Click(object sender, EventArgs e)
        {
            var success = false;
            RefreshTrees();
            if (Utils.CountConcept(currentConcept.Child) != Utils.CountConcept(secondConcept.Child))
            {
                MessageBox.Show($"Концепты {currentConcept.Name} и {secondConcept.Name} имеют разное количество дочерних концептов", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var result = rbCurrentOntology.Checked ? Utils.CompareConceptPropertyLists(secondConcept.Child, currentConcept.Child) :
                            Utils.CompareConceptPropertyLists(currentConcept.Child, secondConcept.Child);
                var tv = rbCurrentOntology.Checked ? tvSecondOntology : tvCurrentOntology;
                var currentName = rbCurrentOntology.Checked ? secondConcept.Name : currentConcept.Name;
                var tnc = tv.Nodes.Find(currentName, true).First().Nodes;
                foreach (var c in result)
                {               
                    var tn = tnc.Find(c.Name, true);
                    if (tn.Count() != 0)
                        tn.First().BackColor = c.color;
                }
                success = result.Count == 0;
                if (success)
                    MessageBox.Show($"Свойства дочерних концептов у {currentConcept.Name} и {secondConcept.Name} идентичны", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Концепты {currentConcept.Name} и {secondConcept.Name} имеют различия в свойствах дочерних концептов", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            pbChildAttrubites.Image = success ? new Bitmap(Properties.Resources.check) : new Bitmap(Properties.Resources.close);
        }

        private void btnCombine_Click(object sender, EventArgs e)
        {
            if (rbCurrentOntology.Checked)
            {
                foreach (var concept in CurrentOntology.Concepts)
                {
                    ResultOntology.Concepts.Add((Concept)concept.Clone(ResultOntology.Id, Utils.GetConceptIdFromOntology(ResultOntology.Id)));
                }
                foreach (var relation in CurrentOntology.Relations)
                {
                    var mainConcept = Utils.FindConceptByName(relation.MainConcept.Name, ResultOntology.Concepts);
                    var secondaryConcept = Utils.FindConceptByName(relation.SecondaryConcept.Name, ResultOntology.Concepts);
                    ResultOntology.Relations.Add((Relation)relation.Clone(ResultOntology.Id, mainConcept, secondaryConcept));
                }
                var resultConcept = Utils.FindConceptByName(currentConcept.Name, ResultOntology.Concepts);
                foreach (var c in secondConcept.Child)
                {
                    resultConcept.Child.Add((Concept)c.Clone(ResultOntology.Id, Utils.GetConceptIdFromOntology(ResultOntology.Id)));
                    Utils.CreateFamilyRelationsDown(resultConcept, resultConcept.Child.Last(), ResultOntology.Id);
                }
            }
            else
            {
                foreach (var concept in SecondOntology.Concepts)
                {
                    ResultOntology.Concepts.Add((Concept)concept.Clone(ResultOntology.Id, Utils.GetConceptIdFromOntology(ResultOntology.Id)));
                }
                foreach (var relation in SecondOntology.Relations)
                {
                    var mainConcept = Utils.FindConceptByName(relation.MainConcept.Name, ResultOntology.Concepts);
                    var secondaryConcept = Utils.FindConceptByName(relation.SecondaryConcept.Name, ResultOntology.Concepts);
                    ResultOntology.Relations.Add((Relation)relation.Clone(ResultOntology.Id, mainConcept, secondaryConcept));
                }
                var resultConcept = Utils.FindConceptByName(secondConcept.Name, ResultOntology.Concepts);
                foreach (var c in currentConcept.Child)
                {
                    resultConcept.Child.Add((Concept)c.Clone(ResultOntology.Id, Utils.GetConceptIdFromOntology(ResultOntology.Id)));
                    Utils.CreateFamilyRelationsDown(resultConcept, resultConcept.Child.Last(), ResultOntology.Id);
                }
            }
            Close();
        }

        #endregion
    }
}
