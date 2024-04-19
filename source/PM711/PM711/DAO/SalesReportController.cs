using Pattern.Stratery;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SalesReportController
    {
        private static SalesReportController instance;

        public static SalesReportController Instance
        {
            get { if (instance == null) { instance = new SalesReportController(); } return instance; }
            private set { instance = value; }
        }

        public DataTable getAllSalesOfMonth(int thang, int nam)
        {
            string query = "SELECT tongTien, ngayLapHD FROM HOADON WHERE MONTH(ngayLapHD) = " + thang + " AND YEAR(ngayLapHD) = " + nam + "";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public int getTotalSalesOfMonth(int thang, int nam)
        {
            string query = "SELECT sum(tongTien) as Tong FROM HOADON WHERE MONTH(ngayLapHD) = " + thang + " AND YEAR(ngayLapHD) = " + nam + "";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }

        public DataTable getAllSalesOfYear(int nam)
        {
            string query = "SELECT tongTien, ngayLapHD FROM HOADON WHERE YEAR(ngayLapHD) = " + nam + "";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public int getTotalSalesOfYear(int nam)
        {
            string query = "SELECT sum(tongTien) as Tong FROM HOADON WHERE YEAR(ngayLapHD) = " + nam + "";
            return (int)DataProvider.Instance.ExecuteScalar(query);
        }
    }
}
