using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__project_Term
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button3.Visible = true;
            button2.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button1.Visible = false;
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DeleteEmployee delEm = new DeleteEmployee();
            delEm.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            UpdateEmployee updateEm = new UpdateEmployee();
            updateEm.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            insertEmployee inserEm = new insertEmployee();
            inserEm.Show();
        }
    }
}
