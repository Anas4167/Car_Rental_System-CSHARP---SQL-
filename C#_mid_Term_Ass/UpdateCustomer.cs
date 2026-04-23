using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace C__project_Term
{
    public partial class UpdateCustomer : Form
    {
        public UpdateCustomer(int id, string fname, string lname, string phone, string email, string password, string address)
        {
            InitializeComponent();
            textBox6.Text = id.ToString();
            textBox1.Text = fname;
            textBox2.Text = lname;
            textBox3.Text = phone;
            textBox4.Text = email;
            textBox5.Text = password;
            textBox7.Text = address;
        }

        string connectionString = "Data Source=DESKTOP-SHPCJHB;Initial Catalog=car_rental_management;Integrated Security=True;Encrypt=False";

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ||
              textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"UPDATE CUSTOMERS 
                         SET FirstName=@fname,
                             LastName=@lname,
                             PhoneNumber=@phone,
                             Email=@email,
                             Password=@pass,
                             Address=@address
                         WHERE CustomerID=@id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", int.Parse(textBox6.Text));
                cmd.Parameters.AddWithValue("@fname", textBox1.Text);
                cmd.Parameters.AddWithValue("@lname", textBox2.Text);
                cmd.Parameters.AddWithValue("@phone", textBox3.Text);
                cmd.Parameters.AddWithValue("@email", textBox4.Text);
                cmd.Parameters.AddWithValue("@pass", textBox5.Text);
                cmd.Parameters.AddWithValue("@address", textBox7.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Customer updated successfully!");
            }

            this.Close();
        }
    }
}
