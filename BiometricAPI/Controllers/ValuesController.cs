using BiometricBLL;
using BiometricBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BiometricAPI.Controllers
{
	public class ValuesController : ApiController
	{
		private readonly BiometricFactory biometricFactory = null;

		public ValuesController()
		{
			biometricFactory = new BiometricFactory(DataModel.Json);
		}

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
					var filterPersons = People.FirstOrDefault(p => p.Id == id);
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
					var filterPersons = People.FirstOrDefault(p => p.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase));
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
					var filterPersons = People.FirstOrDefault(p => p.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
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

		// POST api/values
		[HttpPost]
		public HttpResponseMessage Post([FromBody] Person person)
		{
			HttpResponseMessage httpResponseMessage = null;
			try
			{
				var result = biometricFactory.BiometricOperation.Create(person);
				httpResponseMessage = Request.CreateResponse<Person>(HttpStatusCode.Created, result);
				httpResponseMessage.Headers.Location = new Uri($"{Request.RequestUri}{person.FirstName}");
			}
			catch (Exception ex)
			{
				httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
			return httpResponseMessage;
		}

		// PUT api/values/5
		[HttpPut]
		public HttpResponseMessage Put(int id, [FromBody] Person person)
		{
			HttpResponseMessage httpResponseMessage = null;
			try
			{
				var result = biometricFactory.BiometricOperation.Update(id, person);
				httpResponseMessage = Request.CreateResponse<Person>(HttpStatusCode.Created, result);
				httpResponseMessage.Headers.Location = new Uri($"{Request.RequestUri}{person.FirstName}");
			}
			catch (Exception ex)
			{
				httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
			return httpResponseMessage;
		}

		// DELETE api/values/5
		[HttpDelete]
		public HttpResponseMessage Delete(int id)
		{
			HttpResponseMessage httpResponseMessage = null;
			try
			{
				var person = People.FirstOrDefault(p => p.Id == id);
				var result = biometricFactory.BiometricOperation.Delete(id);
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
				Persons people = null;
				if (biometricFactory != null)
				{
					people = biometricFactory.BiometricOperation.ReadAll() as Persons;
				}
				return people;
			}
		}
	}
}