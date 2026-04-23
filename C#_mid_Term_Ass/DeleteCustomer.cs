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
    public partial class DeleteCustomer : Form
    {
        public DeleteCustomer()
        {
            InitializeComponent();
        }

        private void DeleteCustomer_Load(object sender, EventArgs e)
        {

        }

        string connectionString = "Data Source=DESKTOP-SHPCJHB;Initial Catalog=car_rental_management;Integrated Security=True;Encrypt=False";


        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox6.Text, out int customerId))
            {
                MessageBox.Show("Please enter Customer ID");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                
                string checkQuery = "SELECT COUNT(*) FROM RENTALS WHERE CustomerID = @id AND ReturnDate IS NULL";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@id", customerId);

                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Cannot delete: Customer currently has rented car!");
                    return;
                }

                
                string deleteQuery = "DELETE FROM CUSTOMERS WHERE CustomerID = @id";
                SqlCommand deleteCmd = new SqlCommand(deleteQuery, con);
                deleteCmd.Parameters.AddWithValue("@id", customerId);

                int rows = deleteCmd.ExecuteNonQuery();

                if (rows > 0)
                    MessageBox.Show("Customer deleted successfully!");
                else
                    MessageBox.Show("Customer not found!");
            }

            textBox6.Clear();
            this.Close();
        }
    }
}
