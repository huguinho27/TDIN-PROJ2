using EnterpriseWorker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class WorkerGUI : Form
    {
        public string name { get; set; }
        public string email { get; set; }

        public WorkerGUI()
        {
            InitializeComponent();
        }

        public void changeNameLabel(string newText)
        {
            nameLabel.Text = newText;
        }

        public void changeDepartmentLabel(string newText)
        {
            departmentLabel.Text = newText;
        }

        public void changeIDLabel(string newText)
        {
            IDLabel.Text = newText;
        }

        public void addTickets(string ID, string title, string status)
        {
            string[] row = { ID, title, status };
            var listItem = new ListViewItem(row);
            ticketsList.Items.Add(listItem);
        }

        private void issueTicketButton_Click(object sender, EventArgs e)
        {
            createTicketWorker ticket = new createTicketWorker();
            ticket.name = this.name;
            ticket.email = this.email;
            ticket.Show();
        }

        private void WorkerGUI_Load(object sender, EventArgs e)
        {

        }

        private void WorkerGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void IDLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
