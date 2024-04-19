using Pattern.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Decorator
{
    public class HoaDonNgayLe : HoaDonDecorator
    {
        public HoaDonNgayLe(HoaDon hd) : base(hd)
        {
        }
        public override double getThanhTien()
        {
            // giam gia 20%
            return hdWrapObj.getThanhTien() - hdWrapObj.getThanhTien() * 0.2;
        }
    }
}
