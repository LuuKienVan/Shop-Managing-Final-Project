﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Factory.DatabaseFactory
{
    public class SqlDatabaseFactory : DatabaseFactory
    {
        private string cnString;
        public SqlDatabaseFactory() { this.cnString = ""; }
        public SqlDatabaseFactory(string cnString)
        {
            this.cnString = cnString;
        }
        public override DbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        public override DbCommand CreateCommand(string cmdText)
        {
            return new SqlCommand(cmdText);
        }

        public override DbCommand CreateCommand(string cmdText, DbConnection cn)
        {
            return new SqlCommand(cmdText, (SqlConnection)cn);
        }

        public override DbConnection CreateConnection()
        {
            if (this.cnString != null && this.cnString != "")
                return new SqlConnection(cnString);
            return new SqlConnection();
        }

        public override DbConnection CreateConnection(string cnString)
        {
            return new SqlConnection(cnString);
        }

        public override DbDataAdapter CreateDataAdapter()
        {
            return new SqlDataAdapter();
        }

        public override DbDataAdapter CreateDataAdapter(DbCommand selectCmd)
        {
            return new SqlDataAdapter((SqlCommand)selectCmd);
        }

        public override DbDataReader CreateDataReader(DbCommand dbCmd)
        {
            return dbCmd.ExecuteReader();
        }

        public override DbParameter CreateParameter(string name, object value)
        {
            return new SqlParameter(name, value);
        }
    }
}
