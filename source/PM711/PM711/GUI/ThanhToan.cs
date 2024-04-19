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
using DTO;
using DAO;
using DAO.Pattern.Factory.HoaDonFactory;
using PM711.DAO.Pattern.Stratery.Check;

namespace PM711
{
    public partial class ThanhToan : Form
    {
        public static string tenNV = "";
        public static string maKH = "";
        public static string ngayBan = "";
        public static int tienKhachDua = 0;
        public static int tongTien = 0;
        public static int checktongTien = 0;
        public static int tienThoi = 0;
        public static Pattern.Decorator.HoaDon hdDecorator;
        public static List<Product> billList = new List<Product>();
        public App app = new App();
        public CheckStratery checkNum = new CheckNumber();
        public ThanhToan()
        {
            InitializeComponent();
        }

        private void loadDataSanPham()
        {
            cbTenSP.DataSource = ProductController.Instance.getProduct();
            cbTenSP.DisplayMember = "tenSP";
            cbTenSP.Text = "Chọn sản phẩm";
        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {
            loadDataSanPham();

            txtTenNV.Text = DangNhap.tenNV;
            dtpNgayBan.Text = DateTime.Today.ToString();
            cbTenSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            /*
                This btn is "Them" in design
            */
            if (cbTenSP.Text != "" && txtSoLuong.Text != "")
            {
                string tenSP = cbTenSP.Text;
                int soLuong = int.Parse(txtSoLuong.Text);
                int giamGia;
                if (txtGiamGia.Text == "")
                {
                    giamGia = 0;
                }
                else
                {
                    giamGia = int.Parse(txtGiamGia.Text);
                }

                //string query = "select soLuong from SANPHAM where tenSP = N'" + tenSP + "'";
                int checkSoLuong = ProductController.Instance.getProductCount(tenSP);

                app.setCheck(checkNum);

                if (!app.getCheck(txtSoLuong.Text.ToString()))
                {
                    lbThongBao.Text = "Số lượng sản phẩm không hợp lệ!";
                    lbTongTien.Text = "";
                }
                else if (soLuong > checkSoLuong)
                {
                    lbThongBao.Text = "Sản phẩm đang chọn chỉ còn số lượng là: " + checkSoLuong + "!";
                    lbTongTien.Text = "";
                }
                else
                {

                    int gia = ProductController.Instance.getProductPrice(tenSP);

                    Product product = new Product(tenSP, soLuong, gia, giamGia);

                    // add product to bill
                    billList.Add(product);

                    double thanhTien = product.getThanhTien();

                    // update UI
                    dgvThanhToan.Rows.Add(tenSP, soLuong, gia, giamGia, thanhTien);

                    dgvThanhToan.AllowUserToAddRows = false;

                    int sum = 0;
                    for (int i = 0; i < dgvThanhToan.Rows.Count; i++)
                    {
                        sum += int.Parse(dgvThanhToan.Rows[i].Cells[4].Value.ToString());
                    }

                    lbThongBao.Text = "Tổng tiền:";
                    lbTongTien.Text = sum.ToString() + " VND";
                    checktongTien = sum;
                }
            }
            else
            {
                lbThongBao.Text = "Vui lòng nhập đủ số liệu!";
                lbTongTien.Text = "";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
                This is btn "Xac nhan" in design
                On click change to "HOA DON view"
            */


            app.setCheck(checkNum);

            if (txtTienKhachDua.Text == "")
            {
                lbThongBao.Text = "Vui lòng điền đầy đủ các thông tin vào!";
                lbTongTien.Text = "";
            }
            else
            {
                if (!app.getCheck(txtTienKhachDua.Text.ToString()))
                {
                    lbThongBao.Text = "Tiền khách đưa không hợp lệ!";
                    lbTongTien.Text = "";
                }
                else
                {
                    if (checktongTien > int.Parse(txtTienKhachDua.Text))
                    {
                        lbThongBao.Text = "Khách trả không đủ tiền!";
                        lbTongTien.Text = "";
                    }
                    else
                    {
                        foreach (DataGridViewRow row in dgvThanhToan.Rows)
                        {
                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                if (row.Cells[i].Value != null && row.Cells[i].Value != DBNull.Value && !String.IsNullOrWhiteSpace(row.Cells[i].Value.ToString()) && txtTienKhachDua.Text != "")
                                {
                                    tenNV = txtTenNV.Text;

                                    ngayBan = dtpNgayBan.Text;
                                    tienKhachDua = int.Parse(txtTienKhachDua.Text);

                                    /*
                                    // Should disable check maKH as it should be automatically generated in db
                                    // Should enter customer's name instead if they are registered
                                    // There are no customer related features currently
                                    // Probably designed base on the previous project requirements
                                    */

                                    //string query = "select maKH from KHACHHANG";

                                    DataTable dataTable = CustomerController.Instance.getCustomer(maKH);

                                    foreach (DataRow r in dataTable.Rows)
                                    {
                                        maKH = txtMaKH.Text;

                                        tongTien = checktongTien;
                                        hdDecorator = new Pattern.Decorator.DefaultHoaDon(tongTien);
                                        HoaDonFactoryClient hdfc = new HoaDonFactoryClient(new HoaDonFactory());
                                        foreach (var itemChecked in KhuyenMaiCheckedListBox.CheckedItems)
                                        {
                                            //if (itemChecked.ToString() == "KM Cuoi Tuan")
                                            //{
                                            //    hdDecorator = new Pattern.Decorator.HoaDonCuoiTuan(hdDecorator);
                                            //}
                                            //else if (itemChecked.ToString() == "KM Ngay Le")
                                            //{
                                            //    hdDecorator = new Pattern.Decorator.HoaDonNgayLe(hdDecorator);
                                            //}
                                            hdDecorator = hdfc.getHoaDon(itemChecked.ToString(), hdDecorator);
                                        }
                                    }
                                    HoaDon hd = new HoaDon();
                                    this.Hide();
                                    hd.ShowDialog();
                                    this.Show();

                                    txtMaKH.Clear();
                                    cbTenSP.Text = "";
                                    txtSoLuong.Clear();
                                    txtGiamGia.Clear();
                                    lbTongTien.Text = "";
                                    txtTienKhachDua.Clear();
                                    dgvThanhToan.Rows.Clear();
                                }
                                else
                                {
                                    lbThongBao.Text = "Vui lòng điền đầy đủ các thông tin vào!";
                                    lbTongTien.Text = "";
                                }
                            }
                        }
                    }
                }
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {   
            /*
              This is btn "Huy" in design 
            */
            dgvThanhToan.Rows.Clear();
            lbThongBao.Text = "Tổng tiền:";
            lbTongTien.Text = "0 VND";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }      

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }       

        private void lbThongBao_Click(object sender, EventArgs e)
        {

        }

        private void dtpNgayBan_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
