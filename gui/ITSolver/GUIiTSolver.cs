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
    public partial class GUIiTSolver : Form
    {
        public GUIiTSolver()
        {
            InitializeComponent();
        }

        public void nameLabel_Click(object sender, EventArgs e)
        {

        }

        public void changeNameLabelText(string newText)
        {
            nameLabel.Text = newText;
        }

        public void changeDepartmentLabelText(string newText)
        {
            departmentLabel.Text = newText;
        }

        public void changeIDLabelText(string newText)
        {
            IDLabel.Text = newText;
        }

        public void addAssignedTicket(string ID, string title, string status)
        {
            string[] row = { ID, title, status };
            var listItem = new ListViewItem(row);
            assignedTicketsList.Items.Add(listItem);
        }

        public void addUnassignedTicket(string ID, string title, string status)
        {
            string[] row = { ID, title, status };
            var listItem = new ListViewItem(row);
            unassignedTicketsList.Items.Add(listItem);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void GUIiTSolver_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
