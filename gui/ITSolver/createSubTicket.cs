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
    public partial class createSubTicket : Form
    {
        public string primaryTicketid { get; set; }
        public string solverEmail { get; set; }
        public string solverName { get; set; }

        public createSubTicket()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            RequestCreateSecondaryTicket request = new RequestCreateSecondaryTicket();
            request.email = this.solverEmail;
            request.description = this.descriptionTextBox.Text;
            request.name = this.solverName;
            request.title = titleTextBox.Text;
            request.troubleTicketId = this.primaryTicketid;

            ResponseCreateSecondaryTicket response = (ResponseCreateSecondaryTicket)WebRequestPost.makeRequest<ResponseCreateSecondaryTicket>("/secondaryquestions/add", request);
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
