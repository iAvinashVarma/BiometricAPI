using log4net;
using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http.Filters;

namespace BiometricAPI.Infrastructure
{
    public class GenericExceptionFilterAttribute : ExceptionFilterAttribute, IExceptionFilter
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception == null) return;

            try
            {
                logger.Error(actionExecutedContext.Exception);
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionExecutedContext.Exception);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}