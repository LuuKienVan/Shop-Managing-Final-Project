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

namespace PM711
{
    public partial class QuanLyDonOnline : Form
    {
        public QuanLyDonOnline()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvDonOnline.CurrentCell.RowIndex;
            dgvDonOnline.Rows.RemoveAt(rowIndex);
                            
        }

        private void QuanLyDonOnline_Load(object sender, EventArgs e)
        {
            string connectString = "Data Source=LAPTOP-DTGRCF82\\SQLEXPRESS;Initial Catalog=QuanLy711;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectString);
            string query = "EXEC random";
            SqlCommand command = new SqlCommand(query, connect);
            connect.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            connect.Close();

            dgvDonOnline.DataSource = dataTable;
        }

        private void dgvDonOnline_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
