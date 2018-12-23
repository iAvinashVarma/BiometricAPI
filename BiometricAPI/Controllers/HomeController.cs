using System.Threading.Tasks;
using System.Web.Mvc;

namespace BiometricAPI.Controllers
{
	/// <summary>
	/// Home Controller.
	/// </summary>
	public class HomeController : Controller
	{
		/// <summary>
		/// Home Index page action.
		/// </summary>
		/// <returns></returns>
		public async Task<ActionResult> Index()
		{
			ViewBag.Title = "Home Page";

			return await Task.Run(() => View());
		}
	}
}