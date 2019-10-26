using BiometricBLL.Factory;
using BiometricBLL.Interface;
using BiometricBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BiometricAPI.Controllers
{
	/// <summary>
	/// Biometric APIs
	/// </summary>
	public class BiometricController : ApiController
	{
		private readonly IRepository<Person> biometricOperation = null;

		/// <summary>
		/// Dynamic Biometric Instantiator
		/// </summary>
		public BiometricController()
		{
			biometricOperation = new BiometricFactory().BiometricOperation;
		}

		/// <summary>
		/// Get all people information.
		/// </summary>
		/// <returns>People</returns>
		// GET api/values
		[HttpGet]
		public HttpResponseMessage Get()
		{
			HttpResponseMessage httpResponseMessage = null;
			try
			{
				httpResponseMessage = Request.CreateResponse<Persons>(HttpStatusCode.OK, People);
			}
			catch (Exception ex)
			{
				httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
			return httpResponseMessage;
		}

		/// <summary>
		/// Get person information based on id.
		/// </summary>
		/// <param name="id">Person Id</param>
		/// <returns>Person</returns>
		public HttpResponseMessage GetById(int id)
		{
			HttpResponseMessage httpResponseMessage = null;
			try
			{
				if (id <= 0)
				{
					httpResponseMessage = Request.CreateResponse<Persons>(HttpStatusCode.OK, People);
				}
				else
				{
					Person filterPersons = People.FirstOrDefault(p => p.Id == id);
					if (filterPersons != null)
					{
						httpResponseMessage = Request.CreateResponse<Person>(HttpStatusCode.OK, filterPersons);
					}
					else
					{
						httpResponseMessage = Request.CreateResponse(HttpStatusCode.NotFound, $"No data found with id {id}.");
					}
				}
			}
			catch (Exception ex)
			{
				httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
			return httpResponseMessage;
		}

		/// <summary>
		/// Get person information based on first name.
		/// </summary>
		/// <param name="firstName">Person First Name</param>
		/// <returns>Person</returns>
		// GET api/values?firstName=
		[HttpGet]
		public HttpResponseMessage GetFirstName(string firstName)
		{
			HttpResponseMessage httpResponseMessage = null;
			try
			{
				if (string.IsNullOrEmpty(firstName))
				{
					httpResponseMessage = Request.CreateResponse<Persons>(HttpStatusCode.OK, People);
				}
				else
				{
					Person filterPersons = People.FirstOrDefault(p => p.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase));
					if (filterPersons != null)
					{
						httpResponseMessage = Request.CreateResponse<Person>(HttpStatusCode.OK, filterPersons);
					}
					else
					{
						httpResponseMessage = Request.CreateResponse(HttpStatusCode.NotFound, $"No data found with first name {firstName}.");
					}
				}
			}
			catch (Exception ex)
			{
				httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
			return httpResponseMessage;
		}

		/// <summary>
		/// Get person information based on last name.
		/// </summary>
		/// <param name="lastName">Person Last Name</param>
		/// <returns>Person</returns>
		// GET api/values?lastName=
		[HttpGet]
		public HttpResponseMessage GetLastName(string lastName)
		{
			HttpResponseMessage httpResponseMessage = null;
			try
			{
				if (string.IsNullOrEmpty(lastName))
				{
					httpResponseMessage = Request.CreateResponse<IList<Person>>(HttpStatusCode.OK, People);
				}
				else
				{
					Person filterPersons = People.FirstOrDefault(p => p.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
					if (filterPersons != null)
					{
						httpResponseMessage = Request.CreateResponse<Person>(HttpStatusCode.OK, filterPersons);
					}
					else
					{
						httpResponseMessage = Request.CreateResponse(HttpStatusCode.NotFound, $"No data found with last name {lastName}.");
					}
				}
			}
			catch (Exception ex)
			{
				httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
			return httpResponseMessage;
		}

		/// <summary>
		/// Create new person.
		/// </summary>
		/// <param name="person">Person Information</param>
		/// <returns>Created Person</returns>
		// POST api/values
		[HttpPost]
		public HttpResponseMessage Post([FromBody] Person person)
		{
			HttpResponseMessage httpResponseMessage = null;
			try
			{
				Person result = biometricOperation.Create(person);
				httpResponseMessage = Request.CreateResponse<Person>(HttpStatusCode.Created, result);
				httpResponseMessage.Headers.Location = new Uri($"{Request.RequestUri}{person.FirstName}");
			}
			catch (Exception ex)
			{
				httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
			return httpResponseMessage;
		}

		/// <summary>
		/// Update existing person.
		/// </summary>
		/// <param name="id">Existing person id</param>
		/// <param name="person">Existing Person information</param>
		/// <returns>Updated Person</returns>
		// PUT api/values/5
		[HttpPut]
		public HttpResponseMessage Put(int id, [FromBody] Person person)
		{
			HttpResponseMessage httpResponseMessage = null;
			try
			{
				Person result = biometricOperation.Update(id, person);
				httpResponseMessage = Request.CreateResponse<Person>(HttpStatusCode.Created, result);
				httpResponseMessage.Headers.Location = new Uri($"{Request.RequestUri}{person.FirstName}");
			}
			catch (Exception ex)
			{
				httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
			return httpResponseMessage;
		}

		/// <summary>
		/// Delete existing person.
		/// </summary>
		/// <param name="id">Existing person id</param>
		/// <returns>Deleted person information</returns>
		// DELETE api/values/5
		[HttpDelete]
		public HttpResponseMessage Delete(int id)
		{
			HttpResponseMessage httpResponseMessage = null;
			try
			{
				Person person = People.FirstOrDefault(p => p.Id == id);
				Person result = biometricOperation.Delete(id);
				httpResponseMessage = Request.CreateResponse<Person>(HttpStatusCode.Created, result);
				httpResponseMessage.Headers.Location = new Uri($"{Request.RequestUri}{person.FirstName}");
			}
			catch (Exception ex)
			{
				httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
			return httpResponseMessage;
		}

		private Persons People
		{
			get
			{
				Persons people = biometricOperation.ReadAll() as Persons;
				return people;
			}
		}
	}
}