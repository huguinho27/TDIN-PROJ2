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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            Common.Register reg = new Common.Register();
            reg.Show();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            RequestLogin request = new RequestLogin();
            request.email = emailTextBox.Text;
            request.password = passwordTextBox.Text;

            //Making the register request
            ResponseLogin response = (ResponseLogin)WebRequestPost.makeRequest<ResponseLogin>("/auth/login", request);
              
            if (response.error.Equals("1"))
                MessageBox.Show(
                    response.message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else if(!response.error.Equals("0"))
                MessageBox.Show(
                    "What??",
                    "Seriously, what?",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
            else
            {
                if (response.department.Equals("1"))
                {
                    GUIiTSolver itsolver = new GUIiTSolver();
                    itsolver.changeNameLabelText(response.name);
                    itsolver.changeDepartmentLabelText("I.T - Solver");
                    itsolver.changeIDLabelText(response.id);
                    foreach (TroubleTicket ticket in response.solverTickets)
                        itsolver.addAssignedTicket(ticket._id, ticket.title, ticket.state);
                    foreach (TroubleTicket ticket in response.unassignedTickets)
                        itsolver.addUnassignedTicket(ticket._id, ticket.title, ticket.state);
                    itsolver.Show();
                }
                else if (response.department.Equals("2"))
                {
                    WorkerGUI workerGui = new WorkerGUI();
                    workerGui.name = response.name;
                    workerGui.email = response.email;
                    workerGui.changeNameLabel(response.name);
                    workerGui.changeDepartmentLabel("Enterprise Worker");
                    workerGui.changeIDLabel(response.id);
                    foreach (TroubleTicket ticket in response.userTickets)
                        workerGui.addTickets(ticket._id, ticket.title, ticket.state);
                    workerGui.Show();
                }
            }
            this.Hide();
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                submitButton_Click(sender, e);
            }
        }
    }
}
