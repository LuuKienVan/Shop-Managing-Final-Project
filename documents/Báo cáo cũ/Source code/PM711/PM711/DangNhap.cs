using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace PM711
{
    public partial class DangNhap : Form
    {
        public static string tenNV = "";
        public static string maNV = "";
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            maNV = txtMaNV.Text;
            string matKhau = txtMatKhau.Text;

            string connectString = "Data Source=LAPTOP-DTGRCF82\\SQLEXPRESS;Initial Catalog=QuanLy711;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectString);
            string query = "select * from NHANVIEN where maNV='" + maNV + "' and matKhau='" + matKhau + "'";
            SqlCommand command = new SqlCommand(query, connect);
            connect.Open();
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            
            if (data.Rows.Count > 0)
            {
                query = "select tenNV from NHANVIEN where maNV = '" + maNV + "'";
                command = new SqlCommand(query, connect);
                
                tenNV = (string)command.ExecuteScalar();
                connect.Close();

                TrangChu home = new TrangChu();
                this.Hide();
                home.ShowDialog();
                this.Show();
                txtMaNV.Text = "";
                txtMatKhau.Text = "";
            }
            else
            {
                MessageBox.Show("Nhập sai mã nhân viên hoặc mật khẩu!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát máy?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
