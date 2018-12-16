using System.Threading.Tasks;
using System.Web.Mvc;

namespace BiometricAPI.Controllers
{
	public class HomeController : Controller
	{
		public async Task<ActionResult> Index()
		{
			ViewBag.Title = "Home Page";

			return await Task.Run(() => View());
		}
	}
}