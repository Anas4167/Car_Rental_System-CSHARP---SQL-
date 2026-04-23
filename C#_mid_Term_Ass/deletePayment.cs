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
    public partial class deletePayment : Form
    {
        public deletePayment()
        {
            InitializeComponent();
        }

        //Anas connection
        string connectionString = "Data Source=DESKTOP-SHPCJHB;Initial Catalog=car_rental_management;Integrated Security=True;Encrypt=False";

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox6.Text, out int paymentId))
            {
                MessageBox.Show("Please enter Payment ID");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

               
                string query = "DELETE FROM PAYMENTS WHERE PaymentID = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", paymentId);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    MessageBox.Show("Payment deleted successfully!");
                else
                    MessageBox.Show("Payment not found!");
            }

            textBox6.Clear();
            this.Close();
        }
    }
}
