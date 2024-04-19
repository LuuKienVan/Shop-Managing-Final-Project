using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM711.DAO.Pattern.Observer
{
    public class HomeNotify : Observer
    {
        private Subject subject;
        public HomeNotify(Subject subject)
        {
            this.subject = subject;
            this.subject.AddObserver(this);
        }

        public void Notify(Subject subject)
        {
            if (subject is ProductDataChange productNumber)
                productNumber.getProductDataChange();
        }
    }
}
