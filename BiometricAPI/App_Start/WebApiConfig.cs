using Microsoft.Owin.Security.OAuth;
using System.Web.Http;

namespace BiometricAPI
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

            config.Routes.MapHttpRoute(
                name: "DefaultCatchall",
                routeTemplate: "api/{*url}",
                defaults: new
                {
                    controller = "Error",
                    action = "404"
                }
            );

            config.Formatters.XmlFormatter.UseXmlSerializer = true;
		}
	}
}