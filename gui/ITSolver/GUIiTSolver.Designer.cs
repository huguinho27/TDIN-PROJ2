namespace WindowsFormsApp1
{
    partial class GUIiTSolver
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
            this.assignedTicketsLabel = new System.Windows.Forms.Label();
            this.unassignedTicketsLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.departmentLabel = new System.Windows.Forms.Label();
            this.IDLabel = new System.Windows.Forms.Label();
            this.assignedTicketsList = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.unassignedTicketsList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(667, 127);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(61, 30);
            this.refreshButton.TabIndex = 9;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // assignedTicketsLabel
            // 
            this.assignedTicketsLabel.AutoSize = true;
            this.assignedTicketsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignedTicketsLabel.Location = new System.Drawing.Point(56, 140);
            this.assignedTicketsLabel.Name = "assignedTicketsLabel";
            this.assignedTicketsLabel.Size = new System.Drawing.Size(163, 20);
            this.assignedTicketsLabel.TabIndex = 5;
            this.assignedTicketsLabel.Text = "Ticket assigned to me";
            // 
            // unassignedTicketsLabel
            // 
            this.unassignedTicketsLabel.AutoSize = true;
            this.unassignedTicketsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unassignedTicketsLabel.Location = new System.Drawing.Point(396, 140);
            this.unassignedTicketsLabel.Name = "unassignedTicketsLabel";
            this.unassignedTicketsLabel.Size = new System.Drawing.Size(148, 20);
            this.unassignedTicketsLabel.TabIndex = 10;
            this.unassignedTicketsLabel.Text = "Unassigned Tickets";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(56, 75);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(51, 20);
            this.nameLabel.TabIndex = 12;
            this.nameLabel.Text = "Name";
            // 
            // departmentLabel
            // 
            this.departmentLabel.AutoSize = true;
            this.departmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departmentLabel.Location = new System.Drawing.Point(56, 22);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(138, 29);
            this.departmentLabel.TabIndex = 14;
            this.departmentLabel.Text = "Department";
            // 
            // IDLabel
            // 
            this.IDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDLabel.Location = new System.Drawing.Point(375, 31);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.IDLabel.Size = new System.Drawing.Size(357, 20);
            this.IDLabel.TabIndex = 22;
            this.IDLabel.Text = "ID";
            this.IDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // assignedTicketsList
            // 
            this.assignedTicketsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Title,
            this.Status});
            this.assignedTicketsList.Location = new System.Drawing.Point(60, 163);
            this.assignedTicketsList.Name = "assignedTicketsList";
            this.assignedTicketsList.Size = new System.Drawing.Size(328, 225);
            this.assignedTicketsList.TabIndex = 23;
            this.assignedTicketsList.UseCompatibleStateImageBehavior = false;
            this.assignedTicketsList.View = System.Windows.Forms.View.Details;
            this.assignedTicketsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.assignedTicketsList_MouseDoubleClick);
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
            // unassignedTicketsList
            // 
            this.unassignedTicketsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.unassignedTicketsList.Location = new System.Drawing.Point(400, 163);
            this.unassignedTicketsList.Name = "unassignedTicketsList";
            this.unassignedTicketsList.Size = new System.Drawing.Size(328, 225);
            this.unassignedTicketsList.TabIndex = 24;
            this.unassignedTicketsList.UseCompatibleStateImageBehavior = false;
            this.unassignedTicketsList.View = System.Windows.Forms.View.Details;
            this.unassignedTicketsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.unassignedTicketsList_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 107;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Title";
            this.columnHeader2.Width = 107;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 107;
            // 
            // GUIiTSolver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 424);
            this.Controls.Add(this.unassignedTicketsList);
            this.Controls.Add(this.assignedTicketsList);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.departmentLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.unassignedTicketsLabel);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.assignedTicketsLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GUIiTSolver";
            this.Text = "GUIiTSolver";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GUIiTSolver_FormClosed);
            this.Load += new System.EventHandler(this.GUIiTSolver_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label assignedTicketsLabel;
        private System.Windows.Forms.Label unassignedTicketsLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label departmentLabel;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.ListView assignedTicketsList;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ListView unassignedTicketsList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}