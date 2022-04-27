
namespace OntologyCreator.Forms
{
    partial class DSL_Form
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
            this.rdyBtn = new System.Windows.Forms.Button();
            this.gbDSL = new System.Windows.Forms.GroupBox();
            this.dgvProjection = new System.Windows.Forms.DataGridView();
            this.Names = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbTreeDsls = new System.Windows.Forms.GroupBox();
            this.tvOntologyLanguage = new System.Windows.Forms.TreeView();
            this.btnChooseOntology = new System.Windows.Forms.Button();
            this.btnSelectLanguage = new System.Windows.Forms.Button();
            this.gbDomainOntology = new System.Windows.Forms.GroupBox();
            this.tvOntologyDomain = new System.Windows.Forms.TreeView();
            this.chbSaveRelations = new System.Windows.Forms.CheckBox();
            this.gbDSL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjection)).BeginInit();
            this.gbTreeDsls.SuspendLayout();
            this.gbDomainOntology.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdyBtn
            // 
            this.rdyBtn.Location = new System.Drawing.Point(1016, 539);
            this.rdyBtn.Name = "rdyBtn";
            this.rdyBtn.Size = new System.Drawing.Size(104, 31);
            this.rdyBtn.TabIndex = 0;
            this.rdyBtn.Text = "Генерация";
            this.rdyBtn.UseVisualStyleBackColor = true;
            this.rdyBtn.Click += new System.EventHandler(this.rdyBtn_Click);
            // 
            // gbDSL
            // 
            this.gbDSL.Controls.Add(this.dgvProjection);
            this.gbDSL.Location = new System.Drawing.Point(282, 12);
            this.gbDSL.Name = "gbDSL";
            this.gbDSL.Size = new System.Drawing.Size(568, 521);
            this.gbDSL.TabIndex = 1;
            this.gbDSL.TabStop = false;
            this.gbDSL.Text = "Проецирование";
            // 
            // dgvProjection
            // 
            this.dgvProjection.AllowUserToAddRows = false;
            this.dgvProjection.AllowUserToDeleteRows = false;
            this.dgvProjection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProjection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Names,
            this.Type});
            this.dgvProjection.Location = new System.Drawing.Point(6, 19);
            this.dgvProjection.Name = "dgvProjection";
            this.dgvProjection.Size = new System.Drawing.Size(556, 496);
            this.dgvProjection.TabIndex = 5;
            // 
            // Names
            // 
            this.Names.HeaderText = "Имя";
            this.Names.Name = "Names";
            // 
            // Type
            // 
            this.Type.HeaderText = "Тип";
            this.Type.Name = "Type";
            // 
            // gbTreeDsls
            // 
            this.gbTreeDsls.Controls.Add(this.tvOntologyLanguage);
            this.gbTreeDsls.Location = new System.Drawing.Point(12, 12);
            this.gbTreeDsls.Name = "gbTreeDsls";
            this.gbTreeDsls.Size = new System.Drawing.Size(264, 521);
            this.gbTreeDsls.TabIndex = 1;
            this.gbTreeDsls.TabStop = false;
            this.gbTreeDsls.Text = "Языковая онтология";
            // 
            // tvOntologyLanguage
            // 
            this.tvOntologyLanguage.Location = new System.Drawing.Point(6, 16);
            this.tvOntologyLanguage.Name = "tvOntologyLanguage";
            this.tvOntologyLanguage.Size = new System.Drawing.Size(252, 499);
            this.tvOntologyLanguage.TabIndex = 0;
            this.tvOntologyLanguage.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOntologyDsls_AfterSelect);
            // 
            // btnChooseOntology
            // 
            this.btnChooseOntology.Location = new System.Drawing.Point(12, 539);
            this.btnChooseOntology.Name = "btnChooseOntology";
            this.btnChooseOntology.Size = new System.Drawing.Size(264, 31);
            this.btnChooseOntology.TabIndex = 2;
            this.btnChooseOntology.Text = "Выбрать онтологию языков";
            this.btnChooseOntology.UseVisualStyleBackColor = true;
            this.btnChooseOntology.Click += new System.EventHandler(this.btnChooseOntology_Click);
            // 
            // btnSelectLanguage
            // 
            this.btnSelectLanguage.Enabled = false;
            this.btnSelectLanguage.Location = new System.Drawing.Point(282, 539);
            this.btnSelectLanguage.Name = "btnSelectLanguage";
            this.btnSelectLanguage.Size = new System.Drawing.Size(172, 31);
            this.btnSelectLanguage.TabIndex = 3;
            this.btnSelectLanguage.Text = "Выбрать в качестве основы";
            this.btnSelectLanguage.UseVisualStyleBackColor = true;
            this.btnSelectLanguage.Click += new System.EventHandler(this.btnSelectLanguage_Click);
            // 
            // gbDomainOntology
            // 
            this.gbDomainOntology.Controls.Add(this.tvOntologyDomain);
            this.gbDomainOntology.Location = new System.Drawing.Point(856, 12);
            this.gbDomainOntology.Name = "gbDomainOntology";
            this.gbDomainOntology.Size = new System.Drawing.Size(264, 521);
            this.gbDomainOntology.TabIndex = 4;
            this.gbDomainOntology.TabStop = false;
            this.gbDomainOntology.Text = "Онтология предметной области";
            // 
            // tvOntologyDomain
            // 
            this.tvOntologyDomain.Location = new System.Drawing.Point(6, 16);
            this.tvOntologyDomain.Name = "tvOntologyDomain";
            this.tvOntologyDomain.Size = new System.Drawing.Size(252, 499);
            this.tvOntologyDomain.TabIndex = 0;
            // 
            // chbSaveRelations
            // 
            this.chbSaveRelations.AutoSize = true;
            this.chbSaveRelations.Location = new System.Drawing.Point(624, 547);
            this.chbSaveRelations.Name = "chbSaveRelations";
            this.chbSaveRelations.Size = new System.Drawing.Size(220, 17);
            this.chbSaveRelations.TabIndex = 5;
            this.chbSaveRelations.Text = "Сохранить связи предметной области";
            this.chbSaveRelations.UseVisualStyleBackColor = true;
            this.chbSaveRelations.CheckedChanged += new System.EventHandler(this.chbSaveRelations_CheckedChanged);
            // 
            // DSL_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 582);
            this.Controls.Add(this.chbSaveRelations);
            this.Controls.Add(this.gbDomainOntology);
            this.Controls.Add(this.btnSelectLanguage);
            this.Controls.Add(this.btnChooseOntology);
            this.Controls.Add(this.gbTreeDsls);
            this.Controls.Add(this.gbDSL);
            this.Controls.Add(this.rdyBtn);
            this.Name = "DSL_Form";
            this.Text = "DSL Generation";
            this.gbDSL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjection)).EndInit();
            this.gbTreeDsls.ResumeLayout(false);
            this.gbDomainOntology.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button rdyBtn;
        private System.Windows.Forms.GroupBox gbDSL;
        private System.Windows.Forms.GroupBox gbTreeDsls;
        private System.Windows.Forms.TreeView tvOntologyLanguage;
        private System.Windows.Forms.Button btnChooseOntology;
        private System.Windows.Forms.Button btnSelectLanguage;
        private System.Windows.Forms.GroupBox gbDomainOntology;
        private System.Windows.Forms.TreeView tvOntologyDomain;
        private System.Windows.Forms.DataGridView dgvProjection;
        private System.Windows.Forms.DataGridViewTextBoxColumn Names;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.CheckBox chbSaveRelations;
    }
}