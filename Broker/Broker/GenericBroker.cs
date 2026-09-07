using Broker.Connection;
using Common.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Broker.Broker
{
    public class GenericBroker : IBroker<IEntity>
    {

        public void Close()
        {
            DbBroker.Instance.GetConnection().Close();
        }
        public void Commit()
        {
            DbBroker.Instance.GetConnection().Commit();
        }
        public void Rollback()
        {
            DbBroker.Instance.GetConnection().Rollback();
        }
        public void Add(IEntity entity)
        {
            SqlCommand cmd = DbBroker.Instance.GetConnection().GetCommand();
            cmd.CommandText = $"insert into {entity.NazivTabele} ({entity.InsertKolone}) values ({entity.InsertVrednosti})";
            Debug.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
        }
        public void Update(IEntity entity, object id)
        {
            SqlCommand cmd = DbBroker.Instance.GetConnection().GetCommand();
            cmd.CommandText = $"update {entity.NazivTabele} set {entity.UpdateVrednost} where {entity.PrimaryKey}='{id}'";
            Debug.WriteLine(cmd.CommandText);

            cmd.ExecuteNonQuery();
        }
        public void Delete(IEntity entity, object id)
        {
            SqlCommand cmd = DbBroker.Instance.GetConnection().GetCommand();
            cmd.CommandText = $"delete from {entity.NazivTabele} where {entity.PrimaryKey}='{id}'";
            cmd.ExecuteNonQuery();
        }
        public List<IEntity> FilterCriteria(IEntity entity, object criteria)
        {
            List<IEntity> result;
            SqlCommand cmd = DbBroker.Instance.GetConnection().GetCommand();
            cmd.CommandText = $"select * from {entity.NazivTabele} where {entity.Search}{criteria}";
            Debug.WriteLine(cmd.CommandText);
            SqlDataReader reader = cmd.ExecuteReader();
            result = entity.GetEntities(reader);
            reader.Close();
            return result;
        }
        public List<IEntity> GetAll(IEntity entity)
        {
            List<IEntity> result;
            SqlCommand cmd = DbBroker.Instance.GetConnection().GetCommand();
            cmd.CommandText = $"select * from {entity.NazivTabele}";
            SqlDataReader reader = cmd.ExecuteReader();
            result = entity.GetEntities(reader);
            reader.Close();
            return result;
        }
        public List<IEntity> GetAllJoin(IEntity entity, IEntity joinEntity)
        {
            List<IEntity> result;
            SqlCommand cmd = DbBroker.Instance.GetConnection().GetCommand();
            cmd.CommandText = $"select * from {entity.NazivTabele} a join {joinEntity.NazivTabele} b on (a.{entity.ForeignKey}= b.{joinEntity.PrimaryKey})";
            SqlDataReader reader = cmd.ExecuteReader();
            result = entity.GetJoinEntities(reader);
            reader.Close();
            return result;
        }
        public List<IEntity> GetAllForeignKey(IEntity entity, object id)
        {
            List<IEntity> result;
            SqlCommand cmd = DbBroker.Instance.GetConnection().GetCommand();
            cmd.CommandText = $"select * from {entity.NazivTabele} where {entity.ForeignKey}='{id}'";
            SqlDataReader reader = cmd.ExecuteReader();
            result = entity.GetEntities(reader);
            reader.Close();
            return result;
        }
        public List<IEntity> GetAllForeignKey2(IEntity entity, object id)
        {
            List<IEntity> result;
            SqlCommand cmd = DbBroker.Instance.GetConnection().GetCommand();
            cmd.CommandText = $"select * from {entity.NazivTabele} where {entity.ForeignKey2}='{id}'";
            SqlDataReader reader = cmd.ExecuteReader();
            result = entity.GetEntities(reader);
            reader.Close();
            return result;
        }
        public List<IEntity> GetAllForeignKeyJoin(IEntity entity, IEntity joinEntity, object id)
        {
            List<IEntity> result;
            SqlCommand cmd = DbBroker.Instance.GetConnection().GetCommand();
            cmd.CommandText = $"select * from {entity.NazivTabele} a join {joinEntity.NazivTabele} b on (a.{entity.PrimaryKey}= b.{joinEntity.ForeignKey}) where b.{joinEntity.ForeignKey2}='{id}'";
            Debug.WriteLine(cmd.CommandText);
            SqlDataReader reader = cmd.ExecuteReader();
            result = entity.GetEntities(reader);
            reader.Close();
            return result;
        }
        public List<IEntity> GetCriteria(IEntity entity)
        {
            List<IEntity> result;
            SqlCommand cmd = DbBroker.Instance.GetConnection().GetCommand();
            cmd.CommandText = $"select * from {entity.NazivTabele} where {entity.Criteria}";
            SqlDataReader reader = cmd.ExecuteReader();
            result = entity.GetEntities(reader);
            reader.Close();
            return result;
        }
        public IEntity GetOne(IEntity entity, object id)
        {
            IEntity result;
            SqlCommand cmd = DbBroker.Instance.GetConnection().GetCommand();
            cmd.CommandText = $"select * from {entity.NazivTabele} where {entity.PrimaryKey}='{id}'";
            SqlDataReader reader = cmd.ExecuteReader();
            result = entity.GetEntity(reader);
            reader.Close();
            return result;
        }
        public object GetMaxId(IEntity entity)
        {
            object pk;
            SqlCommand cmd = DbBroker.Instance.GetConnection().GetCommand();
            cmd.CommandText = $"select max({entity.PrimaryKey}) from {entity.NazivTabele}";
            pk = cmd.ExecuteScalar();
            return pk;
        }
    }
}