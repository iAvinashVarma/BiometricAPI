using System.Web.Mvc;
using System.Web.Routing;

namespace BiometricAPI
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Help Area",
				url: string.Empty,
				defaults: new { controller = "Help", action = "Index"}
			).DataTokens = new RouteValueDictionary(new { area = "HelpPage" });
		}
	}
}