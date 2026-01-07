using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ElectricityBillproject
{
    public class DBHandler
    {
        public SqlConnection GetConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings["ElectricityBillDB"].ConnectionString;
            return new SqlConnection(cs);
        }
    }
}