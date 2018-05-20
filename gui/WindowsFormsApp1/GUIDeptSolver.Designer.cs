namespace WindowsFormsApp1
{
    partial class GUIDeptSolver
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
            this.refreshButton = new System.Windows.Forms.Button();
            this.ticketsLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.assignedTicketsList = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(634, 85);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(66, 36);
            this.refreshButton.TabIndex = 15;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // ticketsLabel
            // 
            this.ticketsLabel.AutoSize = true;
            this.ticketsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketsLabel.Location = new System.Drawing.Point(81, 101);
            this.ticketsLabel.Name = "ticketsLabel";
            this.ticketsLabel.Size = new System.Drawing.Size(59, 20);
            this.ticketsLabel.TabIndex = 12;
            this.ticketsLabel.Text = "Tickets";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(260, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 33);
            this.label2.TabIndex = 16;
            this.label2.Text = "Department Solver";
            // 
            // assignedTicketsList
            // 
            this.assignedTicketsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Title,
            this.Status});
            this.assignedTicketsList.Location = new System.Drawing.Point(85, 124);
            this.assignedTicketsList.Name = "assignedTicketsList";
            this.assignedTicketsList.Size = new System.Drawing.Size(615, 203);
            this.assignedTicketsList.TabIndex = 24;
            this.assignedTicketsList.UseCompatibleStateImageBehavior = false;
            this.assignedTicketsList.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 107;
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 107;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 107;
            // 
            // GUIDeptSolver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 360);
            this.Controls.Add(this.assignedTicketsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.ticketsLabel);
            this.Name = "GUIDeptSolver";
            this.Text = "GUIanotherDeptSolver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GUIDeptSolver_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label ticketsLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView assignedTicketsList;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Status;
    }
}