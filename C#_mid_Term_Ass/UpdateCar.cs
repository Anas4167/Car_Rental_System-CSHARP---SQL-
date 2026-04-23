using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C__project_Term
{
    public partial class UpdateCar : Form
    {
        public UpdateCar(int id, string name, string brand, string model, int year, string plate, string price, string status)
        {
            InitializeComponent();
            textBox6.Text = id.ToString();
            textBox1.Text = name;
            textBox2.Text = brand;
            textBox3.Text = model;
            textBox4.Text = year.ToString();
            textBox5.Text = plate;
            textBox7.Text = price;

            
            if (status == "Active")
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
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

            // 🔥 Get status
            string status = "";
            if (radioButton1.Checked)
                status = "Active";
            else if (radioButton2.Checked)
                status = "NotActive";
            else
            {
                MessageBox.Show("Select status");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"UPDATE CARS 
                         SET CarName=@name,
                             Brand=@brand,
                             Model=@model,
                             YearMade=@year,
                             PlateNumber=@plate,
                             PricePerDay=@price,
                             Status=@status
                         WHERE CarID=@id";

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

                MessageBox.Show("Car updated successfully!");
            }

            this.Close();
        }
    }
}
