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
    public partial class Payments : Form
    {



        public Payments()
        {
            InitializeComponent();

            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;

            LoadPayment();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void OpenForm(Form childForm)
        {
            childForm.StartPosition = FormStartPosition.CenterScreen;
            childForm.Show();
        }

        private void LoadPayment()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM PAYMENTS";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }
        //Anas connection
        string connectionString = "Data Source=DESKTOP-SHPCJHB;Initial Catalog=car_rental_management;Integrated Security=True;Encrypt=False";

        private void button1_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            button2.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //inser payment
            insertPayment inserPay = new insertPayment();
            inserPay.FormClosed += (s, args) => LoadPayment(); //aoutamatic
                                                               //loading
            inserPay.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;

                updatePayment updatePay = new updatePayment(
                    Convert.ToInt32(row.Cells["PaymentID"].Value),
                    Convert.ToInt32(row.Cells["RentalID"].Value),
                    row.Cells["PaymentDate"].Value.ToString(),
                    row.Cells["PaymentMethod"].Value.ToString(),
                    row.Cells["AmountPaid"].Value.ToString()
                );

                updatePay.FormClosed += (s, args) => LoadPayment();

                updatePay.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deletePayment delPay = new deletePayment();
            delPay.FormClosed += (s, args) => LoadPayment();
            delPay.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadPayment();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // You can leave this empty or remove if not used
        }
    }
}