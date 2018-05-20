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
        }

        public void changeTitleText(string msg)
        {
            this.titleTextBox.Text = msg;
        }

        public void changeDescriptionText(string msg)
        {
            this.descriptionTextBox.Text = msg;
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
