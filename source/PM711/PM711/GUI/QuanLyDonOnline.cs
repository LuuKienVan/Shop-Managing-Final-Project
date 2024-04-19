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
    public partial class QuanLyDonOnline : Form
    {
        public QuanLyDonOnline()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvDonOnline.CurrentCell.RowIndex;
            dgvDonOnline.Rows.RemoveAt(rowIndex);
                            
        }

        private void QuanLyDonOnline_Load(object sender, EventArgs e)
        {
            // get online bills
            // unit testing only
            // not implemented yet
            // convenient store doesn't need this feature
            DataTable dataTable = BillController.Instance.getOnlineBill();
            dgvDonOnline.DataSource = dataTable;
        }

        private void dgvDonOnline_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
