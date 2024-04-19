using Pattern.Stratery;
using PM711;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO.Pattern.Proxy.FormProxy
{
    /*
        Lazy instantation and caching to save resources
        Some page need authorization to access
    */

    //
    // interface
    //
    public interface IForm
    {
        void loadForm();
    }


    //
    // real service (Form)
    //
    public class RealPage : IForm
    {
        private Form f;
        public RealPage(Form f) 
        {
            this.f = f;
        }
        public void loadForm()
        {
            f.Show();
        }
    }

    /*
        ----------------------------------------Proxy service (Form)-------------------------------------------
    */

    // DoanhThu page
    public class DoanhThuPageProxy : IForm
    {
        private RealPage realPage;
        private string role;

        public DoanhThuPageProxy(string role)
        {
            this.role = role;
        }

        public void loadForm()
        {
            if (isManager())
            {
                if (realPage == null) { realPage = new RealPage(new DoanhThu()); }
                realPage.loadForm();
            }
            else { MessageBox.Show("Không đủ quyền truy cập"); }
        }

        // phan quyen
        private bool isManager()
        {
            if (this.role == "Quản lý" || this.role == "Admin")
            {
                return true;
            }
            return false;
        }
    }
}
