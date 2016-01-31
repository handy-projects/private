using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Private.Infra.Extensions;
using Private.Web.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Private.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet, AllowAnonymous]
        public ActionResult LogIn()
        { 
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> LogIn(LogInVm model)
        {
            model.Validate();
            
            model.LoginSuccess += async () =>
            {
                var claims = new List<Claim>
                {
                    new Claim("email", model.Email)
                };

                var id = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await this.Request.HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            };

            await model.Login();

            return model.IsLoginSuccess.Is(true) 
                ? RedirectToAction("Index", "Home") 
                : (ActionResult) View(model);
        }

        [HttpPost]
        public async Task<ActionResult> LogOut()
        {
            await this.Request.HttpContext.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("LogIn");
        }
    }
}
