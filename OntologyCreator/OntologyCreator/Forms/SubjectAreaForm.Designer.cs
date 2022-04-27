namespace OntologyCreator
{
    partial class SubjectAreaForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubjectAreaForm));
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbGoal = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.gbInterview = new System.Windows.Forms.GroupBox();
            this.lblInterview = new System.Windows.Forms.Label();
            this.gbInterview.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Image = global::OntologyCreator.Properties.Resources.back;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(337, 166);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(71, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Назад";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "Какая предметная область онтологии? *\r\n";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 49);
            this.label2.TabIndex = 2;
            this.label2.Text = "Для каких целей будет использоваться данная онтология?";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "Кем будет использоваться данная онтология?";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(165, 6);
            this.tbName.MaxLength = 500;
            this.tbName.Multiline = true;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(243, 47);
            this.tbName.TabIndex = 2;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // tbGoal
            // 
            this.tbGoal.Location = new System.Drawing.Point(165, 59);
            this.tbGoal.MaxLength = 1000;
            this.tbGoal.Multiline = true;
            this.tbGoal.Name = "tbGoal";
            this.tbGoal.Size = new System.Drawing.Size(243, 47);
            this.tbGoal.TabIndex = 3;
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(165, 113);
            this.tbUser.MaxLength = 1000;
            this.tbUser.Multiline = true;
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(243, 47);
            this.tbUser.TabIndex = 4;
            // 
            // btnNext
            // 
            this.btnNext.Image = global::OntologyCreator.Properties.Resources.right_arrow;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(12, 166);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(319, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Далее";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // gbInterview
            // 
            this.gbInterview.Controls.Add(this.lblInterview);
            this.gbInterview.Location = new System.Drawing.Point(12, 195);
            this.gbInterview.Name = "gbInterview";
            this.gbInterview.Size = new System.Drawing.Size(396, 69);
            this.gbInterview.TabIndex = 8;
            this.gbInterview.TabStop = false;
            this.gbInterview.Text = "Интервью";
            // 
            // lblInterview
            // 
            this.lblInterview.Location = new System.Drawing.Point(7, 20);
            this.lblInterview.Name = "lblInterview";
            this.lblInterview.Size = new System.Drawing.Size(383, 43);
            this.lblInterview.TabIndex = 0;
            // 
            // SubjectAreaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 271);
            this.Controls.Add(this.gbInterview);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.tbGoal);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubjectAreaForm";
            this.Text = "Предметная область";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SubjectArea_FormClosing);
            this.gbInterview.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbGoal;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox gbInterview;
        private System.Windows.Forms.Label lblInterview;
    }
}

