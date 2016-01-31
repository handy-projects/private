using Private.Infra.Errors;
using Private.Infra.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Private.Web.ViewModels
{
    public class LogInVm
    {
        private const string ADMIN_EMAIL = "wbserg@gmail.com";
        private const string ADMIN_PASSWORD = "a1b2c3d4!";

        public string Email { get; set; }

        public string Password { get; set; }

        public bool? IsLoginSuccess { get; private set; }

        public event Action LoginSuccess;

        public event Action LoginFailed;

        public void Validate()
        {
            if (Email.IsNullOrEmpty())
            {
                throw new ValidationError("Email is required");
            }

            if (Password.IsNullOrEmpty())
            {
                throw new ValidationError("Password is required");
            }
        }

        public async Task Login()
        {
            if(Email.Is(ADMIN_EMAIL) && Password.Is(ADMIN_PASSWORD))
            {
                IsLoginSuccess = true;
                // add cookie
                LoginSuccess.Raise();
            }
            else
                LoginFailed.Raise();
        }
    }
}
