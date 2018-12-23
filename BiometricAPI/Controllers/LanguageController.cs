using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BiometricAPI.Controllers
{
	/// <summary>
	/// Language Controller.
	/// </summary>
	public class LanguageController : Controller
	{
		/// <summary>
		/// Language Controller task creation.
		/// </summary>
		/// <returns></returns>
		// GET: Language
		public async Task<ActionResult> Index()
		{
			return await Task.Run(() => View());
		}

		/// <summary>
		/// Change language action.
		/// </summary>
		/// <param name="LanguageAbbrevation"></param>
		/// <returns></returns>
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