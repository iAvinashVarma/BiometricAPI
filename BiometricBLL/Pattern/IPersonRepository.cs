using BiometricBLL.Model;
using System.Collections.Generic;

namespace BiometricBLL.Pattern
{
    public interface IPersonRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> GetEntitiesByFirstName(string firstName);

        IEnumerable<TEntity> GetEntitiesByLastName(string lastName);
    }
}
