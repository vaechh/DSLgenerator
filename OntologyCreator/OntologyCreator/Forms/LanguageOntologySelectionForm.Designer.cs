
namespace OntologyCreator.Forms
{
    partial class LanguageOntologySelectionForm
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
            this.choseLabel = new System.Windows.Forms.Label();
            this.btnMethood = new System.Windows.Forms.Button();
            this.btnMission = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // choseLabel
            // 
            this.choseLabel.AutoSize = true;
            this.choseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.choseLabel.Location = new System.Drawing.Point(58, 49);
            this.choseLabel.Name = "choseLabel";
            this.choseLabel.Size = new System.Drawing.Size(191, 15);
            this.choseLabel.TabIndex = 0;
            this.choseLabel.Text = "Выберете языковую онтологию";
            // 
            // btnMethood
            // 
            this.btnMethood.Location = new System.Drawing.Point(31, 104);
            this.btnMethood.Name = "btnMethood";
            this.btnMethood.Size = new System.Drawing.Size(243, 23);
            this.btnMethood.TabIndex = 1;
            this.btnMethood.Text = "Классификация по методологии";
            this.btnMethood.UseVisualStyleBackColor = true;
            this.btnMethood.Click += new System.EventHandler(this.btnMethood_Click);
            // 
            // btnMission
            // 
            this.btnMission.Location = new System.Drawing.Point(31, 143);
            this.btnMission.Name = "btnMission";
            this.btnMission.Size = new System.Drawing.Size(243, 23);
            this.btnMission.TabIndex = 2;
            this.btnMission.Text = "Классификаиця по задачам";
            this.btnMission.UseVisualStyleBackColor = true;
            this.btnMission.Click += new System.EventHandler(this.btnMission_Click);
            // 
            // LanguageOntologySelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 188);
            this.Controls.Add(this.btnMission);
            this.Controls.Add(this.btnMethood);
            this.Controls.Add(this.choseLabel);
            this.Name = "LanguageOntologySelectionForm";
            this.Text = "Выбор онтологии";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label choseLabel;
        private System.Windows.Forms.Button btnMethood;
        private System.Windows.Forms.Button btnMission;
    }
}