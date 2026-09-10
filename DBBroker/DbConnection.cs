using Microsoft.Data.SqlClient;
using System.Configuration;
namespace DBBroker
{
    internal class DbConnection
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        public DbConnection()
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings["MojaBaza"];

            if (connectionStringSettings==null|| string.IsNullOrWhiteSpace(connectionStringSettings.ConnectionString))
            {
                throw new Exception("Konekcioni string nije definisan u App.config fajlu.\nMolimo unesite konekcioni string u podesavanjima za bazu");
            }
            connection = new SqlConnection(connectionStringSettings.ConnectionString);
        }

        public void OpenConnection()
        {
            connection.Open();
        }

        public void CloseConnection()
        {
            connection?.Close();
        }

        public void BeginTransaction()
        {
            transaction = connection.BeginTransaction();
        }
        public void Commit()
        {
            transaction?.Commit();
        }
        public void Rollback()
        {
            transaction?.Rollback();
        }
        public SqlCommand CreateCommand()
        {
            return new SqlCommand("", connection, transaction);
        }
    }
}
