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

        //Anas connection
        string connectionString = "Data Source=DESKTOP-SHPCJHB;Initial Catalog=car_rental_management;Integrated Security=True;Encrypt=False";

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(
                connectionString

             );

            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM CUSTOMERS", sqlConnection);

            int count = (int)cmd.ExecuteScalar();

            label2.Text =  count.ToString();

            sqlConnection.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(
               connectionString

            );

            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM CARS", sqlConnection);

            int count = (int)cmd.ExecuteScalar();

            label3.Text = count.ToString();

            sqlConnection.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(
               connectionString

            );

            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM CUSTOMERS", sqlConnection);

            int count = (int)cmd.ExecuteScalar();

            label5.Text = count.ToString();

            sqlConnection.Close();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(
               connectionString

            );

            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM CARS", sqlConnection);

            int count = (int)cmd.ExecuteScalar();

            label7.Text = count.ToString();

            sqlConnection.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(
               connectionString

            );

            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM RENTALS", sqlConnection);

            int count = (int)cmd.ExecuteScalar();

            label10.Text = count.ToString();

            sqlConnection.Close();
        }
    }
}
