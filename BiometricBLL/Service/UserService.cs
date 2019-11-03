using BiometricBLL.Model;
using BiometricBLL.Pattern.Factory;

namespace BiometricBLL.Service
{
    public class UserService
    {
        public User GetUserByCredentials(string email, string password)
        {
            var userRepository = UserFactory.Repository;
            var user = userRepository.GetByCredentials(email, password);
            return user;
        }
    }
}
