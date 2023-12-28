using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdataApp.Data;
using OdataApp.Data.Models;

namespace OdataApp.Controllers
{


    public class UpdateUserRequest
    {
        public string Username { get; set; }
    }


    public class CreateUserRequest
    {
        public int Id { get; set; }
        public string Username { get; set; }


        public string Email { get; set; }

        public int Age { get; set; }
    }


    [Route("/api/v1/users")]
    public class UserV1Controller : Controller
    {
        private readonly AppDbContext _ctx;
        public UserV1Controller(AppDbContext ctx)
        {

            _ctx = ctx;
        }


        [HttpGet]
        public List<User> GetUsers()
        {
            return _ctx.Users.ToList();
        }


        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _ctx.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpGet("{id}/comments")]
        public IActionResult GetCommentsOfUser(int id)
        {
            var user = _ctx.Users.Include(x => x.Comments).FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.Comments.Select(x => new { Text = x.Text }));
        }

        private void CheckAccess(CreateUserRequest user)
        {
            // если не админ
            // то
            throw new Exception();
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest user)
        {
            var id = _ctx.Users.Max(x => x.Id) + 1;

            user.Id = id;
            var newUser = new User
            {
                Id = id,
                Username = user.Username,
                Email = user.Username + "@ya.ru",
                Age = 37,
            };
            _ctx.Users.Add(newUser);


            // Validator.ValidateSave(user)


            _ctx.SaveChanges();
            return Created("", user.Id);
        }


        [HttpPost("{id}/send-to-space")]
        public IActionResult Archive(int id)
        {
            // Какой-то код
            return Ok("");
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateUserRequest user)
        {


            var existing = _ctx.Users.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                return NotFound(user);
            }

            //existing.Age = user.Age;
            existing.Username = user.Username;
            //existing.Email = user.Email;
            //existing.CountryId = user.CountryId;
            _ctx.Users.Update(existing);
            _ctx.SaveChanges();
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var existing = _ctx.Users.FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                return NotFound(id);
            }


            _ctx.Users.Remove(existing);
            _ctx.SaveChanges();
            return Ok();
        }
    }
}
