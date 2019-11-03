using AutoMapper;
using BiometricBLL.Cryptography;
using BiometricBLL.Model;
using BiometricBLL.Pattern.Factory;
using BiometricBLL.Pattern.Interface;
using MongoDB.Bson;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BiometricAPI.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly IUserRepository<User> userRepository = null;

        public AccountController()
        {
            userRepository = UserFactory.Repository;
        }

        /// <summary>
        /// Get user information based on id.
        /// </summary>
        /// <param name="id">Person Id</param>
        /// <returns>Person</returns>
        [Authorize]
        [HttpGet]
        public HttpResponseMessage GetById(string id)
        {
            HttpResponseMessage httpResponseMessage;
            var objectId = new ObjectId(id);
            var user = userRepository.GetById(objectId);
            var userInfo = Mapper.Map<User, UserInfo>(user);
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, userInfo);
            return httpResponseMessage;
        }

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="user">User Information</param>
        /// <returns>Created user</returns>
        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody] User user)
        {
            HttpResponseMessage httpResponseMessage;
            user.Password = PasswordHash.CreateHash(user.Password);
            var createdUser = userRepository.Add(user);
            var userInfo = Mapper.Map<User, UserInfo>(createdUser);
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created, userInfo);
            httpResponseMessage.Headers.Location = new Uri($"{Request.RequestUri}/{userInfo.Id}");
            return httpResponseMessage;
        }
    }
}