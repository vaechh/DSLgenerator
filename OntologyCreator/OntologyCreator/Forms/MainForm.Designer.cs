namespace OntologyCreator.Forms
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.msFile = new System.Windows.Forms.ToolStripMenuItem();
            this.msFileCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.msFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.msExistingOntologies = new System.Windows.Forms.ToolStripMenuItem();
            this.объединитьОнтологииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msSaveOWL = new System.Windows.Forms.ToolStripMenuItem();
            this.msSaveXML = new System.Windows.Forms.ToolStripMenuItem();
            this.msInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.msSavePicture = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuDSL = new System.Windows.Forms.ToolStripMenuItem();
            this.gbOntologyTree = new System.Windows.Forms.GroupBox();
            this.tvOntology = new System.Windows.Forms.TreeView();
            this.tcClass = new System.Windows.Forms.TabControl();
            this.tpData = new System.Windows.Forms.TabPage();
            this.btnAddRelation = new System.Windows.Forms.Button();
            this.btnAddAttribute = new System.Windows.Forms.Button();
            this.gbRelations = new System.Windows.Forms.GroupBox();
            this.dgvRelations = new System.Windows.Forms.DataGridView();
            this.RelationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelationWith = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelRelation = new System.Windows.Forms.Button();
            this.btnEditRelation = new System.Windows.Forms.Button();
            this.gbAttributes = new System.Windows.Forms.GroupBox();
            this.dgvAttributes = new System.Windows.Forms.DataGridView();
            this.PropertyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropertyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelAttribute = new System.Windows.Forms.Button();
            this.btnEditAttribute = new System.Windows.Forms.Button();
            this.tpShow = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbOntology = new System.Windows.Forms.PictureBox();
            this.btnEditClass = new System.Windows.Forms.Button();
            this.btnDelClass = new System.Windows.Forms.Button();
            this.btnAddSubclass = new System.Windows.Forms.Button();
            this.btnAddClass = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.gbOntologyTree.SuspendLayout();
            this.tcClass.SuspendLayout();
            this.tpData.SuspendLayout();
            this.gbRelations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelations)).BeginInit();
            this.gbAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).BeginInit();
            this.tpShow.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOntology)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msFile,
            this.msSaveOWL,
            this.msSaveXML,
            this.msInfo,
            this.msSavePicture,
            this.toolStripMenuDSL});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(787, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // msFile
            // 
            this.msFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msFileCreate,
            this.msFileOpen,
            this.msExistingOntologies,
            this.объединитьОнтологииToolStripMenuItem});
            this.msFile.Name = "msFile";
            this.msFile.Size = new System.Drawing.Size(79, 20);
            this.msFile.Text = "Онтология";
            // 
            // msFileCreate
            // 
            this.msFileCreate.Name = "msFileCreate";
            this.msFileCreate.Size = new System.Drawing.Size(203, 22);
            this.msFileCreate.Text = "Создать новую";
            this.msFileCreate.Click += new System.EventHandler(this.msFileCreate_Click);
            // 
            // msFileOpen
            // 
            this.msFileOpen.Name = "msFileOpen";
            this.msFileOpen.Size = new System.Drawing.Size(203, 22);
            this.msFileOpen.Text = "Открыть";
            this.msFileOpen.Click += new System.EventHandler(this.msFileOpen_Click);
            // 
            // msExistingOntologies
            // 
            this.msExistingOntologies.Name = "msExistingOntologies";
            this.msExistingOntologies.Size = new System.Drawing.Size(203, 22);
            this.msExistingOntologies.Text = "Открытые онтологии";
            this.msExistingOntologies.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.msExistingOntologies_DropDownItemClicked);
            // 
            // объединитьОнтологииToolStripMenuItem
            // 
            this.объединитьОнтологииToolStripMenuItem.Name = "объединитьОнтологииToolStripMenuItem";
            this.объединитьОнтологииToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.объединитьОнтологииToolStripMenuItem.Text = "Объединить онтологии";
            this.объединитьОнтологииToolStripMenuItem.Click += new System.EventHandler(this.combineOntologiesToolStripMenuItem_Click);
            // 
            // msSaveOWL
            // 
            this.msSaveOWL.Name = "msSaveOWL";
            this.msSaveOWL.Size = new System.Drawing.Size(107, 20);
            this.msSaveOWL.Text = "Сохранить OWL";
            this.msSaveOWL.Click += new System.EventHandler(this.msFileSaveOWL_Click);
            // 
            // msSaveXML
            // 
            this.msSaveXML.Name = "msSaveXML";
            this.msSaveXML.Size = new System.Drawing.Size(105, 20);
            this.msSaveXML.Text = "Сохранить XML";
            this.msSaveXML.Click += new System.EventHandler(this.msSaveXML_Click);
            // 
            // msInfo
            // 
            this.msInfo.Name = "msInfo";
            this.msInfo.Size = new System.Drawing.Size(172, 20);
            this.msInfo.Text = "Информация об онтологии";
            this.msInfo.Click += new System.EventHandler(this.msInfo_Click);
            // 
            // msSavePicture
            // 
            this.msSavePicture.Enabled = false;
            this.msSavePicture.Name = "msSavePicture";
            this.msSavePicture.Size = new System.Drawing.Size(155, 20);
            this.msSavePicture.Text = "Сохранить изображение";
            this.msSavePicture.Click += new System.EventHandler(this.msSavePicture_Click);
            // 
            // toolStripMenuDSL
            // 
            this.toolStripMenuDSL.Name = "toolStripMenuDSL";
            this.toolStripMenuDSL.Size = new System.Drawing.Size(98, 20);
            this.toolStripMenuDSL.Text = "DSL генератор";
            this.toolStripMenuDSL.Click += new System.EventHandler(this.toolStripMenuDSL_Click);
            // 
            // gbOntologyTree
            // 
            this.gbOntologyTree.Controls.Add(this.tvOntology);
            this.gbOntologyTree.Location = new System.Drawing.Point(12, 27);
            this.gbOntologyTree.Name = "gbOntologyTree";
            this.gbOntologyTree.Size = new System.Drawing.Size(266, 440);
            this.gbOntologyTree.TabIndex = 1;
            this.gbOntologyTree.TabStop = false;
            this.gbOntologyTree.Text = "Дерево онтологии";
            // 
            // tvOntology
            // 
            this.tvOntology.Location = new System.Drawing.Point(0, 19);
            this.tvOntology.Name = "tvOntology";
            this.tvOntology.Size = new System.Drawing.Size(266, 420);
            this.tvOntology.TabIndex = 0;
            this.tvOntology.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOntology_AfterSelect);
            this.tvOntology.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvOntology_MouseUp);
            this.tvOntology.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvOntology_MouseUp);
            // 
            // tcClass
            // 
            this.tcClass.Controls.Add(this.tpData);
            this.tcClass.Controls.Add(this.tpShow);
            this.tcClass.Location = new System.Drawing.Point(284, 27);
            this.tcClass.Name = "tcClass";
            this.tcClass.SelectedIndex = 0;
            this.tcClass.Size = new System.Drawing.Size(491, 409);
            this.tcClass.TabIndex = 2;
            this.tcClass.SelectedIndexChanged += new System.EventHandler(this.tcClass_SelectedIndexChanged);
            // 
            // tpData
            // 
            this.tpData.Controls.Add(this.btnAddRelation);
            this.tpData.Controls.Add(this.btnAddAttribute);
            this.tpData.Controls.Add(this.gbRelations);
            this.tpData.Controls.Add(this.gbAttributes);
            this.tpData.Location = new System.Drawing.Point(4, 22);
            this.tpData.Name = "tpData";
            this.tpData.Padding = new System.Windows.Forms.Padding(3);
            this.tpData.Size = new System.Drawing.Size(483, 383);
            this.tpData.TabIndex = 0;
            this.tpData.Text = "Данные";
            this.tpData.UseVisualStyleBackColor = true;
            // 
            // btnAddRelation
            // 
            this.btnAddRelation.Image = global::OntologyCreator.Properties.Resources.add;
            this.btnAddRelation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddRelation.Location = new System.Drawing.Point(271, 154);
            this.btnAddRelation.Name = "btnAddRelation";
            this.btnAddRelation.Size = new System.Drawing.Size(200, 25);
            this.btnAddRelation.TabIndex = 6;
            this.btnAddRelation.Text = "Добавить связь";
            this.btnAddRelation.UseVisualStyleBackColor = true;
            this.btnAddRelation.Visible = false;
            this.btnAddRelation.Click += new System.EventHandler(this.btnAddRelation_Click);
            // 
            // btnAddAttribute
            // 
            this.btnAddAttribute.Image = global::OntologyCreator.Properties.Resources.add;
            this.btnAddAttribute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddAttribute.Location = new System.Drawing.Point(6, 154);
            this.btnAddAttribute.Name = "btnAddAttribute";
            this.btnAddAttribute.Size = new System.Drawing.Size(200, 25);
            this.btnAddAttribute.TabIndex = 5;
            this.btnAddAttribute.Text = "Добавить свойство";
            this.btnAddAttribute.UseVisualStyleBackColor = true;
            this.btnAddAttribute.Visible = false;
            this.btnAddAttribute.Click += new System.EventHandler(this.btnAddAttribute_Click);
            // 
            // gbRelations
            // 
            this.gbRelations.Controls.Add(this.dgvRelations);
            this.gbRelations.Controls.Add(this.btnDelRelation);
            this.gbRelations.Controls.Add(this.btnEditRelation);
            this.gbRelations.Location = new System.Drawing.Point(6, 185);
            this.gbRelations.Name = "gbRelations";
            this.gbRelations.Size = new System.Drawing.Size(465, 144);
            this.gbRelations.TabIndex = 1;
            this.gbRelations.TabStop = false;
            this.gbRelations.Text = "Связи";
            // 
            // dgvRelations
            // 
            this.dgvRelations.AllowUserToAddRows = false;
            this.dgvRelations.AllowUserToDeleteRows = false;
            this.dgvRelations.AllowUserToResizeColumns = false;
            this.dgvRelations.AllowUserToResizeRows = false;
            this.dgvRelations.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvRelations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRelations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRelations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRelations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RelationID,
            this.RelationName,
            this.RelationWith,
            this.RelationType});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRelations.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRelations.EnableHeadersVisualStyles = false;
            this.dgvRelations.Location = new System.Drawing.Point(10, 19);
            this.dgvRelations.MultiSelect = false;
            this.dgvRelations.Name = "dgvRelations";
            this.dgvRelations.ReadOnly = true;
            this.dgvRelations.RowHeadersVisible = false;
            this.dgvRelations.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRelations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRelations.Size = new System.Drawing.Size(363, 100);
            this.dgvRelations.TabIndex = 8;
            this.dgvRelations.SelectionChanged += new System.EventHandler(this.dgvRelations_SelectionChanged);
            this.dgvRelations.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvRelations_MouseDown);
            this.dgvRelations.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvRelations_MouseDown);
            // 
            // RelationID
            // 
            this.RelationID.Frozen = true;
            this.RelationID.HeaderText = "ID";
            this.RelationID.Name = "RelationID";
            this.RelationID.ReadOnly = true;
            this.RelationID.Visible = false;
            // 
            // RelationName
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.RelationName.DefaultCellStyle = dataGridViewCellStyle2;
            this.RelationName.Frozen = true;
            this.RelationName.HeaderText = "Название";
            this.RelationName.Name = "RelationName";
            this.RelationName.ReadOnly = true;
            this.RelationName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RelationName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RelationName.Width = 121;
            // 
            // RelationWith
            // 
            this.RelationWith.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RelationWith.Frozen = true;
            this.RelationWith.HeaderText = "С чем";
            this.RelationWith.Name = "RelationWith";
            this.RelationWith.ReadOnly = true;
            this.RelationWith.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RelationWith.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RelationWith.Width = 121;
            // 
            // RelationType
            // 
            this.RelationType.HeaderText = "Тип отношений";
            this.RelationType.Name = "RelationType";
            this.RelationType.ReadOnly = true;
            this.RelationType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RelationType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RelationType.Width = 120;
            // 
            // btnDelRelation
            // 
            this.btnDelRelation.Enabled = false;
            this.btnDelRelation.Image = global::OntologyCreator.Properties.Resources.delete;
            this.btnDelRelation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelRelation.Location = new System.Drawing.Point(379, 50);
            this.btnDelRelation.Name = "btnDelRelation";
            this.btnDelRelation.Size = new System.Drawing.Size(80, 25);
            this.btnDelRelation.TabIndex = 5;
            this.btnDelRelation.TabStop = false;
            this.btnDelRelation.Text = "Удалить";
            this.btnDelRelation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelRelation.UseVisualStyleBackColor = true;
            this.btnDelRelation.Click += new System.EventHandler(this.btnDelRelation_Click);
            // 
            // btnEditRelation
            // 
            this.btnEditRelation.Enabled = false;
            this.btnEditRelation.Image = global::OntologyCreator.Properties.Resources.edit;
            this.btnEditRelation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditRelation.Location = new System.Drawing.Point(379, 19);
            this.btnEditRelation.Name = "btnEditRelation";
            this.btnEditRelation.Size = new System.Drawing.Size(80, 25);
            this.btnEditRelation.TabIndex = 4;
            this.btnEditRelation.TabStop = false;
            this.btnEditRelation.Text = "Изменить";
            this.btnEditRelation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditRelation.UseVisualStyleBackColor = true;
            // 
            // gbAttributes
            // 
            this.gbAttributes.Controls.Add(this.dgvAttributes);
            this.gbAttributes.Controls.Add(this.btnDelAttribute);
            this.gbAttributes.Controls.Add(this.btnEditAttribute);
            this.gbAttributes.Location = new System.Drawing.Point(6, 6);
            this.gbAttributes.Name = "gbAttributes";
            this.gbAttributes.Size = new System.Drawing.Size(465, 142);
            this.gbAttributes.TabIndex = 0;
            this.gbAttributes.TabStop = false;
            this.gbAttributes.Text = "Свойства";
            // 
            // dgvAttributes
            // 
            this.dgvAttributes.AllowUserToAddRows = false;
            this.dgvAttributes.AllowUserToDeleteRows = false;
            this.dgvAttributes.AllowUserToResizeColumns = false;
            this.dgvAttributes.AllowUserToResizeRows = false;
            this.dgvAttributes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvAttributes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAttributes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PropertyID,
            this.PropertyName,
            this.PropertyValue});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAttributes.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvAttributes.EnableHeadersVisualStyles = false;
            this.dgvAttributes.Location = new System.Drawing.Point(10, 19);
            this.dgvAttributes.MultiSelect = false;
            this.dgvAttributes.Name = "dgvAttributes";
            this.dgvAttributes.ReadOnly = true;
            this.dgvAttributes.RowHeadersVisible = false;
            this.dgvAttributes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAttributes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttributes.Size = new System.Drawing.Size(363, 117);
            this.dgvAttributes.TabIndex = 7;
            this.dgvAttributes.SelectionChanged += new System.EventHandler(this.dgvAttributes_SelectionChanged);
            this.dgvAttributes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvAttributes_MouseDown);
            this.dgvAttributes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvAttributes_MouseDown);
            // 
            // PropertyID
            // 
            this.PropertyID.Frozen = true;
            this.PropertyID.HeaderText = "ID";
            this.PropertyID.Name = "PropertyID";
            this.PropertyID.ReadOnly = true;
            this.PropertyID.Visible = false;
            // 
            // PropertyName
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PropertyName.DefaultCellStyle = dataGridViewCellStyle5;
            this.PropertyName.Frozen = true;
            this.PropertyName.HeaderText = "Название";
            this.PropertyName.Name = "PropertyName";
            this.PropertyName.ReadOnly = true;
            this.PropertyName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PropertyName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PropertyName.Width = 160;
            // 
            // PropertyValue
            // 
            this.PropertyValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.PropertyValue.DefaultCellStyle = dataGridViewCellStyle6;
            this.PropertyValue.Frozen = true;
            this.PropertyValue.HeaderText = "Значение";
            this.PropertyValue.Name = "PropertyValue";
            this.PropertyValue.ReadOnly = true;
            this.PropertyValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PropertyValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PropertyValue.Width = 202;
            // 
            // btnDelAttribute
            // 
            this.btnDelAttribute.Enabled = false;
            this.btnDelAttribute.Image = global::OntologyCreator.Properties.Resources.delete;
            this.btnDelAttribute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelAttribute.Location = new System.Drawing.Point(379, 50);
            this.btnDelAttribute.Name = "btnDelAttribute";
            this.btnDelAttribute.Size = new System.Drawing.Size(80, 25);
            this.btnDelAttribute.TabIndex = 1;
            this.btnDelAttribute.TabStop = false;
            this.btnDelAttribute.Text = "Удалить";
            this.btnDelAttribute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelAttribute.UseVisualStyleBackColor = true;
            this.btnDelAttribute.Click += new System.EventHandler(this.btnDelAttribute_Click);
            // 
            // btnEditAttribute
            // 
            this.btnEditAttribute.Enabled = false;
            this.btnEditAttribute.Image = global::OntologyCreator.Properties.Resources.edit;
            this.btnEditAttribute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditAttribute.Location = new System.Drawing.Point(379, 19);
            this.btnEditAttribute.Name = "btnEditAttribute";
            this.btnEditAttribute.Size = new System.Drawing.Size(80, 25);
            this.btnEditAttribute.TabIndex = 0;
            this.btnEditAttribute.TabStop = false;
            this.btnEditAttribute.Text = "Изменить";
            this.btnEditAttribute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditAttribute.UseVisualStyleBackColor = true;
            this.btnEditAttribute.Click += new System.EventHandler(this.btnEditAttribute_Click);
            // 
            // tpShow
            // 
            this.tpShow.Controls.Add(this.panel1);
            this.tpShow.Location = new System.Drawing.Point(4, 22);
            this.tpShow.Name = "tpShow";
            this.tpShow.Padding = new System.Windows.Forms.Padding(3);
            this.tpShow.Size = new System.Drawing.Size(483, 383);
            this.tpShow.TabIndex = 1;
            this.tpShow.Text = "Просмотр";
            this.tpShow.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pbOntology);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 360);
            this.panel1.TabIndex = 1;
            // 
            // pbOntology
            // 
            this.pbOntology.Location = new System.Drawing.Point(0, 0);
            this.pbOntology.Name = "pbOntology";
            this.pbOntology.Size = new System.Drawing.Size(452, 360);
            this.pbOntology.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOntology.TabIndex = 0;
            this.pbOntology.TabStop = false;
            // 
            // btnEditClass
            // 
            this.btnEditClass.Enabled = false;
            this.btnEditClass.Image = global::OntologyCreator.Properties.Resources.edit;
            this.btnEditClass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditClass.Location = new System.Drawing.Point(545, 442);
            this.btnEditClass.Name = "btnEditClass";
            this.btnEditClass.Size = new System.Drawing.Size(113, 25);
            this.btnEditClass.TabIndex = 3;
            this.btnEditClass.Text = "Изменить класс";
            this.btnEditClass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditClass.UseVisualStyleBackColor = true;
            this.btnEditClass.Click += new System.EventHandler(this.btnEditClass_Click);
            // 
            // btnDelClass
            // 
            this.btnDelClass.Enabled = false;
            this.btnDelClass.Image = global::OntologyCreator.Properties.Resources.delete;
            this.btnDelClass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelClass.Location = new System.Drawing.Point(664, 442);
            this.btnDelClass.Name = "btnDelClass";
            this.btnDelClass.Size = new System.Drawing.Size(111, 25);
            this.btnDelClass.TabIndex = 4;
            this.btnDelClass.Text = "Удалить класс";
            this.btnDelClass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelClass.UseVisualStyleBackColor = true;
            this.btnDelClass.Click += new System.EventHandler(this.btnDelClass_Click);
            // 
            // btnAddSubclass
            // 
            this.btnAddSubclass.Enabled = false;
            this.btnAddSubclass.Image = global::OntologyCreator.Properties.Resources.plus;
            this.btnAddSubclass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddSubclass.Location = new System.Drawing.Point(407, 442);
            this.btnAddSubclass.Name = "btnAddSubclass";
            this.btnAddSubclass.Size = new System.Drawing.Size(132, 25);
            this.btnAddSubclass.TabIndex = 1;
            this.btnAddSubclass.Text = "Добавить подкласс";
            this.btnAddSubclass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddSubclass.UseVisualStyleBackColor = true;
            this.btnAddSubclass.Click += new System.EventHandler(this.btnAddSubclass_Click);
            // 
            // btnAddClass
            // 
            this.btnAddClass.Image = global::OntologyCreator.Properties.Resources.add;
            this.btnAddClass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddClass.Location = new System.Drawing.Point(284, 442);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(117, 25);
            this.btnAddClass.TabIndex = 0;
            this.btnAddClass.Text = "Добавить класс";
            this.btnAddClass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddClass.UseVisualStyleBackColor = true;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 539);
            this.Controls.Add(this.btnEditClass);
            this.Controls.Add(this.btnDelClass);
            this.Controls.Add(this.btnAddSubclass);
            this.Controls.Add(this.btnAddClass);
            this.Controls.Add(this.tcClass);
            this.Controls.Add(this.gbOntologyTree);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Ontology Interviewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.gbOntologyTree.ResumeLayout(false);
            this.tcClass.ResumeLayout(false);
            this.tpData.ResumeLayout(false);
            this.gbRelations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelations)).EndInit();
            this.gbAttributes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).EndInit();
            this.tpShow.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbOntology)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem msFile;
        private System.Windows.Forms.ToolStripMenuItem msFileCreate;
        private System.Windows.Forms.ToolStripMenuItem msFileOpen;
        private System.Windows.Forms.ToolStripMenuItem msSaveOWL;
        private System.Windows.Forms.ToolStripMenuItem msInfo;
        private System.Windows.Forms.GroupBox gbOntologyTree;
        private System.Windows.Forms.TreeView tvOntology;
        private System.Windows.Forms.TabControl tcClass;
        private System.Windows.Forms.TabPage tpData;
        private System.Windows.Forms.GroupBox gbRelations;
        private System.Windows.Forms.GroupBox gbAttributes;
        private System.Windows.Forms.TabPage tpShow;
        private System.Windows.Forms.Button btnAddClass;
        private System.Windows.Forms.Button btnAddSubclass;
        private System.Windows.Forms.Button btnDelClass;
        private System.Windows.Forms.Button btnAddRelation;
        private System.Windows.Forms.Button btnAddAttribute;
        private System.Windows.Forms.DataGridView dgvRelations;
        private System.Windows.Forms.Button btnDelRelation;
        private System.Windows.Forms.Button btnEditRelation;
        private System.Windows.Forms.DataGridView dgvAttributes;
        private System.Windows.Forms.Button btnDelAttribute;
        private System.Windows.Forms.Button btnEditAttribute;
        private System.Windows.Forms.Button btnEditClass;
        private System.Windows.Forms.PictureBox pbOntology;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem msSavePicture;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDSL;
        private System.Windows.Forms.ToolStripMenuItem msSaveXML;
        private System.Windows.Forms.ToolStripMenuItem msExistingOntologies;
        private System.Windows.Forms.ToolStripMenuItem объединитьОнтологииToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelationWith;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyValue;
    }
}