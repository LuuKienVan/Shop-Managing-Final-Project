using DAO;
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
    public partial class Kho : Form
    {
        public Kho()
        {
            InitializeComponent();
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Kho_Load(object sender, EventArgs e)
        {
            DataTable dataTable = ProductController.Instance.getProduct();       
            dgvKho.DataSource = dataTable;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            /*
                This is btn "Them Kho" in design 
            */
            AddKho ak = new AddKho();
            this.Hide();
            ak.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
                This is btn "Xem SP Het Han" 
            */
            SanPhamSapHetHan sanPhamSapHetHan = new SanPhamSapHetHan();
            this.Hide();
            sanPhamSapHetHan.ShowDialog();
            this.Show();
        }
    }
}
