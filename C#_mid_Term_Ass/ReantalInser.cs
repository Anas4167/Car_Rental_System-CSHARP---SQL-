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
    public partial class ReantalInser : Form
    {
        public ReantalInser()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadCustomers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT CustomerID, FirstName + ' ' + LastName AS Name FROM CUSTOMERS";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow row = dt.NewRow();
                row["CustomerID"] = 0;
                row["Name"] = "choose Customer";
                dt.Rows.InsertAt(row, 0);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "CustomerID";
            }
        }
        private void LoadCars()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                string query = "SELECT CarID, CarName FROM CARS WHERE Status='Available'";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow row = dt.NewRow();
                row["CarID"] = 0;
                row["CarName"] = "choose Car";
                dt.Rows.InsertAt(row, 0);

                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "CarName";
                comboBox2.ValueMember = "CarID";
            }
        }

        //Anas connection
        string connectionString = "Data Source=DESKTOP-SHPCJHB;Initial Catalog=car_rental_management;Integrated Security=True;Encrypt=False";


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox6.Text == "" ||
        comboBox1.SelectedValue == null || comboBox2.SelectedValue == null)
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            
            if (!int.TryParse(textBox1.Text, out int rentalId))
            {
                MessageBox.Show("Invalid Rental ID");
                return;
            }

            
            if (!decimal.TryParse(textBox6.Text, out decimal totalAmount))
            {
                MessageBox.Show("Invalid Total Amount");
                return;
            }

            
            int customerId = Convert.ToInt32(comboBox1.SelectedValue);
            int carId = Convert.ToInt32(comboBox2.SelectedValue);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

               
                string checkQuery = "SELECT COUNT(*) FROM RENTALS WHERE CarID=@carId AND ReturnDate IS NULL";

                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@carId", carId);

                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Car is already rented!");
                    return;
                }

               
                string query = @"INSERT INTO RENTALS
                                (RentalID, CustomerID, CarID, RentDate, ReturnDate, TotalAmount)
                                VALUES
                                (@rid, @cid, @carid, @rentDate, @returnDate, @total)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@rid", rentalId);
                cmd.Parameters.AddWithValue("@cid", customerId);
                cmd.Parameters.AddWithValue("@carid", carId);

               
                cmd.Parameters.AddWithValue("@rentDate", dateTimePicker1.Value);

                if (dateTimePicker2.Checked)
                    cmd.Parameters.AddWithValue("@returnDate", dateTimePicker2.Value);
                else
                    cmd.Parameters.AddWithValue("@returnDate", DBNull.Value);

                cmd.Parameters.AddWithValue("@total", totalAmount);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Rental inserted successfully!");
            }

            this.Close();


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ReantalInser_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadCars();
        }
    }
}
