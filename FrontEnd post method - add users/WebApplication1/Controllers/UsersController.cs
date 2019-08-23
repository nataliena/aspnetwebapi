using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }

    }
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static IList<User> _users = new List<User>
        {
            new User
            {
              Id=1,
              FirstName="User 1 FirstName",
              Lastname="User 1 LastName",
              Age=30
              },
            new User
            {
               Id=2,
              FirstName="User 2 FirstName",
              Lastname="User 2 LastName",
              Age=35
              },
            new User
            {
                Id=3,
              FirstName="User 3 FirstName",
              Lastname="User 3 LastName",
              Age=25
              },
            new User
            {
                Id=4,
              FirstName="User 4 FirstName",
              Lastname="User 4 LastName",
              Age=28
              },

            new User
            {
                Id=5,
              FirstName="User 5 FirstName",
              Lastname="User 5 LastName",
            
              }

        };
        [HttpGet]
        public ActionResult <List<User>> GetAllUsers()
        {
            return Ok(_users);


        }
        [HttpGet("{id}")]
        public ActionResult<User> GetUserByIndex(int id)
        {
            User user = _users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound($"User with id : {id} not found");

            }
            return Ok(user);

        }
        [HttpGet("{id}/isadult")]
        public ActionResult<User> GetAge(int id)
        {
            User user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound($"User with id : {id} not found");
            }
            else if (user.Age >= 18)
            {
                return Ok($"User with id :{id} is adult");
            }
            else
            {
                return Ok($"User with id :{id} is'nt adult");
            }



        }

        [HttpPost]
        public ActionResult<string> Post([FromBody]User obj)
        {
            User newUser = new User
            {
                Id = _users.Count() + 1,
                FirstName = obj.FirstName,
                Lastname = obj.Lastname
                
            };
            _users.Add(newUser);
            return Ok("Get a post request");
        }









    }
}