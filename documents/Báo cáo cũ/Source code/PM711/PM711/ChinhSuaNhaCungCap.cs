using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM711
{
    public partial class ChinhSuaNhaCungCap : Form
    {
        public ChinhSuaNhaCungCap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (cbMaNCC.Text != "" && txtTenNCC.Text != "" && cbSPCungCap.Text != "" && txtSDT.Text != "" && txtDiaChi.Text != "" && txtDanhGia.Text != "")
            {
                string maNCC = cbMaNCC.Text;
                string tenNCC = txtTenNCC.Text;
                string SDT = txtSDT.Text;
                string diaChi = txtDiaChi.Text;
                int danhGia = int.Parse(txtDanhGia.Text);
                string spCungCap = cbSPCungCap.Text;

                string connectString = "Data Source=LAPTOP-DTGRCF82\\SQLEXPRESS;Initial Catalog=QuanLy711;Integrated Security=True";
                SqlConnection connect = new SqlConnection(connectString);

                string query = "update NHACUNGCAP set tenNCC = N' " + tenNCC + " ', sdtNCC = ' " + SDT + " ', diachiNCC = N'" + diaChi + "', ratingNcc =  " + danhGia + " , cacSPCungCap = N'" + spCungCap + "' where maNCC = '" + maNCC + "'";
                SqlCommand command = new SqlCommand(query, connect);
                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);

                this.Close();
            }
            else
            {
                lbThongBao.Text = "Vui lòng nhập đầy đủ thông tin!";
            }
        }

        private void ChinhSuaNhaCungCap_Load(object sender, EventArgs e)
        {
            lbThongBao.Text = "";

            string connectString = "Data Source=LAPTOP-DTGRCF82\\SQLEXPRESS;Initial Catalog=QuanLy711;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectString);

            string query = "select DISTINCT cacSPCungCap from NHACUNGCAP";
            SqlCommand command = new SqlCommand(query, connect);


            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);

            cbSPCungCap.DataSource = dataTable;
            cbSPCungCap.DisplayMember = "cacSPCungCap";
            cbSPCungCap.Text = "Chọn loại sản phẩm";



            query = "select maNCC from NHACUNGCAP";
            command = new SqlCommand(query, connect);

            dataTable = new DataTable();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);

            cbMaNCC.DataSource = dataTable;
            cbMaNCC.DisplayMember = "maNCC";
            cbMaNCC.Text = "Chọn mã nhà cung cấp";
            connect.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
