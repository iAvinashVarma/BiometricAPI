using BiometricBLL.Enum;
using BiometricBLL.Pattern;
using System;

namespace BiometricBLL.Concrete
{
    public class ConnectionProcess : SingletonBase<ConnectionProcess>
    {
        public ConnectionType ConnectionType
        {
            get
            {
                var processLevelConnectionType = Environment.GetEnvironmentVariable("BIOMETRICAPI_CONNECTIONTYPE", EnvironmentVariableTarget.Process);
                var userLevelConnectionType = Environment.GetEnvironmentVariable("BIOMETRICAPI_CONNECTIONTYPE", EnvironmentVariableTarget.User);
                var connectionUrl = string.IsNullOrEmpty(processLevelConnectionType) ? userLevelConnectionType : processLevelConnectionType;
                return int.TryParse(connectionUrl, out int connectionTypeId) ? (ConnectionType)connectionTypeId : ConnectionType.Json;
            }
        }
    }
}
