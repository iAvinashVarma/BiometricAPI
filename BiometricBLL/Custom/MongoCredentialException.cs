using System;

namespace BiometricBLL.Custom
{
    public class MongoCredentialException : Exception
    {
        public MongoCredentialException() : base($"Invalid credentials.")
        {

        }

        public MongoCredentialException(string message) : base(message)
        {

        }
    }
}
