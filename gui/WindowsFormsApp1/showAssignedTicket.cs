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
        public bool solved;
        public string answerText;

        public showAssignedTicket()
        {
            InitializeComponent();
        }

        public void unableStateText()
        {
            this.statusTextBox.Enabled = false;
            statusTextBox.Enabled = false;
        }

        public void changeDateText(string epochTime)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            double d = double.Parse(epochTime);
            DateTime t = dt.ToLocalTime().AddMilliseconds(d + 3600000);
            dateTextBox.Text = t.ToString();
            dateTextBox.Enabled = false;
        }

        public void changeSolverNameText(string newText)
        {
            this.solverNameTextBox.Text = newText;
            this.solverNameTextBox.Enabled = false;
        }

        public void unableTitleText()
        {
            this.titleTextBox.Enabled = false;
        }

        public void unableDescriptionText()
        {
            this.descriptionTextBox.Enabled = false;
        }

        public void unableAnswerText()
        {
            this.answerTextBox.Enabled = false;
        }

        public void changeStateText(string msg)
        {
            this.statusTextBox.Text = msg;
            statusTextBox.Enabled = false;
        }

        public void changeTitleText(string msg)
        {
            this.titleTextBox.Text = msg;
            titleTextBox.Enabled = false;
        }

        public void changeDescriptionText(string msg)
        {
            this.descriptionTextBox.Text = msg;
            descriptionTextBox.Enabled = false;
        }

        public void changeAnswerText(string msg)
        {
            this.answerTextBox.Text = msg;
        }

        public void deactivateSubmitButton()
        {
            this.submitButton.Enabled = false;
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
            this.solved = true;
            this.answerText = this.answerTextBox.Text;
            this.Hide();

        }
    }
}
