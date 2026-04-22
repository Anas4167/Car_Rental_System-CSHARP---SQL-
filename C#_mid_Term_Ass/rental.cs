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
            ReantalInser form2 = new ReantalInser();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rentalUpdate rentalUpdate = new rentalUpdate();
            rentalUpdate.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteRental deleteRental = new DeleteRental();
            deleteRental.Show();
        }

       
      
        string connectionString = "Data Source=DESKTOP-0ID2UPP;Initial Catalog=Car_Rental_Management;Integrated Security=True;Encrypt=False";

        private void LoadRentals()
        {
            SqlConnection con = new SqlConnection(connectionString);

            string query = "SELECT * FROM RENTALS";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
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
