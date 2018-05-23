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
        public string id { get; set; }

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
            ticketsList.Items.Add(new ListViewItem(row));
        }

        private void issueTicketButton_Click(object sender, EventArgs e)
        {
            createTicketWorker ticket = new createTicketWorker();
            ticket.name = this.name;
            ticket.email = this.email;
            ticket.ShowDialog();

            this.refreshButton_Click(sender, e);
        }

        private void WorkerGUI_Load(object sender, EventArgs e)
        {

        }

        private void WorkerGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void IDLabel_Click(object sender, EventArgs e)
        {

        }

        private void ticketsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RequestTroubleTicket request = new RequestTroubleTicket();
            request.id = this.ticketsList.SelectedItems[0].SubItems[0].Text;

            //Making the register request
            ResponseTroubleTicket response = (ResponseTroubleTicket)WebRequestPost.makeRequest<ResponseTroubleTicket>("/troubletickets/get", request);

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

            viewTicketWorker window = new viewTicketWorker();
            window.changeStatusText(response.state);
            window.changeTitleText(response.title);
            window.changeDescriptionText(response.description);
            window.changeAnswerText(response.answer);
            window.changeDateTextBox(response.date);
            window.changeSolverNameText(response.solverName);
            window.Show();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RequestUser request = new RequestUser();
            request.id = this.id;

            //Making the register request
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

            ticketsList.Items.Clear();
            foreach (TroubleTicket ticket in response.userTickets)
                this.addTickets(ticket.id, ticket.title, ticket.state);

        }
    }
}
