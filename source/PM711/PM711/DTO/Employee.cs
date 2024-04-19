using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Employee
    {
        private String maNV;
        private String tenNV;
        private String matKhau;
        private String diaChi;
        private String sdtNV;
        private String chucVu;

        public Employee(string maNV, string tenNV, string matKhau, string diaChi, string sdtNV, string chucVu)
        {
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.matKhau = matKhau;
            this.diaChi = diaChi;
            this.sdtNV = sdtNV;
            this.chucVu = chucVu;
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SdtNV { get => sdtNV; set => sdtNV = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
    }
}
