using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnterpriseWorker
{
    public partial class createTicketWorker : Form
    {
        public string name { get; set; }
        public string email { get; set; }

        public createTicketWorker()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (titleTextBox.Text == "" || descriptionTextBox.Text == "")
            {
                MessageBox.Show(
                    "Title or description are empty: ",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            RequestCreateTicket request = new RequestCreateTicket();
            request.name = this.name;
            request.email = this.email;
            request.title = titleTextBox.Text;
            request.description = descriptionTextBox.Text;

            ResponseCreateTicket response = (ResponseCreateTicket)WebRequestPost.makeRequest<ResponseCreateTicket>("/troubletickets/add", request);

            if (response.error.Equals("0"))
                MessageBox.Show(
                    "Successfully created trouble ticket: " + response.insertedId,
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (response.error.Equals("1"))
                MessageBox.Show(
                    response.message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            this.Hide();

        }
    }
}
