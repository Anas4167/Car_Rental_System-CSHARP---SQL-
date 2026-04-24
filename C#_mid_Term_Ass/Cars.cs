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
    public partial class Cars : Form
    {
        public Cars()
        {
            InitializeComponent();
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            LoadCars();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
   

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            insertCar insertCar = new insertCar();
            insertCar.FormClosed += (s, args) => LoadCars();
            insertCar.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;

                UpdateCar updateCar = new UpdateCar(
                    Convert.ToInt32(row.Cells["CarID"].Value),
                    row.Cells["CarName"].Value.ToString(),
                    row.Cells["Brand"].Value.ToString(),
                    row.Cells["Model"].Value.ToString(),
                    Convert.ToInt32(row.Cells["YearMade"].Value),
                    row.Cells["PlateNumber"].Value.ToString(),
                    row.Cells["PricePerDay"].Value.ToString(),
                    row.Cells["Status"].Value.ToString()
                );

                updateCar.FormClosed += (s, args) => LoadCars();

                updateCar.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteCar delCar = new DeleteCar();

            delCar.FormClosed += (s, args) => LoadCars();

            delCar.Show();
        }
        //Anas connection
        string connectionString = "Data Source=DESKTOP-SHPCJHB;Initial Catalog=car_rental_management;Integrated Security=True;Encrypt=False";

        private void LoadCars()
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
            LoadCars();
        }
    }
}
