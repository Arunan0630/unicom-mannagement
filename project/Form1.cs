using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
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
                }

                else
                {
                    MessageBox.Show("invaild Username or Password .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
