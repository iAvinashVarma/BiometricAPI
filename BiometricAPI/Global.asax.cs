using BiometricAPI.Formatter;
using BiometricAPI.Infrastructure;
using System;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BiometricAPI
{
	/// <summary>
	/// 
	/// </summary>
	public class WebApiApplication : System.Web.HttpApplication
	{
		/// <summary>
		/// 
		/// </summary>
		protected void Application_Start()
		{
			var csvQueryStringMapping = new QueryStringMapping("format", "csv", "text/csv");
			var csvMediaTypeFormatter = new CSVMediaTypeFormatter(csvQueryStringMapping);
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			GlobalConfiguration.Configuration.Formatters.Add(csvMediaTypeFormatter);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterExceptionFilters(GlobalConfiguration.Configuration.Filters);
        }

        public static void RegisterExceptionFilters(HttpFilterCollection filters)
        {
            filters.Add(new GenericExceptionFilterAttribute());
        }
    }
}