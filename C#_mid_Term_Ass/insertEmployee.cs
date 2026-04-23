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
    public partial class insertEmployee : Form
    {
        public insertEmployee()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        string connectionString = "Data Source=DESKTOP-SHPCJHB;Initial Catalog=car_rental_management;Integrated Security=True;Encrypt=False";


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox1.Text == "" || textBox2.Text == "" ||
      textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO EMPLOYEES 
                        (EmployeeID, FirstName, LastName, PositionName, PhoneNumber, Salary)
                        VALUES 
                        (@id, @fname, @lname, @position, @phone, @salary)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", int.Parse(textBox6.Text));
                cmd.Parameters.AddWithValue("@fname", textBox1.Text);
                cmd.Parameters.AddWithValue("@lname", textBox2.Text);
                cmd.Parameters.AddWithValue("@position", textBox3.Text);
                cmd.Parameters.AddWithValue("@phone", textBox4.Text);
                cmd.Parameters.AddWithValue("@salary", decimal.Parse(textBox5.Text));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Employee inserted successfully!");
            }
            textBox6.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            this.Close();
            
        }
    }
}
