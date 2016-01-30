using Microsoft.AspNet.Mvc;
using Private.Web.ViewModels;

namespace Private.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LogIn(LogInVm model)
        {
            model.Validate();

            model.LoginSuccess += () => RedirectToAction("Index", "Home");

            return RedirectToAction("Index", "Home");
        }
    }
}
