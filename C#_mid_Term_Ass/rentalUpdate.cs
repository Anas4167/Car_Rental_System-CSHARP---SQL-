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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace C__project_Term
{
    public partial class rentalUpdate : Form
    {
        public rentalUpdate(int rentalId, int customerId, int carId, string rentDate, string returnDate, string total)
        {
            InitializeComponent();
            textBox1.Text = rentalId.ToString();
            textBox2.Text = customerId.ToString();
            textBox3.Text = carId.ToString();
            textBox4.Text = rentDate;
            textBox5.Text = returnDate;
            textBox6.Text = total;
        }

        //Anas connection
        string connectionString = "Data Source=DESKTOP-SHPCJHB;Initial Catalog=car_rental_management;Integrated Security=True;Encrypt=False";


        private void button1_Click(object sender, EventArgs e)
        {

           


        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ||
                    textBox4.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("Please fill all required fields");
                    return;
                }

                if (!int.TryParse(textBox1.Text, out int rentalId) ||
                    !int.TryParse(textBox2.Text, out int customerId) ||
                    !int.TryParse(textBox3.Text, out int carId))
                {
                    MessageBox.Show("Invalid IDs");
                    return;
                }

                if (!decimal.TryParse(textBox6.Text, out decimal total))
                {
                    MessageBox.Show("Invalid amount");
                    return;
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string checkQuery = @"SELECT COUNT(*) FROM RENTALS 
                   WHERE CarID = @carId 
                   AND ReturnDate IS NULL 
                   AND RentalID != @rid";

                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@carId", carId);
                    checkCmd.Parameters.AddWithValue("@rid", rentalId);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Car is already rented!");
                        return;
                    }

                    string query = @"UPDATE RENTALS 
              SET CustomerID=@cid,
                  CarID=@carid,
                  RentDate=@rentDate,
                  ReturnDate=@returnDate,
                  TotalAmount=@total
              WHERE RentalID=@rid";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@rid", rentalId);
                    cmd.Parameters.AddWithValue("@cid", customerId);
                    cmd.Parameters.AddWithValue("@carid", carId);
                    cmd.Parameters.AddWithValue("@rentDate", DateTime.Parse(textBox4.Text));

                    if (string.IsNullOrWhiteSpace(textBox5.Text))
                        cmd.Parameters.AddWithValue("@returnDate", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@returnDate", DateTime.Parse(textBox5.Text));

                    cmd.Parameters.AddWithValue("@total", total);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                        MessageBox.Show("Rental updated successfully!");
                    else
                        MessageBox.Show("No record updated! Check RentalID.");
                }

                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid date format. Please enter correct date values.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }
        }
    }
}
