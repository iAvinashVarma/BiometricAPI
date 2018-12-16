using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BiometricAPI.Controllers
{
	public class LanguageController : Controller
	{
		// GET: Language
		public async Task<ActionResult> Index()
		{
			return await Task.Run(() => View());
		}

		public async Task<ActionResult> Change(string LanguageAbbrevation)
		{
			await Task.Factory.StartNew(() =>
			 {
				 if (!string.IsNullOrEmpty(LanguageAbbrevation))
				 {
					 Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
					 Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);
				 }

				 HttpCookie cookie = new HttpCookie("Language")
				 {
					 Value = LanguageAbbrevation
				 };
				 Response.Cookies.Add(cookie);
			 });

			return await Task.Run(() => RedirectToAction("Index", "Home"));
		}
	}
}