using Pattern.Factory.DatabaseFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        private static string connectionString = "Data Source=.;" +
                                          "Initial Catalog=QuanLy711;" +
                                          "Integrated Security=True";
        // Change this factory if migrating to another database
        private DatabaseFactory factory = new SqlDatabaseFactory(connectionString);

        /*
            Singleton pattern ensures that only 1 instance of db controller can be created 
         */
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value;}
        }

        private DataProvider() { }

        /*
            This method returns a table contains info of the given query
         */
        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using (var connection = factory.CreateConnection())
            {
                connection.Open();
                var cmd = factory.CreateCommand(query, connection);
                var adapter = factory.CreateDataAdapter(cmd);
                adapter.Fill(dt);
                connection.Close();
            }
            return dt;
        }

        /*
            This method return a boolean value indicate if a query is successfully executed
         */
        public bool ExecuteNonQuery(string query)
        {
            int returnVal = 0;
            using (var connection = factory.CreateConnection())
            {
                connection.Open();
                var cmd = factory.CreateCommand(query, connection);
                returnVal = cmd.ExecuteNonQuery();
                connection.Close();
            }
            return returnVal > 0;
        }

        /*
            This method returns the first column of the first row in the result set returned by the query
         */
        public object ExecuteScalar(string query)
        {
            object dt = new DataTable();
            using (var connection = factory.CreateConnection())
            {
                connection.Open();
                var cmd = factory.CreateCommand(query, connection);
                dt = cmd.ExecuteScalar();
                connection.Close();
            }
            return dt;
        }
    }
}
