using DTO;
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

namespace PM711
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            lbTienKhachDua.Text = ThanhToan.tienKhachDua.ToString() + " VND";
            lbTenNV.Text = ThanhToan.tenNV;
            lbMaKH.Text = ThanhToan.maKH;
            lbNgayBan.Text = ThanhToan.ngayBan;
            lbTongTien.Text = ThanhToan.tongTien.ToString() + " VND";

            int tienThoi = ThanhToan.tienKhachDua - ThanhToan.tongTien;
            if (tienThoi < 0)
            {
                lbKhachTraThieu.Text = "Khách trả không đủ tiền!";
            }    
            lbTienTraKhach.Text = tienThoi.ToString() + " VND";

            List<Bill> billList = new List<Bill>();
            billList = ThanhToan.billList;

            foreach (Bill bill in billList)
            {
                string tenSP = bill.getTenSanPham();
                int soLuong = bill.getSoLuong();
                int gia = bill.getGia();
                int giamGia = bill.getGiamGia();
                int thanhTien = bill.getThanhTien();
                dgvThanhToan.Rows.Add(tenSP, soLuong, gia, giamGia, thanhTien);
            }

            int tt = ThanhToan.tongTien;
            int tkd = ThanhToan.tienKhachDua;
            int ttk = tienThoi;
            string nl = lbNgayBan.Text;
            string mkh = lbMaKH.Text;
            string mnv = DangNhap.maNV;

            string connectString = "Data Source=LAPTOP-DTGRCF82\\SQLEXPRESS;Initial Catalog=QuanLy711;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectString);

            string query = "insert into HOADON values('', '" + tt + "', '" + tkd + "', '" + ttk + "', '" + nl + "', '" + mkh + "', '" + mnv + "')";
            SqlCommand command = new SqlCommand(query, connect);
            connect.Open();
            command.ExecuteNonQuery();

            foreach (Bill bill in billList)
            {
                string tenSP = bill.getTenSanPham();
                int soLuong = bill.getSoLuong();
                query = "select maSP from SANPHAM where tenSP = N'" + tenSP + "'";
                command = new SqlCommand(query, connect);
                string maSP = command.ExecuteScalar().ToString();

                query = "update SANPHAM set soLuong = soLuong - " + soLuong + " where maSP = '" + maSP + "'";
                command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();
            }
            connect.Close();
        }

        private void lbTienKhachDua_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbTongTien_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
