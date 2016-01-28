using Microsoft.AspNet.Mvc;

namespace Private.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
    }
}
