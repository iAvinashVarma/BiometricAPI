using BiometricAPI.Controllers;
using BiometricBLL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
			Assert.IsTrue(response.TryGetContentValue<Persons>(out Persons people));
		}

		[TestMethod]
		public void GetFirstName()
		{
			// Arrange
			BiometricController controller = new BiometricController
			{
				Request = new HttpRequestMessage(),
				Configuration = new HttpConfiguration()
			};
			string expectedLastName = "Rand";

			// Act
			HttpResponseMessage response = controller.GetFirstName("Ayn");

			// Assert
			Assert.IsNotNull(response);
			Assert.IsTrue(response.TryGetContentValue<Person>(out Person person));
			Assert.AreEqual(expectedLastName, person.LastName);
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