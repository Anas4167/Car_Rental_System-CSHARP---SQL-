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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel3.BringToFront();
            form_load(new Dashbord());

        }
        public void form_load(object formObj)
        {
            if (this.panel2.Controls.Count > 0)
            {
                this.panel2.Controls.RemoveAt(0);
            }
            Form f = formObj as Form;
            if (f == null)
            {
                MessageBox.Show("The provided object is not a Form.", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(f);
            this.panel2.Tag = f;
            f.Show();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            
            form_load(new rental());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form_load(new customers());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form_load(new Cars());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form_load(new Employees());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            form_load(new Payments());
        }

        private void Dahbord_Click(object sender, EventArgs e)
        {
            form_load(new Dashbord());
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
