namespace OntologyCreator.Forms
{
    partial class OntologyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OntologyForm));
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.tbDescript = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbInterview = new System.Windows.Forms.GroupBox();
            this.lblInterview = new System.Windows.Forms.Label();
            this.btnSubject = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAction = new System.Windows.Forms.Button();
            this.gbInterview.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSubject
            // 
            this.tbSubject.BackColor = System.Drawing.SystemColors.Menu;
            this.tbSubject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSubject.Location = new System.Drawing.Point(12, 104);
            this.tbSubject.Multiline = true;
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.ReadOnly = true;
            this.tbSubject.Size = new System.Drawing.Size(237, 36);
            this.tbSubject.TabIndex = 27;
            // 
            // tbDescript
            // 
            this.tbDescript.Location = new System.Drawing.Point(75, 32);
            this.tbDescript.MaxLength = 1000;
            this.tbDescript.Multiline = true;
            this.tbDescript.Name = "tbDescript";
            this.tbDescript.Size = new System.Drawing.Size(261, 47);
            this.tbDescript.TabIndex = 4;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(75, 6);
            this.tbName.MaxLength = 100;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(261, 20);
            this.tbName.TabIndex = 3;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Предметная область:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Описание";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Название*";
            // 
            // gbInterview
            // 
            this.gbInterview.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gbInterview.Controls.Add(this.lblInterview);
            this.gbInterview.Location = new System.Drawing.Point(12, 177);
            this.gbInterview.Name = "gbInterview";
            this.gbInterview.Size = new System.Drawing.Size(324, 63);
            this.gbInterview.TabIndex = 28;
            this.gbInterview.TabStop = false;
            this.gbInterview.Text = "Интвервью";
            // 
            // lblInterview
            // 
            this.lblInterview.Location = new System.Drawing.Point(7, 20);
            this.lblInterview.Name = "lblInterview";
            this.lblInterview.Size = new System.Drawing.Size(311, 39);
            this.lblInterview.TabIndex = 0;
            // 
            // btnSubject
            // 
            this.btnSubject.Image = global::OntologyCreator.Properties.Resources.magnifying_glass_search;
            this.btnSubject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubject.Location = new System.Drawing.Point(255, 115);
            this.btnSubject.Name = "btnSubject";
            this.btnSubject.Size = new System.Drawing.Size(81, 25);
            this.btnSubject.TabIndex = 2;
            this.btnSubject.Text = "Подробно";
            this.btnSubject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubject.UseVisualStyleBackColor = true;
            this.btnSubject.Click += new System.EventHandler(this.btnSubject_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::OntologyCreator.Properties.Resources.back;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(255, 146);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 25);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Назад";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAction
            // 
            this.btnAction.Image = global::OntologyCreator.Properties.Resources.edit;
            this.btnAction.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAction.Location = new System.Drawing.Point(15, 146);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(234, 25);
            this.btnAction.TabIndex = 1;
            this.btnAction.Text = "Редактировать";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // OntologyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 245);
            this.Controls.Add(this.gbInterview);
            this.Controls.Add(this.btnSubject);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.tbDescript);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OntologyForm";
            this.Text = "Информация об онтологии";
            this.gbInterview.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.TextBox tbDescript;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubject;
        private System.Windows.Forms.GroupBox gbInterview;
        private System.Windows.Forms.Label lblInterview;
    }
}