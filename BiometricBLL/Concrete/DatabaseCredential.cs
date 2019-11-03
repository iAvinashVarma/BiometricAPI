using BiometricBLL.Custom;
using BiometricBLL.Pattern;
using System;

namespace BiometricBLL.Concrete
{
    public class DatabaseCredential : SingletonBase<DatabaseCredential>
    {
        public const string DatabaseName = "biometric";
        public const string PersonCollectionName = "person";
        public const string UserCollectionName = "user";

        private DatabaseCredential()
        {

        }

        public string ConnectionString
        {
            get
            {
                return $"{Prototype}://{UserName}:{AccessKey}@{ConnectionUrl}?retryWrites=true&w=majority";
            }
        }

        public string Prototype
        {
            get
            {
                return "mongodb+srv";
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

        public string ConnectionUrl
        {
            get
            {
                var processLevelConnectionUrl = Environment.GetEnvironmentVariable("MONGODB_CONNECTIONURL", EnvironmentVariableTarget.Process);
                var userLevelConnectionUrl = Environment.GetEnvironmentVariable("MONGODB_CONNECTIONURL", EnvironmentVariableTarget.User);
                var connectionUrl = string.IsNullOrEmpty(processLevelConnectionUrl) ? userLevelConnectionUrl : processLevelConnectionUrl;
                if (string.IsNullOrEmpty(connectionUrl))
                {
                    throw new MongoCredentialException("Invalid ConnectionUrl.");
                }
                return connectionUrl;
            }
        }
    }
}
