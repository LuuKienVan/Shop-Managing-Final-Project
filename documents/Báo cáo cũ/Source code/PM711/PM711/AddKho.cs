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
    public partial class AddKho : Form
    {
        public AddKho()
        {
            InitializeComponent();
        }

        public void loadData()
        {
            string connectString = "Data Source=LAPTOP-DTGRCF82\\SQLEXPRESS;Initial Catalog=QuanLy711;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectString);

            string query = "select DISTINCT loai from SANPHAM";
            SqlCommand command = new SqlCommand(query, connect);

            
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);

            cbLoaiSP.DataSource = dataTable;
            cbLoaiSP.DisplayMember = "loai";
            cbLoaiSP.Text = "Chọn loại sản phẩm";
            


            query = "select DISTINCT maNCC from NHACUNGCAP";
            command = new SqlCommand(query, connect);
            
            dataTable = new DataTable();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);

            cbMaNCC.DataSource = dataTable;
            cbMaNCC.DisplayMember = "maNCC";
            cbMaNCC.Text = "Chọn mã nhà cung cấp";
            connect.Close();

        }

        private void AddKho_Load(object sender, EventArgs e)
        {
            loadData();
            lbThongBao.Text = "";
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTenSP.Text != "" && txtSoLuong.Text != "" && cbLoaiSP.Text != "" && dtpHSD.Text != "" && txtGiaBan.Text != "" && txtGiaBan.Text != "" && cbMaNCC.Text != "")
            {
                string tenSP = txtTenSP.Text;
                int soLuong = int.Parse(txtSoLuong.Text);
                string loaiSP = cbLoaiSP.Text;
                string HSD = dtpHSD.Text;
                int giaBan = int.Parse(txtGiaBan.Text);
                int giaNhap = int.Parse(txtGiaNhap.Text);
                string maNCC = cbMaNCC.Text;

                string connectString = "Data Source=LAPTOP-DTGRCF82\\SQLEXPRESS;Initial Catalog=QuanLy711;Integrated Security=True";
                SqlConnection connect = new SqlConnection(connectString);

                string query = "insert into SANPHAM values('', N'" + tenSP + "', " + soLuong + ", N'" + loaiSP + "', '" + HSD + "', " + giaBan + ", " + giaNhap + ", '" + maNCC + "')";
                SqlCommand command = new SqlCommand(query, connect);
                connect.Open();
                command.ExecuteNonQuery();
                connect.Close();

                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);

                this.Close();
            }
            else
            {
                lbThongBao.Text = "Vui lòng nhập đầy đủ thông tin!";
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpHSD_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbThongBao_Click(object sender, EventArgs e)
        {

        }
    }
}
