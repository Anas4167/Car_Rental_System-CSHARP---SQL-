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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C__project_Term
{
    public partial class ReantalInser : Form
    {
        public ReantalInser()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(
                 "Data Source=DESKTOP-0ID2UPP;Initial Catalog=Car_Rental_Management;Integrated Security=True;Encrypt=False"
             );

            string query = "INSERT INTO RENTALS (RentalID, CustomerID, CarID, RentDate, ReturnDate, TotalAmount) " +
                           "VALUES (@RentalID, @CustomerID, @CarID, @RentDate, @ReturnDate, @TotalAmount)";

            SqlCommand cmd = new SqlCommand(query, conn);

            // assign textbox values
            cmd.Parameters.AddWithValue("@RentalID", textBox1.Text);
            cmd.Parameters.AddWithValue("@CustomerID", textBox2.Text);
            cmd.Parameters.AddWithValue("@CarID", textBox3.Text);
            cmd.Parameters.AddWithValue("@RentDate", textBox4.Text);
            cmd.Parameters.AddWithValue("@ReturnDate", textBox5.Text);
            cmd.Parameters.AddWithValue("@TotalAmount", textBox6.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Rental added successfully!");


        }
    }
}
