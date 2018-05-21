using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            RequestRegister request = new RequestRegister();
            request.email = emailBox.Text;
            request.name = usernameBox.Text;
            request.department = (departmentComboBox.SelectedIndex + 1).ToString();
            request.password = passwordBox.Text;
            request.confirmPassword = password2Box.Text;

            //Making the register request
            ResponseRegister response = (ResponseRegister)WebRequestPost.makeRequest<ResponseRegister>("/auth/register", request);

            if (response.error.Equals("0"))
                MessageBox.Show(
                    "User registered with id: " + response.insertedId,
                    "Success", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if(response.error.Equals("1"))
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
            this.Hide();
        }
    }
}
