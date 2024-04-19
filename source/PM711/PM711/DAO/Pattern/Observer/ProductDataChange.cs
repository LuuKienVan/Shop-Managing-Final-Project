using DAO.Pattern.Proxy.FormProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM711.DAO.Pattern.Observer
{
    public class ProductDataChange : Subject
    {
        private string notify;

        public void getProductDataChange()
        {
            DangNhap.home.Show();

            MessageBox.Show(notify, "Thông báo", MessageBoxButtons.OK);
        }

        public void setProductDataChange(string notify)
        {
            this.notify = notify;
            ProductChange();
        }

        public void ProductChange()
        {
            NotifyObserver(this);
        }

        public override void NotifyObserver(Subject subject)
        {
            foreach (var obs in observer)
            {
                obs.Notify(subject);
            }
        }
    }
}
