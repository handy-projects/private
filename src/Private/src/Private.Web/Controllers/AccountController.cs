using Microsoft.AspNet.Mvc;
using Private.Infra.Extensions;
using Private.Web.ViewModels;
using System.Threading.Tasks;

namespace Private.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> LogIn(LogInVm model)
        {
            model.Validate();
            
            await model.Login();
            
            return model.IsLoginSuccess.Is(true) 
                ? RedirectToAction("Index", "Home") 
                : (ActionResult) View(model);
        }
    }
}
