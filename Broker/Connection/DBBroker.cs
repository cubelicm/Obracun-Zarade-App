using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broker.Connection
{
    public class DbBroker
    {
        private DbConnection connection = new DbConnection();

        private static DbBroker instance;

        public static DbBroker Instance { get { if (instance == null) instance = new DbBroker(); return instance; } }

        public DbConnection GetConnection()
        {
            if (!connection.IsReady())
                connection.OpenConnection();

            return connection;
        }
    }
}
