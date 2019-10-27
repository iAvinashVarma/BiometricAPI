using BiometricAPI.Controllers;
using BiometricDAL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace BiometricAPI.Tests.Controllers
{
    [Ignore]
    [TestClass]
	public class BiometricControllerTest
	{
		[TestMethod]
		public void Get()
		{
            // Arrange
            BiometricController controller = new BiometricController
			{
				Request = new HttpRequestMessage(),
				Configuration = new HttpConfiguration()
			};

			// Act
			HttpResponseMessage response = controller.Get();

			// Assert
			Assert.IsNotNull(response);
            Assert.IsTrue(response.TryGetContentValue<IEnumerable<Person>>(out _));
		}

		[TestMethod]
		public void GetFirstName()
        {
            // Arrange
            using (BiometricController controller = new BiometricController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            })
            {
                string expectedLastName = "Rand";

                // Act
                HttpResponseMessage response = controller.GetFirstName("Ayn");

                // Assert
                Assert.IsNotNull(response);
                Assert.IsTrue(response.TryGetContentValue(out IEnumerable<Person> persons));
                Assert.AreEqual(expectedLastName, persons.ToList().FirstOrDefault().LastName);
            }
        }

        [TestMethod]
		public void Post()
		{
			// Arrange
			BiometricController controller = new BiometricController();

			// Act

			// Assert
		}

		[TestMethod]
		public void Put()
		{
			// Arrange
			BiometricController controller = new BiometricController();

			// Act

			// Assert
		}

		[TestMethod]
		public void Delete()
		{
			// Arrange
			BiometricController controller = new BiometricController();

			// Act

			// Assert
		}
	}
}