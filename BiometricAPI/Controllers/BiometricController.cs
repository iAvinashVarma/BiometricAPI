using BiometricBLL.Concrete;
using BiometricDAL.Model;
using BiometricDAL.Pattern;
using BiometricDAL.Repository;
using System;
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
        private readonly IRepository<Person> personRepository = null;

        /// <summary>
        /// Dynamic Biometric Instantiator
        /// </summary>
        public BiometricController()
        {
            personRepository = new PersonRepository(MongoCredential.Instance.ConnectionString, MongoCredential.DatabaseName, MongoCredential.CollectionName);
        }

        /// <summary>
        /// Get all people information.
        /// </summary>
        /// <returns>People</returns>
        // GET api/values
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage httpResponseMessage;
            var people = personRepository.GetAll().ToList();
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, people);
            return httpResponseMessage;
        }

        /// <summary>
        /// Get person information based on id.
        /// </summary>
        /// <param name="id">Person Id</param>
        /// <returns>Person</returns>
        public HttpResponseMessage GetById(string id)
        {
            HttpResponseMessage httpResponseMessage;
            var guid = new Guid(id);
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, personRepository.GetById(guid));
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
            HttpResponseMessage httpResponseMessage;
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, personRepository.GetEntitiesByField("firstName", firstName));
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
            HttpResponseMessage httpResponseMessage;
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, personRepository.GetEntitiesByField("lastName", lastName));
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
            HttpResponseMessage httpResponseMessage;
            personRepository.Add(person);
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created);
            httpResponseMessage.Headers.Location = new Uri($"{Request.RequestUri}{person.FirstName}");
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
        public HttpResponseMessage Put(string id, [FromBody] Person person)
        {
            HttpResponseMessage httpResponseMessage = null;
            var guid = new Guid(id);
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created, personRepository.Update(guid, person));
            httpResponseMessage.Headers.Location = new Uri($"{Request.RequestUri}{person.FirstName}");
            return httpResponseMessage;
        }

        /// <summary>
        /// Delete existing person.
        /// </summary>
        /// <param name="id">Existing person id</param>
        /// <returns>Deleted person information</returns>
        // DELETE api/values/5
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            HttpResponseMessage httpResponseMessage;
            var guid = new Guid(id);
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.Accepted, personRepository.Remove(guid));
            return httpResponseMessage;
        }
    }
}