using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class EmployeeController
    {
        private static EmployeeController instance;

        public static EmployeeController Instance
        {
            get { if (instance == null) { instance = new EmployeeController(); } return instance; }
            private set { instance = value; }
        }

        public DataTable getEmployee()
        {
            // view all employees method
            string query = "select * from NHANVIEN";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }

        public bool insertEmployee()
        {
            // insert method
            return true;
        }

        public bool updateEmployee()
        {
            // update method
            return true;
        }

        public bool deleteEmployee()
        {
            return true;
        }

        public bool checkLogin(string maNV, string matKhau)
        {
            string query = "select * from NHANVIEN where maNV='" + maNV + "' and matKhau='" + matKhau + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt.Rows.Count > 0;
        }

        public string getEmployeeName(string maNV)
        {
            // get employee info by employee id
            return (string)DataProvider.Instance.ExecuteScalar("select tenNV from NHANVIEN where maNV = '" + maNV + "'");
        }

        public string getEmployeeRole(string maNV)
        {
            return (string)DataProvider.Instance.ExecuteScalar("select chucVu from NHANVIEN where maNV = '" + maNV + "'");
        }
    }
}
