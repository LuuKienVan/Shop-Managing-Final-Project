using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Decorator
{
    public abstract class HoaDonDecorator : HoaDon
    {
        protected HoaDon hdWrapObj;

        public HoaDonDecorator(HoaDon hd)
        {
            this.hdWrapObj = hd;
        }
    }
}
