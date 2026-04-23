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
    public partial class DeleteRental : Form
    {
        public DeleteRental()
        {
            InitializeComponent();
        }

        //Anas connection
        string connectionString = "Data Source=DESKTOP-SHPCJHB;Initial Catalog=car_rental_management;Integrated Security=True;Encrypt=False";
        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox6.Text, out int rentalId))
            {
                MessageBox.Show("Please enter Rental ID");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string checkQuery = "SELECT COUNT(*) FROM RENTALS WHERE RentalID = @id AND ReturnDate IS NULL";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@id", rentalId);

                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Cannot delete: Rental is still active!");
                    return;
                }

                string deleteQuery = "DELETE FROM RENTALS WHERE RentalID = @id";
                SqlCommand deleteCmd = new SqlCommand(deleteQuery, con);
                deleteCmd.Parameters.AddWithValue("@id", rentalId);

                int rows = deleteCmd.ExecuteNonQuery();

                if (rows > 0)
                    MessageBox.Show("Rental deleted successfully!");
                else
                    MessageBox.Show("Rental not found!");
            }

            textBox6.Clear();
            this.Close();
        }
    }
}
