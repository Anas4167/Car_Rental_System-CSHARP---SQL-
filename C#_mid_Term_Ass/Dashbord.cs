using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__project_Term
{
    public partial class Dashbord : Form
    {
        public Dashbord()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(
      "Data Source=DESKTOP-0ID2UPP;Initial Catalog=Car_Rental_Management;Integrated Security=True;Encrypt=False"
  );

            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM CUSTOMERS", sqlConnection);

            int count = (int)cmd.ExecuteScalar();

            label2.Text =  count.ToString();

            sqlConnection.Close();

        }
    }
}
