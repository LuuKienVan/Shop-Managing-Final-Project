using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Decorator
{
    public class HoaDonCuoiTuan : HoaDonDecorator
    {
        public HoaDonCuoiTuan(HoaDon hd) : base(hd)
        {
        }

        public override double getThanhTien()
        {
            // giam gia 10%
            return hdWrapObj.getThanhTien() - hdWrapObj.getThanhTien() * 0.1;
        }
    }
}
