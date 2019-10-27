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
                return $"mongodb+srv://{UserName}:{AccessKey}@avpro-xigyn.mongodb.net/test?retryWrites=true&w=majority";
            }
        }

        public string UserName
        {
            get
            {
                var processLevelUsername = Environment.GetEnvironmentVariable("MONGODB_USERNAME", EnvironmentVariableTarget.Process);
                var userLevelUsername = Environment.GetEnvironmentVariable("MONGODB_USERNAME", EnvironmentVariableTarget.User);
                var userName = string.IsNullOrEmpty(processLevelUsername) ? userLevelUsername : processLevelUsername;
                if (string.IsNullOrEmpty(userName))
                {
                    throw new MongoCredentialException("Invalid UserName.");
                }
                return userName;
            }
        }

        public string AccessKey
        {
            get
            {
                var processLevelAccessKey = Environment.GetEnvironmentVariable("MONGODB_ACCESSKEY", EnvironmentVariableTarget.Process);
                var userLevelAccessKey = Environment.GetEnvironmentVariable("MONGODB_ACCESSKEY", EnvironmentVariableTarget.User);
                var accessKey = string.IsNullOrEmpty(processLevelAccessKey) ? userLevelAccessKey : processLevelAccessKey;
                if (string.IsNullOrEmpty(accessKey))
                {
                    throw new MongoCredentialException("Invalid AccessKey.");
                }
                return accessKey;
            }
        }
    }
}
