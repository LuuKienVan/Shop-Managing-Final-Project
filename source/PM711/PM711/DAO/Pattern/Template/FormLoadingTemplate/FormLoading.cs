using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM711.DAO.Pattern.Template.FormLoadingTemplate
{
    public abstract class FormLoading
    {
        // template method
        // 'readonly' & 'sealed' keywords which is equivalent to final are not supported
        public void loadForm(bool load_modal = true)
        {
            Form f = createForm();
            if (load_modal)
            {
                hideHome();
                loadModal(f);
                showHome();
            }
            if (!load_modal)
            {
                loadNonModal(f);
            }
        }

        public abstract Form createForm();
        private void loadModal(Form f)
        {
            f.ShowDialog();
        }
        private void loadNonModal(Form f)
        {
            f.Show();
        }
        private void hideHome()
        {
            DangNhap.home.Hide();
        }

        private void showHome()
        {
            DangNhap.home.Show();
        }
    }

    public class ThanhToanForm : FormLoading
    {
        public override Form createForm()
        {
            return new ThanhToan();
        }
    }

    public class KhoForm : FormLoading
    {
        public override Form createForm()
        {
            return new Kho();
        }
    }

    public class QuanLyDonOnlineForm : FormLoading
    {
        public override Form createForm()
        {
            return new QuanLyDonOnline();
        }
    }

    public class NhaCungCapForm : FormLoading
    {
        public override Form createForm()
        {
            return new NhaCungCap();
        }
    }
}
