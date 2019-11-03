using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BiometricBLL.Cryptography.Tests
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