using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PM711
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThanhToan tt = new ThanhToan();
            this.Hide();
            tt.ShowDialog();
            this.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DoanhThu doanhthu = new DoanhThu();
            this.Hide();
            doanhthu.ShowDialog();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            Kho kho = new Kho();
            this.Hide();
            kho.ShowDialog();
            this.Show();
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            NhaCungCap ncc = new NhaCungCap();
            this.Hide();
            ncc.ShowDialog();
            this.Show();
        }

        private void btnGiaoHang_Click(object sender, EventArgs e)
        {
            QuanLyDonOnline giaohang = new QuanLyDonOnline();
            this.Hide();
            giaohang.ShowDialog();
            this.Show();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            txtTenNV.Text = "Xin chào " + DangNhap.tenNV;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

    }
}
