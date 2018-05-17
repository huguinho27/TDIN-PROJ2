namespace WindowsFormsApp1
{
    partial class WorkerGUI
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.ticketsLabel = new System.Windows.Forms.Label();
            this.issueTicketButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.ticketsList = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IDLabel = new System.Windows.Forms.Label();
            this.departmentLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ticketsLabel
            // 
            this.ticketsLabel.AutoSize = true;
            this.ticketsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketsLabel.Location = new System.Drawing.Point(72, 124);
            this.ticketsLabel.Name = "ticketsLabel";
            this.ticketsLabel.Size = new System.Drawing.Size(140, 20);
            this.ticketsLabel.TabIndex = 0;
            this.ticketsLabel.Text = "My Trouble Tickets";
            // 
            // issueTicketButton
            // 
            this.issueTicketButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issueTicketButton.Location = new System.Drawing.Point(76, 334);
            this.issueTicketButton.Name = "issueTicketButton";
            this.issueTicketButton.Size = new System.Drawing.Size(130, 42);
            this.issueTicketButton.TabIndex = 3;
            this.issueTicketButton.Text = "+ Issue a Ticket";
            this.issueTicketButton.UseVisualStyleBackColor = true;
            this.issueTicketButton.Click += new System.EventHandler(this.issueTicketButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(625, 105);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(66, 36);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // ticketsList
            // 
            this.ticketsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Title,
            this.Status});
            this.ticketsList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.ticketsList.Location = new System.Drawing.Point(76, 147);
            this.ticketsList.Name = "ticketsList";
            this.ticketsList.Size = new System.Drawing.Size(615, 171);
            this.ticketsList.TabIndex = 18;
            this.ticketsList.UseCompatibleStateImageBehavior = false;
            // 
            // IDLabel
            // 
            this.IDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDLabel.Location = new System.Drawing.Point(428, 29);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(263, 20);
            this.IDLabel.TabIndex = 21;
            this.IDLabel.Text = "ID";
            this.IDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.IDLabel.Click += new System.EventHandler(this.IDLabel_Click);
            // 
            // departmentLabel
            // 
            this.departmentLabel.AutoSize = true;
            this.departmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departmentLabel.Location = new System.Drawing.Point(72, 20);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(138, 29);
            this.departmentLabel.TabIndex = 20;
            this.departmentLabel.Text = "Department";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(73, 66);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(51, 20);
            this.nameLabel.TabIndex = 19;
            this.nameLabel.Text = "Name";
            // 
            // WorkerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 386);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.departmentLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.ticketsList);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.issueTicketButton);
            this.Controls.Add(this.ticketsLabel);
            this.Name = "WorkerGUI";
            this.Text = "WorkerGUI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WorkerGUI_FormClosed);
            this.Load += new System.EventHandler(this.WorkerGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ticketsLabel;
        private System.Windows.Forms.Button issueTicketButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ListView ticketsList;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Label departmentLabel;
        private System.Windows.Forms.Label nameLabel;
    }
}