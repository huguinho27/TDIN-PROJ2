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
    public partial class viewASubTicketITSolver : Form
    {
        public viewASubTicketITSolver()
        {
            InitializeComponent();
            departmentTextBox.Text = "Department";
            departmentTextBox.Enabled = false;
        }

        public void changeStateText(string newText)
        {
            this.statusTextBox.Text = newText;
            this.statusTextBox.Enabled = false;
        }

        public void changeTitleText(string newText)
        {
            this.titleTextBox.Text = newText;
            this.titleTextBox.Enabled = false;
        }

        public void changeDescriptionText(string newText)
        {
            this.descriptionTextBox.Text = newText;
            this.descriptionTextBox.Enabled = false;
        }

        public void changeAnswerText(string newText)
        {
            this.answerTextBox.Text = newText;
        }

        public void changeDateText(string epochTime)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            double d = double.Parse(epochTime);
            DateTime t = dt.ToLocalTime().AddMilliseconds(d + 3600000);
            dateTextBox.Text = t.ToString();
            dateTextBox.Enabled = false;
        }

    }
}
