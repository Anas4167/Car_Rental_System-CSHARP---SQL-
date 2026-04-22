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
    public partial class insertPayment : Form
    {
        public insertPayment()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(
              "Data Source=DESKTOP-0ID2UPP;Initial Catalog=Car_Rental_Management;Integrated Security=True;Encrypt=False"
              );

            string query = "INSERT INTO PAYMENTS (PaymentID, RentalID, PaymentDate, PaymentMethod, AmountPaid) " +
                           "VALUES (@PaymentID, @RentalID, @PaymentDate, @PaymentMethod, @AmountPaid)";

            SqlCommand cmd = new SqlCommand(query, conn);

            // assign textbox values
            cmd.Parameters.AddWithValue("@PaymentID", textBox1.Text);
            cmd.Parameters.AddWithValue("@RentalID", textBox2.Text);
            cmd.Parameters.AddWithValue("@PaymentDate", textBox3.Text);
            cmd.Parameters.AddWithValue("@PaymentMethod", textBox4.Text);
            cmd.Parameters.AddWithValue("@AmountPaid", textBox5.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Payment added successfully!");
        }
    }
}
