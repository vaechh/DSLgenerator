namespace OntologyCreator.Forms
{
    partial class CommonConceptForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommonConceptForm));
            this.gbCurrentOntology = new System.Windows.Forms.GroupBox();
            this.tvCurrentOntology = new System.Windows.Forms.TreeView();
            this.gbSecondOntology = new System.Windows.Forms.GroupBox();
            this.tvSecondOntology = new System.Windows.Forms.TreeView();
            this.gbSelectMainOntology = new System.Windows.Forms.GroupBox();
            this.rbSecondOntology = new System.Windows.Forms.RadioButton();
            this.rbCurrentOntology = new System.Windows.Forms.RadioButton();
            this.btnCheckChildNames = new System.Windows.Forms.Button();
            this.gbCurrentConcept = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCurrentAttributes = new System.Windows.Forms.DataGridView();
            this.lblCurrentConcept = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbSecondConcept = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvSecondAttributes = new System.Windows.Forms.DataGridView();
            this.lblSecondConcept = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCombine = new System.Windows.Forms.Button();
            this.btnCheckChildAttributes = new System.Windows.Forms.Button();
            this.btnCheckAttributes = new System.Windows.Forms.Button();
            this.pbAttributes = new System.Windows.Forms.PictureBox();
            this.pbChildAttrubites = new System.Windows.Forms.PictureBox();
            this.pbChildNames = new System.Windows.Forms.PictureBox();
            this.PropertyID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropertyName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropertyValue1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropertyID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropertyName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropertyValue2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCurrentOntology.SuspendLayout();
            this.gbSecondOntology.SuspendLayout();
            this.gbSelectMainOntology.SuspendLayout();
            this.gbCurrentConcept.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentAttributes)).BeginInit();
            this.gbSecondConcept.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecondAttributes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAttributes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChildAttrubites)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChildNames)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCurrentOntology
            // 
            this.gbCurrentOntology.Controls.Add(this.tvCurrentOntology);
            this.gbCurrentOntology.Location = new System.Drawing.Point(12, 12);
            this.gbCurrentOntology.Name = "gbCurrentOntology";
            this.gbCurrentOntology.Size = new System.Drawing.Size(228, 426);
            this.gbCurrentOntology.TabIndex = 0;
            this.gbCurrentOntology.TabStop = false;
            this.gbCurrentOntology.Text = "Первая онтология";
            // 
            // tvCurrentOntology
            // 
            this.tvCurrentOntology.Location = new System.Drawing.Point(0, 20);
            this.tvCurrentOntology.Name = "tvCurrentOntology";
            this.tvCurrentOntology.Size = new System.Drawing.Size(228, 406);
            this.tvCurrentOntology.TabIndex = 0;
            this.tvCurrentOntology.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCurrentOntology_AfterSelect);
            // 
            // gbSecondOntology
            // 
            this.gbSecondOntology.Controls.Add(this.tvSecondOntology);
            this.gbSecondOntology.Location = new System.Drawing.Point(246, 12);
            this.gbSecondOntology.Name = "gbSecondOntology";
            this.gbSecondOntology.Size = new System.Drawing.Size(228, 426);
            this.gbSecondOntology.TabIndex = 1;
            this.gbSecondOntology.TabStop = false;
            this.gbSecondOntology.Text = "Вторая онтология";
            // 
            // tvSecondOntology
            // 
            this.tvSecondOntology.Location = new System.Drawing.Point(0, 20);
            this.tvSecondOntology.Name = "tvSecondOntology";
            this.tvSecondOntology.Size = new System.Drawing.Size(228, 406);
            this.tvSecondOntology.TabIndex = 0;
            this.tvSecondOntology.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSecondOntology_AfterSelect);
            // 
            // gbSelectMainOntology
            // 
            this.gbSelectMainOntology.Controls.Add(this.rbSecondOntology);
            this.gbSelectMainOntology.Controls.Add(this.rbCurrentOntology);
            this.gbSelectMainOntology.Location = new System.Drawing.Point(12, 444);
            this.gbSelectMainOntology.Name = "gbSelectMainOntology";
            this.gbSelectMainOntology.Size = new System.Drawing.Size(462, 43);
            this.gbSelectMainOntology.TabIndex = 2;
            this.gbSelectMainOntology.TabStop = false;
            this.gbSelectMainOntology.Text = "Выбор главной онтологии";
            // 
            // rbSecondOntology
            // 
            this.rbSecondOntology.AutoSize = true;
            this.rbSecondOntology.Location = new System.Drawing.Point(234, 19);
            this.rbSecondOntology.Name = "rbSecondOntology";
            this.rbSecondOntology.Size = new System.Drawing.Size(116, 17);
            this.rbSecondOntology.TabIndex = 1;
            this.rbSecondOntology.Text = "Вторая онтология";
            this.rbSecondOntology.UseVisualStyleBackColor = true;
            // 
            // rbCurrentOntology
            // 
            this.rbCurrentOntology.AutoSize = true;
            this.rbCurrentOntology.Checked = true;
            this.rbCurrentOntology.Location = new System.Drawing.Point(6, 19);
            this.rbCurrentOntology.Name = "rbCurrentOntology";
            this.rbCurrentOntology.Size = new System.Drawing.Size(118, 17);
            this.rbCurrentOntology.TabIndex = 0;
            this.rbCurrentOntology.TabStop = true;
            this.rbCurrentOntology.Text = "Первая онтология";
            this.rbCurrentOntology.UseVisualStyleBackColor = true;
            // 
            // btnCheckChildNames
            // 
            this.btnCheckChildNames.Enabled = false;
            this.btnCheckChildNames.Location = new System.Drawing.Point(480, 386);
            this.btnCheckChildNames.Name = "btnCheckChildNames";
            this.btnCheckChildNames.Size = new System.Drawing.Size(280, 23);
            this.btnCheckChildNames.TabIndex = 3;
            this.btnCheckChildNames.Text = "Сравнить дочерние концепты по названию";
            this.btnCheckChildNames.UseVisualStyleBackColor = true;
            this.btnCheckChildNames.Click += new System.EventHandler(this.btnCheckChildNames_Click);
            // 
            // gbCurrentConcept
            // 
            this.gbCurrentConcept.Controls.Add(this.label3);
            this.gbCurrentConcept.Controls.Add(this.label2);
            this.gbCurrentConcept.Controls.Add(this.dgvCurrentAttributes);
            this.gbCurrentConcept.Controls.Add(this.lblCurrentConcept);
            this.gbCurrentConcept.Controls.Add(this.label1);
            this.gbCurrentConcept.Location = new System.Drawing.Point(480, 12);
            this.gbCurrentConcept.Name = "gbCurrentConcept";
            this.gbCurrentConcept.Size = new System.Drawing.Size(314, 164);
            this.gbCurrentConcept.TabIndex = 4;
            this.gbCurrentConcept.TabStop = false;
            this.gbCurrentConcept.Text = "Концепт первой онтологии";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(7, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Свойства:";
            // 
            // dgvCurrentAttributes
            // 
            this.dgvCurrentAttributes.AllowUserToAddRows = false;
            this.dgvCurrentAttributes.AllowUserToDeleteRows = false;
            this.dgvCurrentAttributes.AllowUserToResizeColumns = false;
            this.dgvCurrentAttributes.AllowUserToResizeRows = false;
            this.dgvCurrentAttributes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCurrentAttributes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCurrentAttributes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCurrentAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCurrentAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PropertyID1,
            this.PropertyName1,
            this.PropertyValue1});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCurrentAttributes.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCurrentAttributes.EnableHeadersVisualStyles = false;
            this.dgvCurrentAttributes.Location = new System.Drawing.Point(6, 53);
            this.dgvCurrentAttributes.MultiSelect = false;
            this.dgvCurrentAttributes.Name = "dgvCurrentAttributes";
            this.dgvCurrentAttributes.ReadOnly = true;
            this.dgvCurrentAttributes.RowHeadersVisible = false;
            this.dgvCurrentAttributes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCurrentAttributes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCurrentAttributes.Size = new System.Drawing.Size(301, 105);
            this.dgvCurrentAttributes.TabIndex = 8;
            // 
            // lblCurrentConcept
            // 
            this.lblCurrentConcept.AutoSize = true;
            this.lblCurrentConcept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrentConcept.Location = new System.Drawing.Point(73, 20);
            this.lblCurrentConcept.Name = "lblCurrentConcept";
            this.lblCurrentConcept.Size = new System.Drawing.Size(122, 13);
            this.lblCurrentConcept.TabIndex = 1;
            this.lblCurrentConcept.Text = "Концепт не выбран";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название:";
            // 
            // gbSecondConcept
            // 
            this.gbSecondConcept.Controls.Add(this.label4);
            this.gbSecondConcept.Controls.Add(this.label5);
            this.gbSecondConcept.Controls.Add(this.dgvSecondAttributes);
            this.gbSecondConcept.Controls.Add(this.lblSecondConcept);
            this.gbSecondConcept.Controls.Add(this.label7);
            this.gbSecondConcept.Location = new System.Drawing.Point(480, 186);
            this.gbSecondConcept.Name = "gbSecondConcept";
            this.gbSecondConcept.Size = new System.Drawing.Size(314, 164);
            this.gbSecondConcept.TabIndex = 5;
            this.gbSecondConcept.TabStop = false;
            this.gbSecondConcept.Text = "Концепт второй онтологии";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(7, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Свойства:";
            // 
            // dgvSecondAttributes
            // 
            this.dgvSecondAttributes.AllowUserToAddRows = false;
            this.dgvSecondAttributes.AllowUserToDeleteRows = false;
            this.dgvSecondAttributes.AllowUserToResizeColumns = false;
            this.dgvSecondAttributes.AllowUserToResizeRows = false;
            this.dgvSecondAttributes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSecondAttributes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSecondAttributes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSecondAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSecondAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PropertyID2,
            this.PropertyName2,
            this.PropertyValue2});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSecondAttributes.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSecondAttributes.EnableHeadersVisualStyles = false;
            this.dgvSecondAttributes.Location = new System.Drawing.Point(6, 53);
            this.dgvSecondAttributes.MultiSelect = false;
            this.dgvSecondAttributes.Name = "dgvSecondAttributes";
            this.dgvSecondAttributes.ReadOnly = true;
            this.dgvSecondAttributes.RowHeadersVisible = false;
            this.dgvSecondAttributes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSecondAttributes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSecondAttributes.Size = new System.Drawing.Size(301, 105);
            this.dgvSecondAttributes.TabIndex = 8;
            // 
            // lblSecondConcept
            // 
            this.lblSecondConcept.AutoSize = true;
            this.lblSecondConcept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSecondConcept.Location = new System.Drawing.Point(73, 20);
            this.lblSecondConcept.Name = "lblSecondConcept";
            this.lblSecondConcept.Size = new System.Drawing.Size(122, 13);
            this.lblSecondConcept.TabIndex = 1;
            this.lblSecondConcept.Text = "Концепт не выбран";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(7, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Название:";
            // 
            // btnCombine
            // 
            this.btnCombine.Enabled = false;
            this.btnCombine.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCombine.Location = new System.Drawing.Point(480, 444);
            this.btnCombine.Name = "btnCombine";
            this.btnCombine.Size = new System.Drawing.Size(307, 43);
            this.btnCombine.TabIndex = 6;
            this.btnCombine.Text = "Объединить";
            this.btnCombine.UseVisualStyleBackColor = true;
            this.btnCombine.Click += new System.EventHandler(this.btnCombine_Click);
            // 
            // btnCheckChildAttributes
            // 
            this.btnCheckChildAttributes.Enabled = false;
            this.btnCheckChildAttributes.Location = new System.Drawing.Point(480, 415);
            this.btnCheckChildAttributes.Name = "btnCheckChildAttributes";
            this.btnCheckChildAttributes.Size = new System.Drawing.Size(280, 23);
            this.btnCheckChildAttributes.TabIndex = 8;
            this.btnCheckChildAttributes.Text = "Сравнить дочерние концепты по свойствам";
            this.btnCheckChildAttributes.UseVisualStyleBackColor = true;
            this.btnCheckChildAttributes.Click += new System.EventHandler(this.btnCheckChildAttributes_Click);
            // 
            // btnCheckAttributes
            // 
            this.btnCheckAttributes.Enabled = false;
            this.btnCheckAttributes.Location = new System.Drawing.Point(480, 357);
            this.btnCheckAttributes.Name = "btnCheckAttributes";
            this.btnCheckAttributes.Size = new System.Drawing.Size(280, 23);
            this.btnCheckAttributes.TabIndex = 10;
            this.btnCheckAttributes.Text = "Сравнить по свойствам";
            this.btnCheckAttributes.UseVisualStyleBackColor = true;
            this.btnCheckAttributes.Click += new System.EventHandler(this.btnCheckAttributes_Click);
            // 
            // pbAttributes
            // 
            this.pbAttributes.Location = new System.Drawing.Point(766, 357);
            this.pbAttributes.Name = "pbAttributes";
            this.pbAttributes.Size = new System.Drawing.Size(21, 23);
            this.pbAttributes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbAttributes.TabIndex = 11;
            this.pbAttributes.TabStop = false;
            // 
            // pbChildAttrubites
            // 
            this.pbChildAttrubites.Location = new System.Drawing.Point(766, 415);
            this.pbChildAttrubites.Name = "pbChildAttrubites";
            this.pbChildAttrubites.Size = new System.Drawing.Size(21, 23);
            this.pbChildAttrubites.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbChildAttrubites.TabIndex = 9;
            this.pbChildAttrubites.TabStop = false;
            // 
            // pbChildNames
            // 
            this.pbChildNames.Location = new System.Drawing.Point(766, 386);
            this.pbChildNames.Name = "pbChildNames";
            this.pbChildNames.Size = new System.Drawing.Size(21, 23);
            this.pbChildNames.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbChildNames.TabIndex = 7;
            this.pbChildNames.TabStop = false;
            // 
            // PropertyID1
            // 
            this.PropertyID1.Frozen = true;
            this.PropertyID1.HeaderText = "ID";
            this.PropertyID1.Name = "PropertyID1";
            this.PropertyID1.ReadOnly = true;
            this.PropertyID1.Visible = false;
            // 
            // PropertyName1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PropertyName1.DefaultCellStyle = dataGridViewCellStyle2;
            this.PropertyName1.Frozen = true;
            this.PropertyName1.HeaderText = "Название";
            this.PropertyName1.Name = "PropertyName1";
            this.PropertyName1.ReadOnly = true;
            this.PropertyName1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PropertyName1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PropertyName1.Width = 150;
            // 
            // PropertyValue1
            // 
            this.PropertyValue1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.PropertyValue1.DefaultCellStyle = dataGridViewCellStyle3;
            this.PropertyValue1.Frozen = true;
            this.PropertyValue1.HeaderText = "Значение";
            this.PropertyValue1.Name = "PropertyValue1";
            this.PropertyValue1.ReadOnly = true;
            this.PropertyValue1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PropertyValue1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PropertyValue1.Width = 150;
            // 
            // PropertyID2
            // 
            this.PropertyID2.Frozen = true;
            this.PropertyID2.HeaderText = "ID";
            this.PropertyID2.Name = "PropertyID2";
            this.PropertyID2.ReadOnly = true;
            this.PropertyID2.Visible = false;
            // 
            // PropertyName2
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PropertyName2.DefaultCellStyle = dataGridViewCellStyle6;
            this.PropertyName2.Frozen = true;
            this.PropertyName2.HeaderText = "Название";
            this.PropertyName2.Name = "PropertyName2";
            this.PropertyName2.ReadOnly = true;
            this.PropertyName2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PropertyName2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PropertyName2.Width = 150;
            // 
            // PropertyValue2
            // 
            this.PropertyValue2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            this.PropertyValue2.DefaultCellStyle = dataGridViewCellStyle7;
            this.PropertyValue2.Frozen = true;
            this.PropertyValue2.HeaderText = "Значение";
            this.PropertyValue2.Name = "PropertyValue2";
            this.PropertyValue2.ReadOnly = true;
            this.PropertyValue2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PropertyValue2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PropertyValue2.Width = 150;
            // 
            // CommonConceptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 499);
            this.Controls.Add(this.pbAttributes);
            this.Controls.Add(this.btnCheckAttributes);
            this.Controls.Add(this.pbChildAttrubites);
            this.Controls.Add(this.btnCheckChildAttributes);
            this.Controls.Add(this.pbChildNames);
            this.Controls.Add(this.btnCombine);
            this.Controls.Add(this.gbSecondConcept);
            this.Controls.Add(this.gbCurrentConcept);
            this.Controls.Add(this.btnCheckChildNames);
            this.Controls.Add(this.gbSelectMainOntology);
            this.Controls.Add(this.gbSecondOntology);
            this.Controls.Add(this.gbCurrentOntology);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CommonConceptForm";
            this.Text = "Объединение онтологий на основе общего концепта";
            this.gbCurrentOntology.ResumeLayout(false);
            this.gbSecondOntology.ResumeLayout(false);
            this.gbSelectMainOntology.ResumeLayout(false);
            this.gbSelectMainOntology.PerformLayout();
            this.gbCurrentConcept.ResumeLayout(false);
            this.gbCurrentConcept.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentAttributes)).EndInit();
            this.gbSecondConcept.ResumeLayout(false);
            this.gbSecondConcept.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecondAttributes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAttributes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChildAttrubites)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChildNames)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCurrentOntology;
        private System.Windows.Forms.TreeView tvCurrentOntology;
        private System.Windows.Forms.GroupBox gbSecondOntology;
        private System.Windows.Forms.TreeView tvSecondOntology;
        private System.Windows.Forms.GroupBox gbSelectMainOntology;
        private System.Windows.Forms.RadioButton rbSecondOntology;
        private System.Windows.Forms.RadioButton rbCurrentOntology;
        private System.Windows.Forms.Button btnCheckChildNames;
        private System.Windows.Forms.GroupBox gbCurrentConcept;
        private System.Windows.Forms.Label lblCurrentConcept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCurrentAttributes;
        private System.Windows.Forms.GroupBox gbSecondConcept;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvSecondAttributes;
        private System.Windows.Forms.Label lblSecondConcept;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCombine;
        private System.Windows.Forms.PictureBox pbChildNames;
        private System.Windows.Forms.Button btnCheckChildAttributes;
        private System.Windows.Forms.PictureBox pbChildAttrubites;
        private System.Windows.Forms.Button btnCheckAttributes;
        private System.Windows.Forms.PictureBox pbAttributes;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyValue1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyValue2;
    }
}