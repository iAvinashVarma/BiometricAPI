using BiometricBLL.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BiometricBLL.Tests.Cryptography
{
    [TestClass]
    public class PasswordHashTests
    {
        [TestMethod]
        public void CreateHashTest()
        {
            // Arrange
            var hash = PasswordHash.CreateHash("Abcd1234");

            // Assert
            Assert.IsNotNull(hash);
        }
    }
}