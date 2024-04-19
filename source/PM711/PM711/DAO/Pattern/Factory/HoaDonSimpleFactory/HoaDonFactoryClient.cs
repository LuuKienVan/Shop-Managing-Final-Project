using Pattern.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Pattern.Factory.HoaDonFactory
{
    public class HoaDonFactoryClient
    {
        HoaDonFactory factory;
        public HoaDonFactoryClient(HoaDonFactory factory) 
        {
            this.factory = factory;
        }

        public HoaDon getHoaDon(string type, HoaDon hd)
        {
            return factory.getHoaDon(type, hd);
        }
    }
}
