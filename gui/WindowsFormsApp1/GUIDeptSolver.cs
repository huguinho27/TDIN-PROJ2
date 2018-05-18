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
    public partial class GUIDeptSolver : Form
    {
        public GUIDeptSolver()
        {
            InitializeComponent();
        }

        public void loadTickets()
        {
            RequestTroubleTicket request2 = new RequestTroubleTicket();
            request2.id = this.assignedTicketsList.SelectedItems[0].SubItems[0].Text;

            ResponseTroubleTicket response2 = (ResponseTroubleTicket)WebRequestPost.makeRequest<ResponseTroubleTicket>("/troubletickets/get", request2);
            if (response2.error.Equals("1"))
                MessageBox.Show(
                    response2.message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else if (!response2.error.Equals("0"))
                MessageBox.Show(
                    "What??",
                    "Seriously, what?",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
        }
    }
}
