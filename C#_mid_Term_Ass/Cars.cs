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
    public partial class Cars : Form
    {
        public Cars()
        {
            InitializeComponent();
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
        }
        private void OpenForm(Form childForm)
        {


            childForm.StartPosition = FormStartPosition.CenterScreen;
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            button2.Visible = true;
            button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenForm(new insertCar());
        }
    }
}
