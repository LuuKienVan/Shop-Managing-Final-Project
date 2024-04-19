using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Customer
    {
        private string maKH;
        private string tenKH;
        private string sdtKH;
        private int diemTichLuy;

        public Customer(string maKH, string tenKH, string sdtKH, int diemTichLuy)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.sdtKH= sdtKH;
            this.diemTichLuy = diemTichLuy;
        }
    }
}
