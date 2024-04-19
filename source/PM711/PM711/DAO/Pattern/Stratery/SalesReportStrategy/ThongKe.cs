using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Stratery
{
    public class ThongKe
    {
        private ThongKeStratery tk;

        public void setDoanhThu(ThongKeStratery tk)
        {
            this.tk = tk;
        }

        public int getDoanhThu(Time time)
        {
            return tk.totalSales(time);
        }
    }
}
