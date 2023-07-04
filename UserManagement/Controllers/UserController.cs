using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public UserController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
          List<User> users = _appDbContext.Users.ToList();
          return Ok(users);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult GetUserById(int Id)
        {
            User user = _appDbContext.Users.First(x => x.Id == Id);
            return Ok(user);
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
            return CreatedAtRoute(nameof(GetUserById), new { Id = user.Id }, user);
        }
    }
}
