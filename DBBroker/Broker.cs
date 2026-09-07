using Common.Domain;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace DBBroker
{
    public class Broker
    {
        private DbConnection connection;
        public Broker()
        {
            connection = new DbConnection();
        }

        public void Rollback()
        {
            connection.Rollback();
        }

        public void Commit()
        {
            connection.Commit();
        }

        public void BeginTransaction()
        {
            connection.BeginTransaction();
        }


        public void CloseConnection()
        {
            connection.CloseConnection();
        }

        public void OpenConnection()
        {
            connection.OpenConnection();
        }

        public void Add(IEntity entity)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"insert into {entity.TableName} values({entity.Values} )";
            Debug.WriteLine(">>> SQL: " + cmd.CommandText);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        public List<IEntity> GetAll(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT {entity.Select} FROM {entity.TableName} {entity.Alias} {entity.Join}";
            Debug.WriteLine(">>> SQL: " + command.CommandText);
            using SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            command.Dispose();
            return list;
        }
        public List<IEntity> GetByCondition(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT {entity.Select} FROM {entity.TableName} WHERE {entity.WhereCondition}";
            Debug.WriteLine(">>> SQL: " + command.CommandText);
            using SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            command.Dispose();
            return list;
        }
        public IEntity GetOne(IEntity entity)
        {
            IEntity found = null;
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = $"SELECT TOP 1 {entity.Select} FROM {entity.TableName} {entity.Alias} {entity.Join} WHERE {entity.WhereCondition};";
                Debug.WriteLine(">>> SQL: " + command.CommandText);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        found = entity.GetOne(reader);
                    }

                }
                return found;
            }
        }
        public void Delete(IEntity entity)
        {
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = $"delete from {entity.TableName} where {entity.WhereCondition}";
                Debug.WriteLine(">>> SQL: " + cmd.CommandText);
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(IEntity entity)
        {
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandText = $"update {entity.TableName} set {entity.UpdateValues} where {entity.WhereCondition}";
                Debug.WriteLine(">>> SQL: " + cmd.CommandText);
                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new Exception("Greska u bazi!");
                }
            }
        }
        public int AddWithId(IEntity entity)
        {
            try
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = $"insert into {entity.TableName} output inserted.{entity.IdName} values ({entity.Values})";
                    Debug.WriteLine(">>> SQL: " + cmd.CommandText);
                    object newId = cmd.ExecuteScalar();
                    if (newId == null)
                    {
                        throw new Exception($"Sistem ne moze da zapamti {entity.TableName}");
                    }
                    return (int)newId;
                }
            }
            catch (Exception)
            {
                throw new Exception($"Sistem ne moze da zapamti {entity.TableName}");
            }

        }
        public List<IEntity> GetByConditionJoin(IEntity entity)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT {entity.Select} FROM {entity.TableName} {entity.Alias} {entity.Join} WHERE {entity.WhereCondition}";
            Debug.WriteLine(">>> SQL: " + command.CommandText);
            using SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            command.Dispose();
            return list;
        }
    }
}
