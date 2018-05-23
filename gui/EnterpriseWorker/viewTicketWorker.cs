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
    public partial class viewTicketWorker : Form
    {
        public viewTicketWorker()
        {
            InitializeComponent();
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

        public void changeDescriptionText(string newText)
        {
            this.descriptionTextBox.Text = newText;
            descriptionTextBox.Enabled = false;
        }

        public void changeAnswerText(string newText)
        {
            this.answerTextBox.Text = newText;
        }

        public void changeDateTextBox(string epochTime)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            double d = double.Parse(epochTime);
            DateTime t = dt.ToLocalTime().AddMilliseconds(d+3600000);
            dateTextBox.Text = t.ToString();
            dateTextBox.Enabled = false;
        }

        public void changeSolverNameText(string newText)
        {
            if (newText == null)
                solverNameTextBox.Text = "Unassigned";
            else
                solverNameTextBox.Text = newText;
            solverNameTextBox.Enabled = false;
        }
    }
}
