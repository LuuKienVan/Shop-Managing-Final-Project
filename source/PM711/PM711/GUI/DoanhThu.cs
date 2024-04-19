using DAO;
using Pattern.Stratery;
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
        ThongKe tk = new ThongKe();
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
            // get sales of specified month
            DataTable dataTable = SalesReportController.Instance.getAllSalesOfMonth(thang,nam);
            cBieuDo.DataSource = dataTable;
            dgvDoanhThu.DataSource = dataTable;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // btn "thong ke" in design
            if (cbThang.Text != "" && cbNam.Text != "")
            {
                thang = int.Parse(cbThang.Text);
                nam = int.Parse(cbNam.Text);

                loadDataDoanhThuThang();
                // get total sales of the month
                tk.setDoanhThu(new ThongKeThang());
                int totalSales = tk.getDoanhThu(new Time(thang,nam));
                lbTongDoanhThu.Text = "Tổng doanh thu tháng " + thang + "/" + nam + ": " + totalSales + " VND";

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
            // get sales of specified year
            DataTable dataTable = SalesReportController.Instance.getAllSalesOfYear(nam);
            cBieuDo.DataSource = dataTable;
            dgvDoanhThu.DataSource = dataTable;
        }

        private void btnThongKeNam_Click_1(object sender, EventArgs e)
        {
            if (cbNam.Text != "")
            {
                nam = int.Parse(cbNam.Text);

                loadDataDoanhThuNam();
                // get total sales of the year
                tk.setDoanhThu(new ThongKeNam());
                int totalSales = tk.getDoanhThu(new Time(nam));
                lbTongDoanhThu.Text = "Tổng doanh thu năm " + nam + ": " + totalSales + " VND";

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
