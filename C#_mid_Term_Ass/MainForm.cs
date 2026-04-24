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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InsertCustomer inserCus = new InsertCustomer();
            inserCus.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoginForm inserLogin = new LoginForm();
            inserLogin.Show();
        }
    }
}
