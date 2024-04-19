using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PM711
{
    public partial class DoanhThu : Form
    {
        public int thang;
        public int nam;
        public DoanhThu()
        {
            InitializeComponent();
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void DoanhThu_Load(object sender, EventArgs e)
        {
            cbThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            loadDataDoanhThuThang();
            loadDataDoanhThuNam();
        }

        public void loadDataDoanhThuThang()
        {
            string connectString = "Data Source=LAPTOP-DTGRCF82\\SQLEXPRESS;Initial Catalog=QuanLy711;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectString);
            string query = "SELECT tongTien, ngayLapHD FROM HOADON WHERE MONTH(ngayLapHD) = " + thang + " AND YEAR(ngayLapHD) = " + nam + "";
            SqlCommand command = new SqlCommand(query, connect);
            connect.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            connect.Close();

            cBieuDo.DataSource = dataTable;
            dgvDoanhThu.DataSource = dataTable;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (cbThang.Text != "" && cbNam.Text != "")
            {
                thang = int.Parse(cbThang.Text);
                nam = int.Parse(cbNam.Text);

                loadDataDoanhThuThang();
                string connectString = "Data Source=LAPTOP-DTGRCF82\\SQLEXPRESS;Initial Catalog=QuanLy711;Integrated Security=True";
                SqlConnection connect = new SqlConnection(connectString);
                string query = "SELECT sum(tongTien) as Tong FROM HOADON WHERE MONTH(ngayLapHD) = " + thang + " AND YEAR(ngayLapHD) = " + nam + "";
                SqlCommand command = new SqlCommand(query, connect);
                connect.Open();
                lbTongDoanhThu.Text = "Tổng doanh thu tháng " + thang + "/" + nam + ": " + command.ExecuteScalar().ToString() + " VND";

                connect.Close();
                cBieuDo.Titles.Clear();
                cBieuDo.Series["Tổng tiền"].XValueMember = "ngayLapHD";
                cBieuDo.Series["Tổng tiền"].YValueMembers = "tongTien";
                cBieuDo.Titles.Add("Biểu đồ thống kê doanh thu tháng " + thang + "/" + nam);
            }  
            else
            {
                lbTongDoanhThu.Text = "Vui lòng chọn đủ các thông tin!";
            }    
            
        }


        public void loadDataDoanhThuNam()
        {
            string connectString = "Data Source=LAPTOP-DTGRCF82\\SQLEXPRESS;Initial Catalog=QuanLy711;Integrated Security=True";
            SqlConnection connect = new SqlConnection(connectString);
            string query = "SELECT tongTien, ngayLapHD FROM HOADON WHERE YEAR(ngayLapHD) = " + nam + "";
            SqlCommand command = new SqlCommand(query, connect);
            connect.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            connect.Close();

            cBieuDo.DataSource = dataTable;
            dgvDoanhThu.DataSource = dataTable;
        }

        private void btnThongKeNam_Click_1(object sender, EventArgs e)
        {
            if (cbNam.Text != "")
            {
                nam = int.Parse(cbNam.Text);

                loadDataDoanhThuNam();
                string connectString = "Data Source=LAPTOP-DTGRCF82\\SQLEXPRESS;Initial Catalog=QuanLy711;Integrated Security=True";
                SqlConnection connect = new SqlConnection(connectString);
                string query = "SELECT sum(tongTien) as Tong FROM HOADON WHERE YEAR(ngayLapHD) = " + nam + "";
                SqlCommand command = new SqlCommand(query, connect);
                connect.Open();
                lbTongDoanhThu.Text = "Tổng doanh thu năm " + nam + ": " + command.ExecuteScalar().ToString() + " VND";

                connect.Close();
                cBieuDo.Titles.Clear();
                cBieuDo.Series["Tổng tiền"].XValueMember = "ngayLapHD";
                cBieuDo.Series["Tổng tiền"].YValueMembers = "tongTien";
                cBieuDo.Titles.Add("Biểu đồ thống kê doanh thu năm " + nam);
            }
            else
            {
                lbTongDoanhThu.Text = "Vui lòng chọn năm!";
            }
        }

        private void cbTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvDoanhThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbNam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
