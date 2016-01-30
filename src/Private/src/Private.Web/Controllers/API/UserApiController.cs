using Microsoft.AspNet.Mvc;
using System.Linq;
using Private.Core.Domain;
using Private.Core.Repositories;
using Private.Web.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace Private.Web.Controllers.API
{
    public class UserApiController : ApiController
    {
        private readonly IRepository<User> _usersRepo;

        public UserApiController(IRepository<User> usersRep)
        {
            _usersRepo = usersRep;
        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var uservm = new UserVm();
            uservm.Creating += async () =>
            {
                Thread.Sleep(10000);
                var t = 56 + 23;
            };

            var users = _usersRepo.Query().ToList();
            Task.Run(async () => await uservm.Create());
            return Ok(users);
        }
    }
}
