using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiometricBLL.Pattern
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Add(TEntity entity);
        TEntity GetById(ObjectId id);
        IEnumerable<TEntity> GetAll();
        bool Update(TEntity entity);
        bool Remove(ObjectId id);
    }
}
