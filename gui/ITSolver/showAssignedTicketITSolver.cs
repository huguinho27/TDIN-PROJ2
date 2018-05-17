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

        public void changeStatusText(string newText)
        {
            this.statusTextBox.Text = newText;
        }

        public void changeTitleText(string newText)
        {
            this.titleTextBox.Text = newText;
        }

        public void changeDescriptionText(string newText)
        {
            this.descriptionTextBox.Text = newText;
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
    }
}
