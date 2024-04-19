using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Decorator
{
    public abstract class HoaDon
    {
        private int cost;

        public int Cost { get => cost; set => cost = value; }

        public abstract double getThanhTien();
    }
}
