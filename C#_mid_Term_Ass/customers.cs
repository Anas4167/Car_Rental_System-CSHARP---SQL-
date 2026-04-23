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
    public partial class customers : Form
    {
        public customers()
        {
            InitializeComponent();
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            LoadCustomer();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
      

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            button2.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteCustomer deleteCustomer = new DeleteCustomer();
            deleteCustomer.FormClosed += (s, args) => LoadCustomer();
            deleteCustomer.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;

                UpdateCustomer updateCustomer = new UpdateCustomer(
                    Convert.ToInt32(row.Cells["CustomerID"].Value),
                    row.Cells["FirstName"].Value.ToString(),
                    row.Cells["LastName"].Value.ToString(),
                    row.Cells["PhoneNumber"].Value.ToString(),
                    row.Cells["Email"].Value.ToString(),
                    row.Cells["Password"].Value.ToString(),
                    row.Cells["Address"].Value.ToString()
                );

                updateCustomer.FormClosed += (s, args) => LoadCustomer();

                updateCustomer.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InsertCustomer insertCustomer = new InsertCustomer();
            insertCustomer.FormClosed += (s, args) => LoadCustomer();
            insertCustomer.Show();
        }


        //Anas connection
        string connectionString = "Data Source=DESKTOP-SHPCJHB;Initial Catalog=car_rental_management;Integrated Security=True;Encrypt=False";

        
        private void LoadCustomer()
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = "SELECT * FROM CUSTOMERS";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
           

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadCustomer();
        }
    }
}
