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
    public partial class rentalUpdate : Form
    {
        public rentalUpdate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
            SqlConnection cnn = new SqlConnection(
                "Data Source=DESKTOP-0ID2UPP;Initial Catalog=Car_Rental_Management;Integrated Security=True;Encrypt=False"
            );

            string query = "UPDATE RENTALS SET CustomerID=@CustomerID, CarID=@CarID, RentDate=@RentDate, ReturnDate=@ReturnDate, TotalAmount=@TotalAmount WHERE RentalID=@RentalID";

            SqlCommand cmd = new SqlCommand(query, cnn);

            // assign values from textboxes
            cmd.Parameters.AddWithValue("@RentalID", textBox1.Text);
            cmd.Parameters.AddWithValue("@CustomerID", textBox2.Text);
            cmd.Parameters.AddWithValue("@CarID", textBox3.Text);
            cmd.Parameters.AddWithValue("@RentDate", textBox4.Text);
            cmd.Parameters.AddWithValue("@ReturnDate", textBox5.Text);
            cmd.Parameters.AddWithValue("@TotalAmount", textBox6.Text);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            MessageBox.Show("Rental updated successfully!");
        

    }
    }
}
