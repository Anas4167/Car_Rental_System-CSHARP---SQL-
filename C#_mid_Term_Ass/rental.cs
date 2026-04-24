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
    public partial class rental : Form
    {
        public rental()
        {
            InitializeComponent();
            button2.Visible = false;
            button5.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            LoadRentals();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button5.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button5.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReantalInser insertRental = new ReantalInser();
            insertRental.FormClosed += (s, args) => LoadRentals();
            insertRental.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;

                rentalUpdate updateRental = new rentalUpdate(
                    Convert.ToInt32(row.Cells["RentalID"].Value),
                    Convert.ToInt32(row.Cells["CustomerID"].Value),
                    Convert.ToInt32(row.Cells["CarID"].Value),
                    row.Cells["RentDate"].Value.ToString(),
                    row.Cells["ReturnDate"].Value?.ToString(),
                    row.Cells["TotalAmount"].Value.ToString()
                );

                updateRental.FormClosed += (s, args) => LoadRentals();

                updateRental.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteRental deleteRental = new DeleteRental();
            deleteRental.FormClosed += (s, args) => LoadRentals();
            deleteRental.Show();
        }


        //Anas connection
        string connectionString = "Data Source=DESKTOP-SHPCJHB;Initial Catalog=car_rental_management;Integrated Security=True;Encrypt=False";


        private void LoadRentals()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllRentals", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadRentals();

          
        }



        private void button6_Click(object sender, EventArgs e)
        {
           LoadRentals();
           
        }
    }
}
