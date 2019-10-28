using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BiometricAPI.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class LogController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage httpResponseMessage;
            var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            var files = Directory.GetFiles(directory, "*.log");
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, files.ToList());
            return httpResponseMessage;
        }
    }
}
