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
    public partial class SanPhamSapHetHan : Form
    {
        public SanPhamSapHetHan()
        {
            InitializeComponent();
        }

        private void SanPhamSapHetHan_Load(object sender, EventArgs e)
        {
            // get all products that are nearly-expired within 10 days
            DataTable dataTable = ProductController.Instance.getNearExpireProducts();
            dgvSPSapHetHan.DataSource = dataTable;
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
