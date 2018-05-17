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
        public string name { get; set; }
        public string email { get; set; }
        public string id { get; set; }

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
            assignedTicketsList.Items.Add(new ListViewItem(row));
        }

        public void addUnassignedTicket(string ID, string title, string status)
        {
            string[] row = { ID, title, status };
            unassignedTicketsList.Items.Add(new ListViewItem(row));
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void GUIiTSolver_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void GUIiTSolver_Load(object sender, EventArgs e)
        {

        }

        private void unassignedTicketsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Resquest assign
            showAssignedTicketITSolver wind = new showAssignedTicketITSolver();
            wind.name = this.name;
            wind.email = this.email;
            wind.solverid = this.id;
            wind.ticketId = this.unassignedTicketsList.SelectedItems[0].SubItems[0].Text;
            bool ctrl = false;
            //request GET? ou vem no anterior?
            //wind.changeAnswerText(response.answer);
            //wind.changeDescriptionText(response.description);
            //wind.changeStatusText(response.state);
            //wind.changeTitleText(response.title);
            /*foreach(TroubleTicket ticket in response.subtickets) {
                wind.addSubTicket(ticket._id, ticket.title, ticket.state);
                if (ticket.state,Equals("unsolved")
                    ctrl = true;
             }*/
            if (ctrl == true)
                wind.makeSubmitButtonUclickable();
            wind.Show();

        }
    }
}
