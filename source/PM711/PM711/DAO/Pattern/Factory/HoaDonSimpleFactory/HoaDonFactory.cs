using Pattern.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Pattern.Factory.HoaDonFactory
{
    public class HoaDonFactory
    {
        public HoaDon getHoaDon(string type, HoaDon hd)
        {
            if (type == "KM Cuoi Tuan")
            {
                hd = new HoaDonCuoiTuan(hd);
            }
            else if (type == "KM Ngay Le")
            {
                hd = new HoaDonNgayLe(hd);
            }
            else
            {

            }
            return hd;
        }
    }
}
