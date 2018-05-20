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
    public partial class showAssignedTicket : Form
    {
        public string secondaryQuestionID;

        public showAssignedTicket()
        {
            InitializeComponent();
        }

        public void changeStateText(string msg)
        {
            this.statusTextBox.Text = msg;
        }

        public void changeTitleText(string msg)
        {
            this.titleTextBox.Text = msg;
        }

        public void changeDescriptionText(string msg)
        {
            this.descriptionTextBox.Text = msg;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (answerTextBox.Text.Equals(""))
            {
                MessageBox.Show(
                    "Answer Text Box is empty, please answer the question",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            RequestSolveSecondaryQuestion request = new RequestSolveSecondaryQuestion();
            request.id = this.secondaryQuestionID;
            request.answer = this.answerTextBox.Text;

            ResponseSolveSecondaryQuestion response = (ResponseSolveSecondaryQuestion)WebRequestPost.makeRequest<ResponseSolveSecondaryQuestion>("/secondaryquestions/solve", request);
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
