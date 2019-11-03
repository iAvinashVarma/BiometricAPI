using BiometricBLL.Concrete;
using BiometricBLL.Cryptography;
using BiometricBLL.Model;
using BiometricBLL.Pattern.Interface;
using MongoDB.Driver;
using System;
using System.Linq;

namespace BiometricBLL.Pattern.Repository.Mongo
{
    public class UserRepository : MongoRepository<User>, IUserRepository<User>
    {
        public UserRepository() : base(DatabaseCredential.Instance.ConnectionString, DatabaseCredential.DatabaseName, DatabaseCredential.UserCollectionName)
        {

        }

        public User GetByCredentials(string email, string password)
        {
            return GetAll().SingleOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && PasswordHash.ValidatePassword(password, u.Password));
        }
    }
}
