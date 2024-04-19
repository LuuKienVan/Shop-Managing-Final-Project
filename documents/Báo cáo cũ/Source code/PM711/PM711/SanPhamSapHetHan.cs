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
    public partial class SanPhamSapHetHan : Form
    {
        public SanPhamSapHetHan()
        {
            InitializeComponent();
        }

        private void SanPhamSapHetHan_Load(object sender, EventArgs e)
        {
            string connectString = "Data Source=LAPTOP-DTGRCF82\\SQLEXPRESS;Initial Catalog=QuanLy711;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectString);
            string query = "SELECT * FROM SANPHAM WHERE datediff(day, getdate(), hsd) <= 10 ";
            SqlCommand command = new SqlCommand(query, connect);
            connect.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            connect.Close();

            dgvSPSapHetHan.DataSource = dataTable;
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
