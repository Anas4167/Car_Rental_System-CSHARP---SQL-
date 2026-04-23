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
    public partial class insertCar : Form
    {
        public insertCar()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=DESKTOP-SHPCJHB;Initial Catalog=car_rental_management;Integrated Security=True;Encrypt=False";

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox1.Text == "" || textBox2.Text == "" ||
               textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

           
            string status = "";
            if (radioButton1.Checked)
                status = "Available";
            else if (radioButton2.Checked)
                status = "Rented";
            else
            {
                MessageBox.Show("Please select status");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO CARS 
        (CarID, CarName, Brand, Model, YearMade, PlateNumber, PricePerDay, Status)
        VALUES 
        (@id, @name, @brand, @model, @year, @plate, @price, @status)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", int.Parse(textBox6.Text));
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@brand", textBox2.Text);
                cmd.Parameters.AddWithValue("@model", textBox3.Text);
                cmd.Parameters.AddWithValue("@year", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@plate", textBox5.Text);
                cmd.Parameters.AddWithValue("@price", decimal.Parse(textBox7.Text));
                cmd.Parameters.AddWithValue("@status", status);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Car inserted successfully!");
            }

           
            textBox6.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;

            this.Close();


        }
    }
}
