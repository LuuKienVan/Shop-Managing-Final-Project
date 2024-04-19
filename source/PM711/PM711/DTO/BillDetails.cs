using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BillDetails
    {
        private string maHD;
        private string maSP;
        private int soLuong;

        public BillDetails(string maHD, string maSP, int soLuong)
        {
            this.MaHD = maHD;
            this.MaSP = maSP;
            this.soLuong = soLuong;
        }

        public string MaHD { get => maHD; set => maHD = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
