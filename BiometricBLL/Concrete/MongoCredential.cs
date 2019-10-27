using BiometricBLL.Custom;
using BiometricBLL.Pattern;
using System;

namespace BiometricBLL.Concrete
{
    public class MongoCredential : SingletonBase<MongoCredential>
    {
        public const string DatabaseName = "biometric";
        public const string CollectionName = "person";

        private MongoCredential()
        {

        }

        public string ConnectionString
        {
            get
            {
                var processLevelAccessKey = Environment.GetEnvironmentVariable("MONGODB_ACCESSKEY", EnvironmentVariableTarget.Process);
                var userLevelAccessKey = Environment.GetEnvironmentVariable("MONGODB_ACCESSKEY", EnvironmentVariableTarget.User);
                var processLevelUsername = Environment.GetEnvironmentVariable("MONGODB_USERNAME", EnvironmentVariableTarget.Process);
                var userLevelUsername = Environment.GetEnvironmentVariable("MONGODB_USERNAME", EnvironmentVariableTarget.User);
                var accessKey = string.IsNullOrEmpty(processLevelAccessKey) ? userLevelAccessKey : processLevelAccessKey;
                var userName = string.IsNullOrEmpty(processLevelUsername) ? userLevelUsername : processLevelUsername;
                if(string.IsNullOrEmpty(accessKey) || string.IsNullOrEmpty(userName))
                {
                    throw new MongoCredentialException();
                }
                return $"mongodb+srv://{userName}:{accessKey}@avpro-xigyn.mongodb.net/test?retryWrites=true&w=majority";
            }
        }
    }
}
