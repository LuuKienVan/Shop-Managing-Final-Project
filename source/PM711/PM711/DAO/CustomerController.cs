using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CustomerController
    {
        /*
            There is no use for this currently as there are no customer features
            Probably due to the requirements of the previous project.
            To be update in the future if related features are added
        */
        private static CustomerController instance;

        public static CustomerController Instance
        {
            get { if (instance == null) { instance = new CustomerController(); } return instance; }
            private set { instance = value; }
        }

        public DataTable getCustomer(string maKH)
        {
            string query = "select maKH from KHACHHANG";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
