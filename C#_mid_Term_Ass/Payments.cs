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
    public partial class Payments: Form
    {
        public Payments()
        {
            InitializeComponent();
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
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

                        button4.Visible = true;
            button5.Visible = true;
            button1.Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Check if an instance of insertPayment is already active
            OpenForm(new insertPayment());

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenForm(new updatePayment());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenForm(new deletePayment());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
