using BiometricBLL.Concrete;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BiometricAPI.Controllers
{
    /// <summary>
    /// Environment APIs
    /// </summary>
    public class EnvironmentController : ApiController
    {
        /// <summary>
        /// Get UserName based on UserName
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <returns>User Name</returns>
        [HttpGet]
        public HttpResponseMessage GetUserName(string userName)
        {
            HttpResponseMessage httpResponseMessage;
            try
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, string.IsNullOrEmpty(userName) ? MongoCredential.Instance.UserName : userName);
            }
            catch (Exception ex)
            {
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            return httpResponseMessage;
        }
    }
}
