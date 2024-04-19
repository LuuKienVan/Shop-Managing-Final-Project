using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Bill
    {
        private string maHD;
        private int tongTien;
        private int tienKhachDua;
        private int tienThoi;
        private string ngayLapHD;
        private string maKH;
        private string maNV;
        private double giamGia = 0;

        public Bill() { }

        public Bill(int tongTien, int tienKhachDua, int tienThoi, string ngayLapHD, string maKH, string maNV, double giamGia)
        {
            this.tongTien = tongTien;
            this.tienKhachDua = tienKhachDua;
            this.tienThoi = tienThoi;
            this.ngayLapHD = ngayLapHD;
            this.maKH = maKH;
            this.maNV = maNV;
            this.GiamGia = giamGia;
        }

        public string MaHD { get => maHD; set => maHD = value; }
        public int TongTien { get => tongTien; set => tongTien = value; }
        public int TienKhachDua { get => tienKhachDua; set => tienKhachDua = value; }
        public int TienThoi { get => tienThoi; set => tienThoi = value; }
        public string NgayLapHD { get => ngayLapHD; set => ngayLapHD = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public double GiamGia { get => giamGia; set => giamGia = value; }
    }
}
