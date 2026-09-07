using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Broker.Broker
{
    public interface IBroker<TEntity> where TEntity : class
    {
        void Commit();
        void Rollback();
        void Close();
        void Add(TEntity entity);
        void Update(IEntity entity, object id);
        void Delete(TEntity entity, object id);
        List<IEntity> FilterCriteria(TEntity entity, object criteria);
        List<TEntity> GetAll(TEntity entity);
        List<IEntity> GetCriteria(TEntity entity);
        TEntity GetOne(TEntity entity, object id);
        List<IEntity> GetAllForeignKey(IEntity entity, object id);
        List<IEntity> GetAllForeignKey2(IEntity entity, object id);
        List<TEntity> GetAllJoin(IEntity entity, IEntity joinEntity);
        List<IEntity> GetAllForeignKeyJoin(IEntity entity, IEntity joinEntity, object id);
        object GetMaxId(TEntity entity);

    }
}
