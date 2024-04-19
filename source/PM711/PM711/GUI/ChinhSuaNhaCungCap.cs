using DAO;
using PM711.DAO.Pattern.Stratery.Check;
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
            // btn "xac nhan"
            // update nha cung cap
            App app = new App();
            CheckStratery checkPhone = new CheckPhone();
            app.setCheck(checkPhone);

            if (cbMaNCC.Text != "Chọn mã nhà cung cấp" && txtTenNCC.Text != "" && cbSPCungCap.Text != "Chọn loại sản phẩm" && txtSDT.Text != "" && txtDiaChi.Text != "" && cbDanhGia.Text != "Chọn đánh giá")
            {
                if (app.getCheck(txtSDT.Text))
                {
                    string maNCC = cbMaNCC.Text;
                    string tenNCC = txtTenNCC.Text;
                    string SDT = txtSDT.Text;
                    string diaChi = txtDiaChi.Text;
                    int danhGia = int.Parse(cbDanhGia.Text);
                    string spCungCap = cbSPCungCap.Text;

                    if (SupplierController.Instance.updateSupplier(maNCC, tenNCC, SDT, diaChi, danhGia, spCungCap))
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại");
                    }
                    //MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);

                    this.Close();
                }
                else
                {
                    lbThongBao.Text = "Số điện thoại không hợp lệ!";
                }
            }
            else
            {
                lbThongBao.Text = "Vui lòng nhập đầy đủ thông tin!";
            }
        }

        private void ChinhSuaNhaCungCap_Load(object sender, EventArgs e)
        {
            lbThongBao.Text = "";

            // get all products of suppliers
            DataTable dataTable = SupplierController.Instance.getProductsOfSupplier();

            cbSPCungCap.DataSource = dataTable;
            cbSPCungCap.DisplayMember = "cacSPCungCap";
            cbSPCungCap.Text = "Chọn loại sản phẩm";

            // get all suppliers' id
            dataTable = SupplierController.Instance.getAllSupplierId();

            cbMaNCC.DataSource = dataTable;
            cbMaNCC.DisplayMember = "maNCC";
            cbMaNCC.Text = "Chọn mã nhà cung cấp";
            cbDanhGia.Text = "Chọn đánh giá";
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
