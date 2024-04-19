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
using DAO;
using Pattern.Decorator;

namespace PM711
{
    public partial class HoaDon : Form
    {
        List<Product> billList = ThanhToan.billList;
        int tienThoi = ThanhToan.tienKhachDua - (int)ThanhToan.hdDecorator.getThanhTien();
        double khuyenMai = ThanhToan.tongTien - ThanhToan.hdDecorator.getThanhTien();
        public HoaDon()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // get all bill info
            int tt = (int)ThanhToan.hdDecorator.getThanhTien();
            int tkd = ThanhToan.tienKhachDua;
            int ttk = tienThoi;
            string nl = lbNgayBan.Text;
            string mkh = lbMaKH.Text;
            string mnv = DangNhap.maNV;
            double tkm = khuyenMai;
            Bill bill = new Bill(tt, tkd, ttk, nl, mkh, mnv, tkm);

            BillController.Instance.insertBill(tt, tkd, ttk, nl, mkh, mnv);

            foreach (Product product in billList)
            {
                string tenSP = product.getTenSanPham();
                int soLuong = product.getSoLuong();
                string maSP = ProductController.Instance.getProductId(tenSP);

                ProductController.Instance.updateProductCount(maSP, soLuong);
            }
            MessageBox.Show("Thanh toán hóa đơn thành công!");
            this.Close();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            /*
                Temporary adjusted
                There are technical debts that need refactoring
                * TEAM DISCUSSION NEEDED *
            */
            /*
            lbTienKhachDua.Text = ThanhToan.tienKhachDua.ToString() + " VND";
            lbTenNV.Text = ThanhToan.tenNV;
            lbMaKH.Text = ThanhToan.maKH;
            lbNgayBan.Text = ThanhToan.ngayBan;
            lbTongTien.Text = ThanhToan.tongTien.ToString() + " VND";
            */

            lbTienKhachDua.Text = ThanhToan.tienKhachDua.ToString();
            lbTenNV.Text = ThanhToan.tenNV;
            lbMaKH.Text = ThanhToan.maKH;
            lbNgayBan.Text = ThanhToan.ngayBan;
            lbTongTien.Text = ThanhToan.hdDecorator.getThanhTien().ToString() + " VND";

            //int tienThoi = ThanhToan.tienKhachDua - ThanhToan.tongTien;
            if (tienThoi < 0)
            {
                lbKhachTraThieu.Text = "Khách trả không đủ tiền!";
            }    
            lbTienTraKhach.Text = tienThoi.ToString() + " VND";

            foreach (Product bill in billList)
            {
                string tenSP = bill.getTenSanPham();
                int soLuong = bill.getSoLuong();
                int gia = bill.getGia();
                int giamGia = bill.getGiamGia();
                int thanhTien = bill.getThanhTien();
                dgvThanhToan.Rows.Add(tenSP, soLuong, gia, giamGia, thanhTien);
            }
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
