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

        //Anas connection
        string connectionString = "Data Source=DESKTOP-SHPCJHB;Initial Catalog=car_rental_management;Integrated Security=True;Encrypt=False";

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ||
              textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

     
            if (!int.TryParse(textBox1.Text, out int rentalId) ||
                !int.TryParse(textBox2.Text, out int customerId) ||
                !int.TryParse(textBox3.Text, out int carId))
            {
                MessageBox.Show("Invalid ID(s)");
                return;
            }

           
            if (!decimal.TryParse(textBox6.Text, out decimal totalAmount))
            {
                MessageBox.Show("Invalid Total Amount");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

             
                string checkQuery = "SELECT COUNT(*) FROM RENTALS WHERE CarID = @carId AND ReturnDate IS NULL";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@carId", carId);

                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Car is already rented!");
                    return;
                }

               
                string query = @"INSERT INTO RENTALS
                (RentalID, CustomerID, CarID, RentDate, ReturnDate, TotalAmount)
                VALUES
                (@rid, @cid, @carid, @rentDate, @returnDate, @total)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@rid", rentalId);
                cmd.Parameters.AddWithValue("@cid", customerId);
                cmd.Parameters.AddWithValue("@carid", carId);
                cmd.Parameters.AddWithValue("@rentDate", (textBox4.Text));
                cmd.Parameters.AddWithValue("@returnDate",
                    string.IsNullOrEmpty(textBox5.Text) ? (object)DBNull.Value : DateTime.Parse(textBox5.Text));
                cmd.Parameters.AddWithValue("@total", totalAmount);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Rental inserted successfully!");
            }

         
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            this.Close();


        }
    }
}
