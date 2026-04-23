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
    public partial class Employees : Form
    {
        public Employees()
        {

            InitializeComponent();
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            LoadEmployee();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            button3.Visible = true;
            button2.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button1.Visible = false;
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DeleteEmployee delEm = new DeleteEmployee();

            delEm.FormClosed += (s, args) => LoadEmployee();

            delEm.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;

                UpdateEmployee updateEm = new UpdateEmployee(
                    Convert.ToInt32(row.Cells["EmployeeID"].Value),
                    row.Cells["FirstName"].Value.ToString(),
                    row.Cells["LastName"].Value.ToString(),
                    row.Cells["PositionName"].Value.ToString(),
                    row.Cells["PhoneNumber"].Value.ToString(),
                    row.Cells["Salary"].Value.ToString()
                );

                updateEm.FormClosed += (s, args) => LoadEmployee();

                updateEm.Show();
            }
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            insertEmployee inserEm = new insertEmployee();

            inserEm.FormClosed += (s, args) => LoadEmployee(); 

            inserEm.Show();

        }

        //Anas connection
        string connectionString = "Data Source=DESKTOP-SHPCJHB;Initial Catalog=car_rental_management;Integrated Security=True;Encrypt=False";

        private void LoadEmployee()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM EMPLOYEES";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //LoadEmployee();
           
        }
    }
}
