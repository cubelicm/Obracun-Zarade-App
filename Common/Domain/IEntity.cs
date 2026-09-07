using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public interface IEntity
    {
        string TableName { get; }
        string Values { get; }
        string Join { get; }
        string Alias { get; }
        string Select { get; }
        string WhereCondition { get; }
        string UpdateValues { get; }
        string IdName { get; }

        List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> lista = new List<IEntity>();
            while (reader.Read())
            {
                lista.Add(GetOne(reader));
            }
            return lista;
        }
        IEntity GetOne(SqlDataReader reader);
    }
}
