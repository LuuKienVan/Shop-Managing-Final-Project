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
    public partial class NhaCungCap : Form
    {
        public NhaCungCap()
        {
            InitializeComponent();
        }

        private void btnTroLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void loadDataNCC()
        {
            // get all suppliers
            DataTable dataTable = SupplierController.Instance.getSupplier();
            dgvNCC.DataSource = dataTable;
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            loadDataNCC();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // btn "chinh sua nha cung cap"
            ChinhSuaNhaCungCap sncc = new ChinhSuaNhaCungCap();
            this.Hide();
            sncc.ShowDialog();
            this.Show();
        }

        private void dgvNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
