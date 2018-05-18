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
        public string solverid { get; set; }

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
            RequestUser request = new RequestUser();
            request.id = this.solverid;
            
            //Requests trouble tickets
            ResponseUser response = (ResponseUser)WebRequestPost.makeRequest<ResponseUser>("/users/get", request);
            if (response.error.Equals("1"))
                MessageBox.Show(
                    response.message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else if (!response.error.Equals("0"))
                MessageBox.Show(
                    "What??",
                    "Seriously, what?",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);

            assignedTicketsList.Items.Clear();
            unassignedTicketsList.Items.Clear();

            //Update both trouble ticket list
            foreach (TroubleTicket ticket in response.solverTickets)
                addAssignedTicket(ticket.id, ticket.title, ticket.state);
            foreach (TroubleTicket ticket in response.unassignedTickets)
                addUnassignedTicket(ticket.id, ticket.title, ticket.state);
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
            //--------------------------------------------
            //Assigns the clicked trouble ticket to solver
            //--------------------------------------------
            RequestAssign request = new RequestAssign();
            request.id = this.unassignedTicketsList.SelectedItems[0].SubItems[0].Text;
            request.solverId = this.solverid;
            request.solverName = this.name;

            ResponseAssign response = (ResponseAssign)WebRequestPost.makeRequest<ResponseAssign>("/troubletickets/assign", request);
            if (response.error.Equals("1"))
                MessageBox.Show(
                    response.message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else if (!response.error.Equals("0"))
                MessageBox.Show(
                    "What??",
                    "Seriously, what?",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
            //--------------------------------------------

            //Creates new window
            showAssignedTicketITSolver wind = new showAssignedTicketITSolver();
            wind.name = this.name;
            wind.email = this.email;
            wind.solverid = this.solverid;
            wind.ticketId = this.unassignedTicketsList.SelectedItems[0].SubItems[0].Text;
            bool ctrl = true;

            //--------------------------------------------
            //Request information for the clicked trouble ticket
            //--------------------------------------------
            RequestTroubleTicket request2 = new RequestTroubleTicket();
            request2.id = this.unassignedTicketsList.SelectedItems[0].SubItems[0].Text;

            ResponseTroubleTicket response2 = (ResponseTroubleTicket)WebRequestPost.makeRequest<ResponseTroubleTicket>("/troubletickets/get", request2);
            if (response2.error.Equals("1"))
                MessageBox.Show(
                    response2.message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else if (!response2.error.Equals("0"))
                MessageBox.Show(
                    "What??",
                    "Seriously, what?",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
            //--------------------------------------------

            wind.changeAnswerText(response2.answer);
            wind.changeDescriptionText(response2.description);
            wind.changeStatusText(response2.state);
            wind.changeTitleText(response2.title);

            //--------------------------------------------
            //Request for secondary questions
            //--------------------------------------------
            RequestSecondaryQuestions request3 = new RequestSecondaryQuestions();
            request3.id = this.unassignedTicketsList.SelectedItems[0].SubItems[0].Text;

            ResponseSecondaryQuestions response3 = (ResponseSecondaryQuestions)WebRequestPost.makeRequest<ResponseSecondaryQuestions>("/troubletickets/getsecondaryquestions", request3);
            if (response3.error.Equals("1"))
                MessageBox.Show(
                    response3.message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else if (!response3.error.Equals("0"))
                MessageBox.Show(
                    "What??",
                    "Seriously, what?",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
            //--------------------------------------------

            foreach(TroubleTicket ticket in response3.secondaryQuestions) {
                wind.addSubTicket(ticket.id, ticket.title, ticket.state);
                if (ticket.state.Equals("unsolved"))
                    ctrl = true;
             }
            if (ctrl == true)
                wind.makeSubmitButtonUclickable();
            wind.ShowDialog();

        }

        private void assignedTicketsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Creates new window
            showAssignedTicketITSolver wind = new showAssignedTicketITSolver();
            wind.name = this.name;
            wind.email = this.email;
            wind.solverid = this.solverid;
            wind.ticketId = this.assignedTicketsList.SelectedItems[0].SubItems[0].Text;
            bool ctrl = false;

            //--------------------------------------------------
            //Request information for the clicked trouble ticket
            //--------------------------------------------------
            RequestTroubleTicket request2 = new RequestTroubleTicket();
            request2.id = this.assignedTicketsList.SelectedItems[0].SubItems[0].Text;

            ResponseTroubleTicket response2 = (ResponseTroubleTicket)WebRequestPost.makeRequest<ResponseTroubleTicket>("/troubletickets/get", request2);
            if (response2.error.Equals("1"))
                MessageBox.Show(
                    response2.message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else if (!response2.error.Equals("0"))
                MessageBox.Show(
                    "What??",
                    "Seriously, what?",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
            //--------------------------------------------

            wind.changeAnswerText(response2.answer);
            wind.changeDescriptionText(response2.description);
            wind.changeStatusText(response2.state);
            wind.changeTitleText(response2.title);

            //--------------------------------------------
            //Request for secondary questions
            //--------------------------------------------
            RequestSecondaryQuestions request3 = new RequestSecondaryQuestions();
            request3.id = this.assignedTicketsList.SelectedItems[0].SubItems[0].Text;

            ResponseSecondaryQuestions response3 = (ResponseSecondaryQuestions)WebRequestPost.makeRequest<ResponseSecondaryQuestions>("/troubletickets/getsecondaryquestions", request3);
            if (response3.error.Equals("1"))
                MessageBox.Show(
                    response3.message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else if (!response3.error.Equals("0"))
                MessageBox.Show(
                    "What??",
                    "Seriously, what?",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
            //--------------------------------------------

            foreach (TroubleTicket ticket in response3.secondaryQuestions)
            {
                wind.addSubTicket(ticket.id, ticket.title, ticket.state);
                if (ticket.state.Equals("waiting"))
                    ctrl = true;
            }

            if (ctrl == true)
            {
                wind.makeSubmitButtonUclickable();
                wind.makeAnswerTextBoxUnavailable();
            }
            wind.ShowDialog();
            this.refreshButton_Click(sender,e);
        }
    }
}
