using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAO
{
    public class SupplierController
    {
        private static SupplierController instance;

        public static SupplierController Instance
        {
            get { if (instance == null) { instance = new SupplierController(); } return instance; }
            private set { instance = value; }
        }
        public DataTable getSupplier()
        {
            // get all supplier
            string query = "select * from NHACUNGCAP";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool updateSupplier(string maNCC, string tenNCC, string SDT, string diaChi, int danhGia, string spCungCap)
        {
            // update supplier
            string query = "update NHACUNGCAP set tenNCC = N' " + tenNCC + " ', sdtNCC = ' " + SDT + " ', diachiNCC = N'" + diaChi + "', ratingNcc =  " + danhGia + " , cacSPCungCap = N'" + spCungCap + "' where maNCC = '" + maNCC + "'";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public DataTable getAllSupplierId()
        {
            // get all Suppliers' id
            string query = "select DISTINCT maNCC from NHACUNGCAP";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable getProductsOfSupplier()
        {
            // get all products of suppliers
            string query = "select DISTINCT cacSPCungCap from NHACUNGCAP";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
