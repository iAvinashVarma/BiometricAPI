using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BiometricBLL.Pattern
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        bool Update(TEntity entity);
        bool Remove(Guid id);
    }
}
