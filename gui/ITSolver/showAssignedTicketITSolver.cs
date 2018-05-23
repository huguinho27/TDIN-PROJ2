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
    public partial class showAssignedTicketITSolver : Form
    {
        public string name { get; set; }
        public string email { get; set; }
        public string solverid { get; set; }
        public string ticketId { get; set; }

        public showAssignedTicketITSolver()
        {
            InitializeComponent();
        }

        public void makeSubmitButtonUclickable()
        {
            submitButton.Enabled = false;
        }

        public void activateSubmitButton()
        {
            submitButton.Enabled = true;
        }

        public void makeSubmitIssueButtonUnclickable()
        {
            issueSubTicketButton.Enabled = false;
        }

        public void changeStatusText(string newText)
        {
            this.statusTextBox.Text = newText;
            statusTextBox.Enabled = false;
        }

        public void changeTitleText(string newText)
        {
            this.titleTextBox.Text = newText;
            titleTextBox.Enabled = false;
        }

        public void changeAuthorText(string newText)
        {
            authorTextBox.Enabled = false;
            authorTextBox.Text = newText;
        }

        public void changeDateText(string epochTime)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            double d = double.Parse(epochTime);
            DateTime t = dt.ToLocalTime().AddMilliseconds(d + 3600000);
            dateTextBox.Text = t.ToString();
            dateTextBox.Enabled = false;
        }

        public void changeDescriptionText(string newText)
        {
            this.descriptionTextBox.Text = newText;
            descriptionTextBox.Enabled = false;
        }

        public void changeAnswerText(string newText)
        {
            this.answerTextBox.Text = newText;
        }

        public void addSubTicket(string ID, string title, string status)
        {
            string[] row = { ID, title, status };
            subTicketsList.Items.Add(new ListViewItem(row));
        }

        public void makeAnswerTextBoxUnavailable()
        {
            answerTextBox.Enabled = false;
        }

        public void activateAnswerTextBox()
        {
            answerTextBox.Enabled = true;
        }

        private void issueSubTicketButton_Click(object sender, EventArgs e)
        {
            createSubTicket subticket = new createSubTicket();
            subticket.solverEmail = this.email;
            subticket.solverName = this.name;
            subticket.primaryTicketid = this.ticketId;
            subticket.ShowDialog();
            this.refreshButton_Click(sender, e);
        }

        public void makeRefreshButtonUnclickable()
        {
            this.refreshButton.Enabled = false;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RequestSecondaryQuestions request3 = new RequestSecondaryQuestions();
            request3.id = this.ticketId;

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
            bool ctrl = false;
            this.subTicketsList.Items.Clear();

            foreach (TroubleTicket ticket in response3.secondaryQuestions)
            {
                addSubTicket(ticket.id, ticket.title, ticket.state);
                if (ticket.state.Equals("waiting"))
                    ctrl = true;
            }

            if (ctrl)
            {
                makeSubmitButtonUclickable();
                makeAnswerTextBoxUnavailable();
            }
            else
            {
                activateAnswerTextBox();
                activateSubmitButton();
            }
        }

        private void subTicketsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            viewASubTicketITSolver wind = new viewASubTicketITSolver();

            RequestSingleSecondaryQuestion request = new RequestSingleSecondaryQuestion();
            request.id = this.subTicketsList.SelectedItems[0].SubItems[0].Text;

            ResponseSingleSecondaryQuestion response = (ResponseSingleSecondaryQuestion)WebRequestPost.makeRequest<ResponseSingleSecondaryQuestion>("/secondaryquestions/get", request);
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

            wind.changeAnswerText(response.answer);
            wind.changeDescriptionText(response.description);
            wind.changeStateText(response.state);
            wind.changeTitleText(response.title);
            wind.changeDateText(response.date);
            wind.ShowDialog();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (!answerTextBox.Text.Equals(""))
            {
                RequestSolveTicket request = new RequestSolveTicket();
                request.id = this.ticketId;
                request.answer = answerTextBox.Text;

                ResponseSolveTicket response = (ResponseSolveTicket)WebRequestPost.makeRequest<ResponseSolveTicket>("/troubletickets/solve", request);
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
                this.Hide();
            }
        }
    }
}
