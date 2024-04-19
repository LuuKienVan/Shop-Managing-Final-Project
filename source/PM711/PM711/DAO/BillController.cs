using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BillController
    {
        private static BillController instance;

        public static BillController Instance
        {
            get { if (instance == null) { instance = new BillController(); } return instance; }
            private set { instance = value; }
        }

        public DataTable getBill()
        {
            // view all bills method
            string query = "select * from HOADON";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }

        public bool insertBill(int tongTien, int tienKhachDua, int tienThoi, string ngayLap, string maKH, string maNV)
        {
            // insert method
            string query = "insert into HOADON values('', '" + tongTien + "', '" + tienKhachDua + "', '" + tienThoi + "', '" + ngayLap + "', '" + maKH + "', '" + maNV + "')";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public bool updateBill()
        {
            // update method
            return true;
        }

        public bool deleteBill() 
        { 
            return true;
        }

        public DataTable getOnlineBill()
        {
            // Duck-tape feature for unit testing
            // not implemented
            // Online ordering is not required in convenient store
            // Temporarily placed here
            string query = "EXEC random";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
