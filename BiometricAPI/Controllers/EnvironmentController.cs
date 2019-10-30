using BiometricBLL.Concrete;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BiometricAPI.Controllers
{
    /// <summary>
    /// Environment APIs
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
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
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, string.IsNullOrEmpty(userName) ? DatabaseCredential.Instance.UserName : userName);
            return httpResponseMessage;
        }
    }
}
