using BiometricBLL.Pattern.Factory;
using BiometricBLL.Model;
using BiometricBLL.Pattern;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Bson;

namespace BiometricAPI.Controllers
{
    /// <summary>
    /// Biometric APIs
    /// </summary>
    public class BiometricController : ApiController
    {
        private readonly IPersonRepository<Person> personRepository = null;

        /// <summary>
        /// Dynamic Biometric Instantiator
        /// </summary>
        public BiometricController()
        {
            personRepository = PersonFactory.Repository;
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
            var objectId = new ObjectId(id);
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, personRepository.GetById(objectId));
            return httpResponseMessage;
        }

        /// <summary>
        /// Get person information based on FirstName.
        /// </summary>
        /// <param name="firstName">First Name</param>
        /// <returns>People</returns>
        public HttpResponseMessage GetByFirstName(string firstName)
        {
            HttpResponseMessage httpResponseMessage;
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, personRepository.GetEntitiesByFirstName(firstName));
            return httpResponseMessage;
        }

        /// <summary>
        /// Get person information based on LastName.
        /// </summary>
        /// <param name="lastName">Last Name</param>
        /// <returns>People</returns>
        public HttpResponseMessage GetByLastName(string lastName)
        {
            HttpResponseMessage httpResponseMessage;
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, personRepository.GetEntitiesByLastName(lastName));
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
            var createdPerson = personRepository.Add(person);
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created, createdPerson);
            httpResponseMessage.Headers.Location = new Uri($"{Request.RequestUri}/{createdPerson.Id}");
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
            person.Id = new ObjectId(id);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created, personRepository.Update(person));
            httpResponseMessage.Headers.Location = new Uri($"{Request.RequestUri}/{person.Id}");
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
            var objectId = new ObjectId(id);
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.Accepted, personRepository.Remove(objectId));
            return httpResponseMessage;
        }
    }
}