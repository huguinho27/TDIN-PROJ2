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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            Common.Register reg = new Common.Register();
            reg.Show();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            RequestLogin request = new RequestLogin();
            request.email = emailTextBox.Text;
            request.password = passwordTextBox.Text;

            //Making the register request
            ResponseLogin response = (ResponseLogin)WebRequestPost.makeRequest<ResponseLogin>("/auth/login", request);

            if (response.error.Equals("0"))
                MessageBox.Show(
                    "User registered with id: " + response.insertedId,
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (response.error.Equals("1"))
                MessageBox.Show(
                    response.message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
                MessageBox.Show(
                    "What??",
                    "Seriously, what?",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
        }
    }
}
