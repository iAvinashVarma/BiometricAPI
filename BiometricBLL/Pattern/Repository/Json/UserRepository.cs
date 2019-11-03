using BiometricBLL.Cryptography;
using BiometricBLL.Model;
using BiometricBLL.Pattern.Interface;
using System;
using System.Linq;

namespace BiometricBLL.Pattern.Repository.Json
{
    public class UserRepository : JsonRepository<User>, IUserRepository<User>
    {
        public UserRepository() : base(@"Data/User.json")
        {

        }

        public User GetByCredentials(string email, string password)
        {
            return GetAll().SingleOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && PasswordHash.ValidatePassword(password, u.Password));
        }
    }
}
