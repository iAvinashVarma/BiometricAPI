using BiometricBLL.Model;

namespace BiometricBLL.Pattern.Interface
{
    public interface IUserRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity GetByCredentials(string email, string password);
    }
}
