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
        public static List<Bill> billList = new List<Bill>();
        public ThanhToan()
        {
            InitializeComponent();
        }

        private void loadDataSanPham()
        {
            string connectString = "Data Source=LAPTOP-DTGRCF82\\SQLEXPRESS;Initial Catalog=QuanLy711;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectString);
            string query = "select * from SANPHAM";
            SqlCommand command = new SqlCommand(query, connect);
            connect.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            connect.Close();

            cbTenSP.DataSource = dataTable;
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

                string connectString = "Data Source=LAPTOP-DTGRCF82\\SQLEXPRESS;Initial Catalog=QuanLy711;Integrated Security=True";
                SqlConnection connect = new SqlConnection(connectString);
                string query = "select soLuong from SANPHAM where tenSP = N'" + tenSP + "'";
                SqlCommand command = new SqlCommand(query, connect);
                connect.Open();
                int checkSoLuong = (int)command.ExecuteScalar();

                if (soLuong > checkSoLuong)
                {
                    lbThongBao.Text = "Sản phẩm đang chọn chỉ còn số lượng là: " + checkSoLuong + "!";
                    lbTongTien.Text = "";
                }
                else
                {
                    query = "select giaBan from SANPHAM where tenSP = N'" + tenSP + "'";
                    command = new SqlCommand(query, connect);

                    int gia = (int)command.ExecuteScalar();

                    connect.Close();

                    Bill bill = new Bill(tenSP, soLuong, gia, giamGia);

                    billList.Add(bill);

                    double thanhTien = bill.getThanhTien();

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

            foreach (DataGridViewRow row in dgvThanhToan.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (row.Cells[i].Value != null && row.Cells[i].Value != DBNull.Value && !String.IsNullOrWhiteSpace(row.Cells[i].Value.ToString()) && txtMaKH.Text != "" && txtTienKhachDua.Text != "")
                    {
                        tenNV = txtTenNV.Text;
                        maKH = txtMaKH.Text;
                        ngayBan = dtpNgayBan.Text;
                        tienKhachDua = int.Parse(txtTienKhachDua.Text);

                        string connectString = "Data Source=LAPTOP-DTGRCF82\\SQLEXPRESS;Initial Catalog=QuanLy711;Integrated Security=True";
                        SqlConnection connect = new SqlConnection(connectString);
                        string query = "select maKH from KHACHHANG";
                        SqlCommand command = new SqlCommand(query, connect);
                        connect.Open();
                        DataTable dataTable = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                        connect.Close();

                        foreach (DataRow r in dataTable.Rows)
                        {
                            if (r[0].ToString() == maKH)
                            {
                                tongTien = checktongTien;
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
                                lbThongBao.Text = "Mã khách hàng không tồn tại!";
                                lbTongTien.Text = "";
                            }
                        }
                    }
                    else
                    {
                        lbThongBao.Text = "Vui lòng điền đầy đủ các thông tin vào!";
                        lbTongTien.Text = "";
                    }
                }
            }



        }

        private void button2_Click_1(object sender, EventArgs e)
        {
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
