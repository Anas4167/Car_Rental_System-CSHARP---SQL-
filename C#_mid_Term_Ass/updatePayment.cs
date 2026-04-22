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
        public updatePayment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(
                "Data Source=DESKTOP-0ID2UPP;Initial Catalog=Car_Rental_Management;Integrated Security=True;Encrypt=False"
            );

            string query = "UPDATE PAYMENTS SET RentalID=@RentalID, PaymentDate=@PaymentDate, PaymentMethod=@PaymentMethod, AmountPaid=@AmountPaid " +
                           "WHERE PaymentID=@PaymentID";

            SqlCommand cmd = new SqlCommand(query, cnn);

            // assign values with proper conversion
            cmd.Parameters.AddWithValue("@PaymentID", Convert.ToInt32(textBox1.Text));
            cmd.Parameters.AddWithValue("@RentalID", Convert.ToInt32(textBox2.Text));

            cmd.Parameters.AddWithValue("@PaymentDate", Convert.ToDateTime(textBox3.Text));
            cmd.Parameters.AddWithValue("@PaymentMethod", textBox4.Text);
            cmd.Parameters.AddWithValue("@AmountPaid", Convert.ToDecimal(textBox5.Text));

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            MessageBox.Show("Payment updated successfully!");
        }
    }
}
