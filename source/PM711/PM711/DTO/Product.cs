using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Product
    {
        private String tenSanPham;
        private int soLuong;
        private int gia;
        private int giamGia;
        private int thanhTien;

        public Product(string tenSanPham, int soLuong, int gia, int giamGia)
        {
            this.TenSanPham = tenSanPham;
            this.SoLuong = soLuong;
            this.Gia = gia;
            this.GiamGia = giamGia;
        }

        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int Gia { get => gia; set => gia = value; }
        public int GiamGia { get => giamGia; set => giamGia = value; }
        public int ThanhTien { 
            get => thanhTien; set => thanhTien = value; }

        public string getTenSanPham()
        {
            return tenSanPham;
        }

        public int getSoLuong()
        {
            return soLuong;
        }
        public int getGia()
        {
            return gia;
        }

        public int getGiamGia()
        {
            return giamGia;
        }
        public int getThanhTien()
        {
            double gg = (double)giamGia / 100;
            return (int)((soLuong * gia) - (gia * soLuong * gg));
        }
    }
}
