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
    public partial class updatePayment : Form
    {
        public updatePayment(int id, int rentalId, string date, string method, string amount)
        {
            InitializeComponent();
            textBox1.Text = id.ToString();       
            textBox2.Text = rentalId.ToString(); 
            textBox3.Text = date;                 
            textBox4.Text = method;               
            textBox5.Text = amount;
        }

        //Anas connection
        string connectionString = "Data Source=DESKTOP-SHPCJHB;Initial Catalog=car_rental_management;Integrated Security=True;Encrypt=False";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ||
                textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int paymentId) ||
                !int.TryParse(textBox2.Text, out int rentalId))
            {
                MessageBox.Show("Invalid IDs");
                return;
            }

            if (!decimal.TryParse(textBox5.Text, out decimal amount))
            {
                MessageBox.Show("Invalid amount");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                
                string checkQuery = "SELECT COUNT(*) FROM RENTALS WHERE RentalID = @rid";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@rid", rentalId);

                int exists = (int)checkCmd.ExecuteScalar();

                if (exists == 0)
                {
                    MessageBox.Show("Rental ID does not exist!");
                    return;
                }

                
                string query = @"UPDATE PAYMENTS
                                 SET RentalID=@rid,
                                     PaymentDate=@date,
                                     PaymentMethod=@method,
                                     AmountPaid=@amount
                                 WHERE PaymentID=@pid";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@pid", paymentId);
                cmd.Parameters.AddWithValue("@rid", rentalId);
                cmd.Parameters.AddWithValue("@date", DateTime.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@method", textBox4.Text);
                cmd.Parameters.AddWithValue("@amount", amount);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    MessageBox.Show("Payment updated successfully!");
                else
                    MessageBox.Show("Update failed!");
            }

            this.Close();

        }
    }
}
