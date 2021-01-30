using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyFit
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
           
        }
   
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Data_Access db = new Data_Access();

            int verificationNumber = db.CheckEmail(RegEmailTxt.Text);

            if (RegEmailTxt.Text == "" || RegPasswordConfirmTxt.Text == "" || RegPasswordTxt.Text == "")
            {
                MessageBox.Show("Please fill out required fields");
            }
            else if (verificationNumber == 1)
            {
                MessageBox.Show("That email has already been registered with another acccount");
            }

            else if (RegPasswordTxt.Text.Length < 5)
            {
                MessageBox.Show("Password must be at least 5 characters");
            }

            else if (RegPasswordTxt.Text != RegPasswordConfirmTxt.Text) 
            {
                MessageBox.Show("Passwords do not match, please try again");
            }

            else
            {
                // Takes all textbox info and adds it to database
                db.AddUser(RegFNameTxt.Text, RegLNameTxt.Text, RegEmailTxt.Text, RegPasswordTxt.Text);

                MessageBox.Show("Account successfully created!");

                // Clears the fields
                RegFNameTxt.Text = "";
                RegLNameTxt.Text = "";
                RegEmailTxt.Text = "";
                RegPasswordTxt.Text = "";
                RegPasswordConfirmTxt.Text = "";
                this.Close();
            }
            
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
  
}
