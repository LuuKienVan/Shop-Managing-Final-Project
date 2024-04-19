using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Supplier
    {
        private string maNCC;
        private string tenNCC;
        private string sdtNCC;
        private string diachiNCC;
        private int ratingNCC;
        private string cacSPCungCap;

        public Supplier(string maNCC, string tenNCC, string sdtNCC, string diachiNCC, int ratingNCC, string cacSPCungCap) 
        {
            this.maNCC = maNCC;
            this.tenNCC = tenNCC;
            this.sdtNCC = sdtNCC;
            this.diachiNCC = diachiNCC;
            this.ratingNCC = ratingNCC;
            this.cacSPCungCap = cacSPCungCap;
        }
        public string MaNCC { get => maNCC; set => maNCC = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
        public string SdtNCC { get => sdtNCC; set => sdtNCC = value; }
        public string DiachiNCC { get => diachiNCC; set => diachiNCC = value; }
        public int RatingNCC { get => ratingNCC; set => ratingNCC = value; }
        public string CacSPCungCap { get => cacSPCungCap; set => cacSPCungCap = value; }
    }
}
