using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BiometricAPI.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ApiController
    {
        [AllowAnonymous]
        [ActionName("Get")]
        public HttpResponseMessage Get()
        {
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Unknown Error");
        }

        [AllowAnonymous]
        [ActionName("404")]
        [HttpGet]
        public HttpResponseMessage Status404()
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No resource matches the URL specified.");
        }

        [AllowAnonymous]
        [ActionName("400")]
        [HttpGet]
        public HttpResponseMessage Status400()
        {
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Empty);
        }

        [AllowAnonymous]
        [ActionName("500")]
        [HttpGet]
        public HttpResponseMessage Status500()
        {
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, string.Empty);
        }
    }
}
