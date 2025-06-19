using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace project.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usarname = textUsername.Text;
            string password = textPassword.Text;



            if (usarname == "admin" && password == "admin123")
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CourseForm courseForm = new CourseForm();
                courseForm.Show();
                this.Hide();

            }

            else
            {
                MessageBox.Show("invaild Username or Password .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoginForm_Load(object sender, EventArgs e)
            {
                //throw new NotImplementedException();
            }

            private void label2_Click(object sender, EventArgs e)
            {
                //throw new NotImplementedException();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
