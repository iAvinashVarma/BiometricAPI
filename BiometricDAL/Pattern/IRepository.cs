using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiometricDAL.Pattern
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetEntitiesByField(string fieldName, string fieldValue);
        IEnumerable<TEntity> GetAll();
        bool Update(Guid id, TEntity entity);
        bool Update(Guid id, string fieldName, string fieldValue);
        bool Remove(Guid id);
    }
}
