using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Odev1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User> UserList = new List<User>()
        {
            new User
            {
                Id = 1,
                Name ="Abdullah",
                SurName = "Erek",
                Password="123"
            },
            new User
            {
                Id = 2,
                 Name ="Berke",
                SurName = "Özbek",
                Password="123456"
            },
            new User
            {
                Id = 3,
                Name ="Serhat",
                SurName = "Saat",
                Password="serhat123"
            }
        };

        [HttpGet]
        public List<User> GetUser()
        {
            return UserList;
        }

        [HttpGet(template: "{id}")]
        public User GetUserById(int id)
        {
            var user = UserList.SingleOrDefault(user => user.Id == id);
            return user;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User addNewUser)
        {
            var user = UserList.SingleOrDefault(u => u.Id == addNewUser.Id);

            if (user is not null)
                return BadRequest();

            UserList.Add(addNewUser);
            return Ok();
        }

        [HttpPut(template: "{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = UserList.SingleOrDefault(u => u.Id == id);

            if (user is null)
                return BadRequest();

            user.Name = updatedUser.Name != default ? updatedUser.Name : user.Name;
            user.SurName = updatedUser.SurName != default ? updatedUser.SurName : user.SurName;
            user.Password = updatedUser.Password != default ? updatedUser.Password : user.Password;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = UserList.SingleOrDefault(u => u.Id == id);

            if (user is null)
            {
                return BadRequest();
            }

            UserList.Remove(user);
            return Ok();
        }


    }
}
