using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAO
{
    public class ProductController
    {
        private static ProductController instance;

        public static ProductController Instance
        {
            get { if (instance == null) { instance = new ProductController(); } return instance; }
            private set { instance = value; }
        }

        public DataTable getProduct ()
        {
            // view all products method
            string query = "select * from SANPHAM";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }

        public bool insertProduct(string tenSP, int soLuong, string loaiSP, string HSD, int giaBan, int giaNhap, string maNCC)
        {
            // insert product method
            string query = "insert into SANPHAM values('', N'" + tenSP + "', " + soLuong + ", N'" + loaiSP + "', '" + HSD + "', " + giaBan + ", " + giaNhap + ", '" + maNCC + "')";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public bool updateProductCount (string maSP, int soLuong)
        {
            // update product method
            string query = "update SANPHAM set soLuong = soLuong - " + soLuong + " where maSP = '" + maSP + "'";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public bool deleteProduct()
        {
            // delete product method
            return true;
        }

        public int getProductCount(string productName)
        {
            // get product count by name
            string query = "select soLuong from SANPHAM where tenSP = N'" + productName + "'";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public int getProductPrice(string productName)
        {
            // get product price by name
            string query = "select giaBan from SANPHAM where tenSP = N'" + productName + "'";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public string getProductId(string productName)
        {
            // get product id by name
            string query = "select maSP from SANPHAM where tenSP = N'" + productName + "'";
            return DataProvider.Instance.ExecuteScalar(query).ToString();
        }

        public DataTable getAllProductType()
        {
            // get all product type
            string query = "select DISTINCT loai from SANPHAM";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable getNearExpireProducts()
        {
            // get all products that are nearly-expired within 10 days
            string query = "SELECT * FROM SANPHAM WHERE datediff(day, getdate(), hsd) <= 10 ";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
