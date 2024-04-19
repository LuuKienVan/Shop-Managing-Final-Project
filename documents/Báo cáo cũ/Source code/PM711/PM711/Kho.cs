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
    public partial class Kho : Form
    {
        public Kho()
        {
            InitializeComponent();
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Kho_Load(object sender, EventArgs e)
        {
            string connectString = "Data Source=LAPTOP-DTGRCF82\\SQLEXPRESS;Initial Catalog=QuanLy711;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectString);
            string query = "select * from SANPHAM";
            SqlCommand command = new SqlCommand(query, connect);
            connect.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            connect.Close();

            dgvKho.DataSource = dataTable;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            AddKho ak = new AddKho();
            this.Hide();
            ak.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SanPhamSapHetHan sanPhamSapHetHan = new SanPhamSapHetHan();
            this.Hide();
            sanPhamSapHetHan.ShowDialog();
            this.Show();
        }
    }
}
