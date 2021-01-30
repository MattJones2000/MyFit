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
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {

        }

        private Point NewChildLocation()
        {
            return new Point(this.Left + 200, this.Top + 200);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WorkoutForm form = new WorkoutForm();
            form.Location = NewChildLocation();
            form.StartPosition = FormStartPosition.Manual;
            form.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
