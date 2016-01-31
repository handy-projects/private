using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;

namespace Private.Web.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var user = this.Request.HttpContext.User;
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Authorize(Policy = "ManageStore")]
        public async Task<IActionResult> Contact()
        {
            await this.HttpContext.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewData["Message"] = "Your contact page.";

            return new EmptyResult();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
