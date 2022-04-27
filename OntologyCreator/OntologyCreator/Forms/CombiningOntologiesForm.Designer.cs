namespace OntologyCreator.Forms
{
    partial class CombineOntologyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CombineOntologyForm));
            this.tvCurrentOntology = new System.Windows.Forms.TreeView();
            this.lblCurrentOntologyText = new System.Windows.Forms.Label();
            this.btnSaveResultXml = new System.Windows.Forms.Button();
            this.tvSecondOntology = new System.Windows.Forms.TreeView();
            this.tvResultOntology = new System.Windows.Forms.TreeView();
            this.lblSecondOntology = new System.Windows.Forms.Label();
            this.lblResultOntology = new System.Windows.Forms.Label();
            this.cbExistingOntologies = new System.Windows.Forms.ComboBox();
            this.lblSecondOntologyName = new System.Windows.Forms.Label();
            this.lblCurrentOntologyName = new System.Windows.Forms.Label();
            this.gbInterview = new System.Windows.Forms.GroupBox();
            this.lblInterview = new System.Windows.Forms.Label();
            this.cbUseExistingOntologies = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentConcept = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSecondConcept = new System.Windows.Forms.Label();
            this.btnCombineNoConnect = new System.Windows.Forms.Button();
            this.btnResultSettings = new System.Windows.Forms.Button();
            this.btnResultClear = new System.Windows.Forms.Button();
            this.btnCombineNew = new System.Windows.Forms.Button();
            this.btnCombineExisting = new System.Windows.Forms.Button();
            this.btnCurrentInfo = new System.Windows.Forms.Button();
            this.btnOpenSecondOntology = new System.Windows.Forms.Button();
            this.btnSaveResultOwl = new System.Windows.Forms.Button();
            this.gbInterview.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvCurrentOntology
            // 
            this.tvCurrentOntology.Location = new System.Drawing.Point(12, 41);
            this.tvCurrentOntology.Name = "tvCurrentOntology";
            this.tvCurrentOntology.Size = new System.Drawing.Size(205, 413);
            this.tvCurrentOntology.TabIndex = 4;
            this.tvCurrentOntology.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCurrent_AfterSelect);
            // 
            // lblCurrentOntologyText
            // 
            this.lblCurrentOntologyText.AutoSize = true;
            this.lblCurrentOntologyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrentOntologyText.Location = new System.Drawing.Point(23, 457);
            this.lblCurrentOntologyText.Name = "lblCurrentOntologyText";
            this.lblCurrentOntologyText.Size = new System.Drawing.Size(188, 24);
            this.lblCurrentOntologyText.TabIndex = 0;
            this.lblCurrentOntologyText.Text = "Текущая онтология ";
            this.lblCurrentOntologyText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSaveResultXml
            // 
            this.btnSaveResultXml.Enabled = false;
            this.btnSaveResultXml.Image = global::OntologyCreator.Properties.Resources.floppy_disk;
            this.btnSaveResultXml.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveResultXml.Location = new System.Drawing.Point(645, 417);
            this.btnSaveResultXml.Name = "btnSaveResultXml";
            this.btnSaveResultXml.Size = new System.Drawing.Size(166, 42);
            this.btnSaveResultXml.TabIndex = 10;
            this.btnSaveResultXml.Text = "Сохранить XML";
            this.btnSaveResultXml.UseVisualStyleBackColor = true;
            this.btnSaveResultXml.Click += new System.EventHandler(this.btnSaveResultXml_Click);
            // 
            // tvSecondOntology
            // 
            this.tvSecondOntology.Location = new System.Drawing.Point(223, 84);
            this.tvSecondOntology.Name = "tvSecondOntology";
            this.tvSecondOntology.Size = new System.Drawing.Size(205, 370);
            this.tvSecondOntology.TabIndex = 5;
            this.tvSecondOntology.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSecondOntology_AfterSelect);
            // 
            // tvResultOntology
            // 
            this.tvResultOntology.Location = new System.Drawing.Point(434, 10);
            this.tvResultOntology.Name = "tvResultOntology";
            this.tvResultOntology.Size = new System.Drawing.Size(205, 444);
            this.tvResultOntology.TabIndex = 12;
            // 
            // lblSecondOntology
            // 
            this.lblSecondOntology.AutoSize = true;
            this.lblSecondOntology.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSecondOntology.Location = new System.Drawing.Point(240, 457);
            this.lblSecondOntology.Name = "lblSecondOntology";
            this.lblSecondOntology.Size = new System.Drawing.Size(178, 24);
            this.lblSecondOntology.TabIndex = 0;
            this.lblSecondOntology.Text = "Вторая онтология ";
            this.lblSecondOntology.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResultOntology
            // 
            this.lblResultOntology.AutoSize = true;
            this.lblResultOntology.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResultOntology.Location = new System.Drawing.Point(486, 457);
            this.lblResultOntology.Name = "lblResultOntology";
            this.lblResultOntology.Size = new System.Drawing.Size(103, 24);
            this.lblResultOntology.TabIndex = 0;
            this.lblResultOntology.Text = "Результат";
            this.lblResultOntology.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbExistingOntologies
            // 
            this.cbExistingOntologies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExistingOntologies.Enabled = false;
            this.cbExistingOntologies.FormattingEnabled = true;
            this.cbExistingOntologies.Location = new System.Drawing.Point(223, 57);
            this.cbExistingOntologies.Name = "cbExistingOntologies";
            this.cbExistingOntologies.Size = new System.Drawing.Size(205, 21);
            this.cbExistingOntologies.TabIndex = 3;
            this.cbExistingOntologies.SelectedIndexChanged += new System.EventHandler(this.cbExistingOntologies_SelectedIndexChanged);
            // 
            // lblSecondOntologyName
            // 
            this.lblSecondOntologyName.AutoSize = true;
            this.lblSecondOntologyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSecondOntologyName.Location = new System.Drawing.Point(308, 15);
            this.lblSecondOntologyName.Name = "lblSecondOntologyName";
            this.lblSecondOntologyName.Size = new System.Drawing.Size(124, 13);
            this.lblSecondOntologyName.TabIndex = 0;
            this.lblSecondOntologyName.Text = "Онтология отсутствует";
            // 
            // lblCurrentOntologyName
            // 
            this.lblCurrentOntologyName.AutoSize = true;
            this.lblCurrentOntologyName.Location = new System.Drawing.Point(12, 15);
            this.lblCurrentOntologyName.Name = "lblCurrentOntologyName";
            this.lblCurrentOntologyName.Size = new System.Drawing.Size(107, 13);
            this.lblCurrentOntologyName.TabIndex = 0;
            this.lblCurrentOntologyName.Text = "Текущая онтология";
            // 
            // gbInterview
            // 
            this.gbInterview.Controls.Add(this.lblInterview);
            this.gbInterview.Location = new System.Drawing.Point(12, 485);
            this.gbInterview.Name = "gbInterview";
            this.gbInterview.Size = new System.Drawing.Size(799, 59);
            this.gbInterview.TabIndex = 0;
            this.gbInterview.TabStop = false;
            this.gbInterview.Text = "Интервью";
            // 
            // lblInterview
            // 
            this.lblInterview.Location = new System.Drawing.Point(7, 20);
            this.lblInterview.Name = "lblInterview";
            this.lblInterview.Size = new System.Drawing.Size(786, 27);
            this.lblInterview.TabIndex = 0;
            this.lblInterview.Text = resources.GetString("lblInterview.Text");
            // 
            // cbUseExistingOntologies
            // 
            this.cbUseExistingOntologies.AutoSize = true;
            this.cbUseExistingOntologies.Location = new System.Drawing.Point(223, 37);
            this.cbUseExistingOntologies.Name = "cbUseExistingOntologies";
            this.cbUseExistingOntologies.Size = new System.Drawing.Size(152, 17);
            this.cbUseExistingOntologies.TabIndex = 13;
            this.cbUseExistingOntologies.Text = "Использовать открытые";
            this.cbUseExistingOntologies.UseVisualStyleBackColor = true;
            this.cbUseExistingOntologies.CheckedChanged += new System.EventHandler(this.cbUseExistingOntologies_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(645, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Концепт текущей онтологии:";
            // 
            // lblCurrentConcept
            // 
            this.lblCurrentConcept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrentConcept.Location = new System.Drawing.Point(645, 27);
            this.lblCurrentConcept.Name = "lblCurrentConcept";
            this.lblCurrentConcept.Size = new System.Drawing.Size(166, 39);
            this.lblCurrentConcept.TabIndex = 17;
            this.lblCurrentConcept.Text = "не выбран";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(645, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Концепт второй онтологии:";
            // 
            // lblSecondConcept
            // 
            this.lblSecondConcept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSecondConcept.Location = new System.Drawing.Point(645, 87);
            this.lblSecondConcept.Name = "lblSecondConcept";
            this.lblSecondConcept.Size = new System.Drawing.Size(166, 39);
            this.lblSecondConcept.TabIndex = 19;
            this.lblSecondConcept.Text = "не выбран";
            // 
            // btnCombineNoConnect
            // 
            this.btnCombineNoConnect.Enabled = false;
            this.btnCombineNoConnect.Image = global::OntologyCreator.Properties.Resources.merge__1_;
            this.btnCombineNoConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCombineNoConnect.Location = new System.Drawing.Point(645, 225);
            this.btnCombineNoConnect.Name = "btnCombineNoConnect";
            this.btnCombineNoConnect.Size = new System.Drawing.Size(166, 42);
            this.btnCombineNoConnect.TabIndex = 20;
            this.btnCombineNoConnect.Text = "Объединить без основы";
            this.btnCombineNoConnect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCombineNoConnect.UseVisualStyleBackColor = true;
            this.btnCombineNoConnect.Click += new System.EventHandler(this.btnCombineNoConnect_Click);
            // 
            // btnResultSettings
            // 
            this.btnResultSettings.Enabled = false;
            this.btnResultSettings.Image = global::OntologyCreator.Properties.Resources.settings;
            this.btnResultSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResultSettings.Location = new System.Drawing.Point(645, 321);
            this.btnResultSettings.Name = "btnResultSettings";
            this.btnResultSettings.Size = new System.Drawing.Size(166, 42);
            this.btnResultSettings.TabIndex = 9;
            this.btnResultSettings.Text = "Настройки онтологии";
            this.btnResultSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResultSettings.UseVisualStyleBackColor = true;
            this.btnResultSettings.Click += new System.EventHandler(this.btnResultSettings_Click);
            // 
            // btnResultClear
            // 
            this.btnResultClear.Enabled = false;
            this.btnResultClear.Image = global::OntologyCreator.Properties.Resources.rubber__1_;
            this.btnResultClear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResultClear.Location = new System.Drawing.Point(645, 273);
            this.btnResultClear.Name = "btnResultClear";
            this.btnResultClear.Size = new System.Drawing.Size(166, 42);
            this.btnResultClear.TabIndex = 8;
            this.btnResultClear.Text = "Очистить";
            this.btnResultClear.UseVisualStyleBackColor = true;
            this.btnResultClear.Click += new System.EventHandler(this.btnResultClear_Click);
            // 
            // btnCombineNew
            // 
            this.btnCombineNew.Enabled = false;
            this.btnCombineNew.Image = global::OntologyCreator.Properties.Resources.merge;
            this.btnCombineNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCombineNew.Location = new System.Drawing.Point(645, 177);
            this.btnCombineNew.Name = "btnCombineNew";
            this.btnCombineNew.Size = new System.Drawing.Size(166, 42);
            this.btnCombineNew.TabIndex = 7;
            this.btnCombineNew.Text = "Объединить концепты на основе нового";
            this.btnCombineNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCombineNew.UseVisualStyleBackColor = true;
            this.btnCombineNew.Click += new System.EventHandler(this.btnCombineNew_Click);
            // 
            // btnCombineExisting
            // 
            this.btnCombineExisting.Enabled = false;
            this.btnCombineExisting.Image = global::OntologyCreator.Properties.Resources.gym_rings_couple__1_;
            this.btnCombineExisting.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCombineExisting.Location = new System.Drawing.Point(645, 129);
            this.btnCombineExisting.Name = "btnCombineExisting";
            this.btnCombineExisting.Size = new System.Drawing.Size(166, 42);
            this.btnCombineExisting.TabIndex = 6;
            this.btnCombineExisting.Text = "Объединить на основе семантической близости";
            this.btnCombineExisting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCombineExisting.UseVisualStyleBackColor = true;
            this.btnCombineExisting.Click += new System.EventHandler(this.btnCombineExisting_Click);
            // 
            // btnCurrentInfo
            // 
            this.btnCurrentInfo.Image = global::OntologyCreator.Properties.Resources.magnifying_glass_search;
            this.btnCurrentInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCurrentInfo.Location = new System.Drawing.Point(138, 10);
            this.btnCurrentInfo.Name = "btnCurrentInfo";
            this.btnCurrentInfo.Size = new System.Drawing.Size(79, 25);
            this.btnCurrentInfo.TabIndex = 0;
            this.btnCurrentInfo.TabStop = false;
            this.btnCurrentInfo.Text = "Подробно";
            this.btnCurrentInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCurrentInfo.UseVisualStyleBackColor = true;
            this.btnCurrentInfo.Click += new System.EventHandler(this.btnCurrentInfo_Click);
            // 
            // btnOpenSecondOntology
            // 
            this.btnOpenSecondOntology.Image = global::OntologyCreator.Properties.Resources.folder__1_;
            this.btnOpenSecondOntology.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenSecondOntology.Location = new System.Drawing.Point(223, 10);
            this.btnOpenSecondOntology.Name = "btnOpenSecondOntology";
            this.btnOpenSecondOntology.Size = new System.Drawing.Size(79, 25);
            this.btnOpenSecondOntology.TabIndex = 1;
            this.btnOpenSecondOntology.Text = "Открыть";
            this.btnOpenSecondOntology.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenSecondOntology.UseVisualStyleBackColor = true;
            this.btnOpenSecondOntology.Click += new System.EventHandler(this.btnOpenSecondOntology_Click);
            // 
            // btnSaveResultOwl
            // 
            this.btnSaveResultOwl.Enabled = false;
            this.btnSaveResultOwl.Image = global::OntologyCreator.Properties.Resources.floppy_disk;
            this.btnSaveResultOwl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveResultOwl.Location = new System.Drawing.Point(645, 369);
            this.btnSaveResultOwl.Name = "btnSaveResultOwl";
            this.btnSaveResultOwl.Size = new System.Drawing.Size(166, 42);
            this.btnSaveResultOwl.TabIndex = 11;
            this.btnSaveResultOwl.Text = "Сохранить OWL";
            this.btnSaveResultOwl.UseVisualStyleBackColor = true;
            this.btnSaveResultOwl.Click += new System.EventHandler(this.btnSaveResultOwl_Click);
            // 
            // CombineOntologyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 556);
            this.Controls.Add(this.btnCombineNoConnect);
            this.Controls.Add(this.lblSecondConcept);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCurrentConcept);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbUseExistingOntologies);
            this.Controls.Add(this.gbInterview);
            this.Controls.Add(this.btnResultSettings);
            this.Controls.Add(this.btnResultClear);
            this.Controls.Add(this.btnCombineNew);
            this.Controls.Add(this.btnCombineExisting);
            this.Controls.Add(this.lblCurrentOntologyName);
            this.Controls.Add(this.btnCurrentInfo);
            this.Controls.Add(this.lblSecondOntologyName);
            this.Controls.Add(this.btnOpenSecondOntology);
            this.Controls.Add(this.cbExistingOntologies);
            this.Controls.Add(this.btnSaveResultOwl);
            this.Controls.Add(this.lblResultOntology);
            this.Controls.Add(this.lblSecondOntology);
            this.Controls.Add(this.tvResultOntology);
            this.Controls.Add(this.tvSecondOntology);
            this.Controls.Add(this.btnSaveResultXml);
            this.Controls.Add(this.lblCurrentOntologyText);
            this.Controls.Add(this.tvCurrentOntology);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CombineOntologyForm";
            this.Text = "Объединение онтологий";
            this.gbInterview.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvCurrentOntology;
        private System.Windows.Forms.Label lblCurrentOntologyText;
        private System.Windows.Forms.Button btnSaveResultXml;
        private System.Windows.Forms.TreeView tvSecondOntology;
        private System.Windows.Forms.TreeView tvResultOntology;
        private System.Windows.Forms.Label lblSecondOntology;
        private System.Windows.Forms.Label lblResultOntology;
        private System.Windows.Forms.Button btnSaveResultOwl;
        private System.Windows.Forms.ComboBox cbExistingOntologies;
        private System.Windows.Forms.Button btnOpenSecondOntology;
        private System.Windows.Forms.Label lblSecondOntologyName;
        private System.Windows.Forms.Button btnCurrentInfo;
        private System.Windows.Forms.Label lblCurrentOntologyName;
        private System.Windows.Forms.Button btnCombineExisting;
        private System.Windows.Forms.Button btnCombineNew;
        private System.Windows.Forms.Button btnResultClear;
        private System.Windows.Forms.Button btnResultSettings;
        private System.Windows.Forms.GroupBox gbInterview;
        private System.Windows.Forms.Label lblInterview;
        private System.Windows.Forms.CheckBox cbUseExistingOntologies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentConcept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSecondConcept;
        private System.Windows.Forms.Button btnCombineNoConnect;
    }
}