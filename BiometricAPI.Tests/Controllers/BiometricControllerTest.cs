using BiometricAPI.Controllers;
using BiometricBLL.Cryptography;
using BiometricBLL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace BiometricAPI.Tests.Controllers
{
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
        public void GetById()
        {
            // Arrange
            BiometricController controller = new BiometricController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            HttpResponseMessage peopleResponse = controller.Get();
            peopleResponse.TryGetContentValue(out IEnumerable<Person> people);
            HttpResponseMessage response = controller.GetById(people.FirstOrDefault().Id.ToString());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.TryGetContentValue<Person>(out _));
        }

        [TestMethod]
        public void GetByFirstName()
        {
            // Arrange
            BiometricController controller = new BiometricController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            HttpResponseMessage response = controller.GetByFirstName("Pruthvi");

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.TryGetContentValue<IEnumerable<Person>>(out _));
        }

        [TestMethod]
        public void GetByLastName()
        {
            // Arrange
            BiometricController controller = new BiometricController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            HttpResponseMessage response = controller.GetByLastName("Raju");

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.TryGetContentValue<IEnumerable<Person>>(out _));
        }
	}
}