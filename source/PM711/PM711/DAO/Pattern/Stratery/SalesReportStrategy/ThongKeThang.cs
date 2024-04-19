using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Stratery
{
    public class ThongKeThang : ThongKeStratery
    {
        public int totalSales(Time time)
        {
            int thang = time.Thang;
            int nam = time.Nam;
            
            return SalesReportController.Instance.getTotalSalesOfMonth(thang,nam);
        }
    }
}
