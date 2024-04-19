using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Stratery
{
    public class ThongKeNam : ThongKeStratery
    {
        public int totalSales(Time time)
        {
            int nam = time.Nam;
            return SalesReportController.Instance.getTotalSalesOfYear(nam);
        }
    }
}
