using BiometricBLL.Concrete;
using BiometricBLL.Enum;
using BiometricBLL.Model;
using BiometricBLL.Pattern.Interface;
using JsonRepo = BiometricBLL.Pattern.Repository.Json;
using MongoRepo = BiometricBLL.Pattern.Repository.Mongo;

namespace BiometricBLL.Pattern.Factory
{
    public static class UserFactory
    {
        public static IUserRepository<User> Repository
        {
            get
            {
                IUserRepository<User> repository;
                var connectionType = ConnectionType.Json;
                //var connectionType = ConnectionProcess.Instance.ConnectionType;
                switch (connectionType)
                {
                    case ConnectionType.MongoDb:
                        repository = new MongoRepo.UserRepository();
                        break;
                    case ConnectionType.Json:
                        repository = new JsonRepo.UserRepository();
                        break;
                    default:
                        repository = new JsonRepo.UserRepository();
                        break;
                }
                return repository;
            }
        }
    }
}
