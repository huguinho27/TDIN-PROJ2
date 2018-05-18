namespace WindowsFormsApp1
{
    partial class viewASubTicketITSolver
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
            this.answerTextBox = new System.Windows.Forms.TextBox();
            this.answerLabel = new System.Windows.Forms.Label();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.departmentTextBox = new System.Windows.Forms.TextBox();
            this.departmentLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // answerTextBox
            // 
            this.answerTextBox.Location = new System.Drawing.Point(165, 283);
            this.answerTextBox.Multiline = true;
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.Size = new System.Drawing.Size(534, 64);
            this.answerTextBox.TabIndex = 24;
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerLabel.Location = new System.Drawing.Point(75, 283);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(62, 20);
            this.answerLabel.TabIndex = 21;
            this.answerLabel.Text = "Answer";
            // 
            // statusTextBox
            // 
            this.statusTextBox.Location = new System.Drawing.Point(165, 115);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(110, 20);
            this.statusTextBox.TabIndex = 20;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(86, 115);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(56, 20);
            this.statusLabel.TabIndex = 19;
            this.statusLabel.Text = "Status";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(165, 194);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(534, 64);
            this.descriptionTextBox.TabIndex = 18;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(53, 194);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(89, 20);
            this.descriptionLabel.TabIndex = 17;
            this.descriptionLabel.Text = "Description";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(165, 152);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(534, 20);
            this.titleTextBox.TabIndex = 16;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(104, 152);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(38, 20);
            this.titleLabel.TabIndex = 15;
            this.titleLabel.Text = "Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(259, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 29);
            this.label1.TabIndex = 14;
            this.label1.Text = "View Secondary Question";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // departmentTextBox
            // 
            this.departmentTextBox.Location = new System.Drawing.Point(165, 77);
            this.departmentTextBox.Name = "departmentTextBox";
            this.departmentTextBox.Size = new System.Drawing.Size(110, 20);
            this.departmentTextBox.TabIndex = 26;
            // 
            // departmentLabel
            // 
            this.departmentLabel.AutoSize = true;
            this.departmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departmentLabel.Location = new System.Drawing.Point(48, 77);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(94, 20);
            this.departmentLabel.TabIndex = 25;
            this.departmentLabel.Text = "Department";
            // 
            // viewASubTicketITSolver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 383);
            this.Controls.Add(this.departmentTextBox);
            this.Controls.Add(this.departmentLabel);
            this.Controls.Add(this.answerTextBox);
            this.Controls.Add(this.answerLabel);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.label1);
            this.Name = "viewASubTicketITSolver";
            this.Text = "View Sub Ticket";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox answerTextBox;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox departmentTextBox;
        private System.Windows.Forms.Label departmentLabel;
    }
}