using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFit
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data_Access db = new Data_Access();

            int ID = db.VerifyUser(EmailTextBox.Text, PasswordTextBox.Text);
            // If ID = 0 that means no record exists with that email/password
            if (ID == 0)
            {
                MessageBox.Show("Invalid email/password combo");
            }
            // else close page and open home page
            else
            {

                HomeForm homeform = new HomeForm();
                homeform.Location = this.Location;
                homeform.StartPosition = FormStartPosition.Manual;
                homeform.Show();
                this.Close();
            }
            
            
            

         
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm temp = new RegistrationForm();
            temp.Region = this.Region;
            temp.Show();
           

        }

        private void ExitLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
