using BiometricBLL.Model;
using System.Collections.Generic;

namespace BiometricBLL.Pattern.Interface
{
    public interface IPersonRepository<TEntity, TPatchEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> GetEntitiesByFirstName(string firstName);

        IEnumerable<TEntity> GetEntitiesByLastName(string lastName);

        TEntity Patch(TPatchEntity patch);
    }
}
