using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sync2._0.Data
{
    public class AdoContext
    {
        public AdoContext()
        {
        }

        public SqliteConnection GetConnection()
        {
            var connection = new SqliteConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            connection.Open();
            return connection;
        }
    }
}
