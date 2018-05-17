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
    }
}
