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
    public partial class DeleteCar : Form
    {
        public DeleteCar()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=DESKTOP-SHPCJHB;Initial Catalog=car_rental_management;Integrated Security=True;Encrypt=False";

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox6.Text, out int carId))
            {
                MessageBox.Show("Please enter Car ID");
                return;
            }

            //int carId = int.Parse(textBox6.Text);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();


                string checkQuery = "SELECT COUNT(*) FROM RENTALS WHERE CarID = @id AND ReturnDate IS NULL";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@id", carId);

                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Cannot delete: Car is currently rented!");
                    return;
                }

              
                string deleteQuery = "DELETE FROM CARS WHERE CarID = @id";
                SqlCommand deleteCmd = new SqlCommand(deleteQuery, con);
                deleteCmd.Parameters.AddWithValue("@id", carId);

                int rows = deleteCmd.ExecuteNonQuery();

                if (rows > 0)
                    MessageBox.Show("Car deleted successfully!");
                else
                    MessageBox.Show("Car not found!");
            }

            textBox6.Clear();
            this.Close();

        }
    }
}
