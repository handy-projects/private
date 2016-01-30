using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Private.Core.Domain;
using Private.Core.Repositories;


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
        public IActionResult Users()
        {
            var users = _usersRepo.Query().ToList();
            return Ok(users);
        }
    }
}
