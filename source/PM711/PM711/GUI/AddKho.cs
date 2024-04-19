using DAO;
using PM711.DAO.Pattern.Observer;
using PM711.DAO.Pattern.Stratery.Check;
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
            // get all product type to display
            DataTable dataTable = ProductController.Instance.getAllProductType();

            cbLoaiSP.DataSource = dataTable;
            cbLoaiSP.DisplayMember = "loai";
            cbLoaiSP.Text = "Chọn loại sản phẩm";
            
            //query = "select DISTINCT maNCC from NHACUNGCAP";

            // get all supplier id to display
            dataTable = SupplierController.Instance.getAllSupplierId();

            cbMaNCC.DataSource = dataTable;
            cbMaNCC.DisplayMember = "maNCC";
            cbMaNCC.Text = "Chọn mã nhà cung cấp";
        }

        private void AddKho_Load(object sender, EventArgs e)
        {
            loadData();
            lbThongBao.Text = "";
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            /*
                This is btn "Them" in design
             */
            App app = new App();
            CheckStratery checkNum = new CheckNumber();
            app.setCheck(checkNum);

            if (txtTenSP.Text != "" && txtSoLuong.Text != "" && cbLoaiSP.Text != "Chọn loại sản phẩm" && dtpHSD.Text != "" && txtGiaBan.Text != "" && txtGiaNhap.Text != "" && cbMaNCC.Text != "Chọn mã nhà cung cấp")
            {
                if (app.getCheck(txtSoLuong.Text) && app.getCheck(txtGiaBan.Text) && app.getCheck(txtGiaNhap.Text))
                {
                    string tenSP = txtTenSP.Text;
                    int soLuong = int.Parse(txtSoLuong.Text);
                    string loaiSP = cbLoaiSP.Text;
                    string HSD = dtpHSD.Text;
                    int giaBan = int.Parse(txtGiaBan.Text);
                    int giaNhap = int.Parse(txtGiaNhap.Text);
                    string maNCC = cbMaNCC.Text;

                    // insert product
                    if (ProductController.Instance.insertProduct(tenSP, soLuong, loaiSP, HSD, giaBan, giaNhap, maNCC))
                    {
                        MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo");

                        ProductDataChange productAdd = new ProductDataChange();
                        _ = new HomeNotify(productAdd);
                        productAdd.setProductDataChange("Kho vừa cập nhật thêm sản phẩm mới!");
                    }
                    else
                    {
                        MessageBox.Show("Them san pham that bai");
                    }
                    //MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);

                    this.Close();
                }
                else
                {
                    lbThongBao.Text = "Không được nhập số âm!";
                }
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
