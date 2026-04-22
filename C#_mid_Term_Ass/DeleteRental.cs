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
    public partial class DeleteRental : Form
    {
        public DeleteRental()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                        SqlConnection cnn = new SqlConnection(
                "Data Source=DESKTOP-0ID2UPP;Initial Catalog=Car_Rental_Management;Integrated Security=True;Encrypt=False"
            );

            string query = "DELETE FROM RENTALS WHERE RentalID=@RentalID";

            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@RentalID", textBox6.Text);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            MessageBox.Show("Rental deleted successfully!");
        }
    }
}
