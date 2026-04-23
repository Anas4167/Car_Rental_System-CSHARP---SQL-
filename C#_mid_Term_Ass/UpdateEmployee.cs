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
using System.Xml.Linq;

namespace C__project_Term
{
    public partial class UpdateEmployee : Form
    {
        public UpdateEmployee(int id, string fname, string lname, string position, string phone, string salary)
        {
            InitializeComponent();
            textBox6.Text = id.ToString();
            textBox1.Text = fname;
            textBox2.Text = lname;
            textBox3.Text = position;
            textBox4.Text = phone;
            textBox5.Text = salary;
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
                string query = @"UPDATE EMPLOYEES 
                         SET FirstName=@fname, 
                             LastName=@lname, 
                             PositionName=@position, 
                             PhoneNumber=@phone, 
                             Salary=@salary
                         WHERE EmployeeID=@id";

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

                MessageBox.Show("Employee updated successfully!");
            }

            this.Close();
        }
    }
}
