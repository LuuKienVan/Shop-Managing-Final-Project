using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO.Pattern.Proxy.FormProxy;
using Pattern.Command;

namespace PM711
{
    public partial class TrangChu : Form
    {
        Command thanhToanCmD;
        Command doanhThuCmD;
        Command khoCmD;
        Command nhaCungCapCmD;
        Command giaoHangCmD;

        public TrangChu()
        {
            InitializeComponent();
            thanhToanCmD = new ThanhToanCommand();
            doanhThuCmD = new DoanhThuCommand();
            khoCmD = new KhoCommand();
            nhaCungCapCmD = new NhaCungCapCommand();
            giaoHangCmD = new GiaoHangCommand();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thanhToanCmD.execute();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            doanhThuCmD.execute();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            khoCmD.execute();
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            nhaCungCapCmD.execute();
        }

        private void btnGiaoHang_Click(object sender, EventArgs e)
        {
            giaoHangCmD.execute();
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
