using Microsoft.AspNetCore.Mvc;

namespace OdataApp.Controllers
{

    public class User1
    {
        public string Name { get; set; }
    }

    [ApiController]
    [Route("/api/data")]
    public class DataController : ControllerBase
    {
    

        private List<User1> _users = new List<User1> { new User1() { Name = "User" } };


        [HttpGet("GetSampleData")]
        public string Index()
        {
            return Guid.NewGuid().ToString();
        }

        [HttpGet("GetUsers")]
        public List<User1> GetAllUsers()
        {
            return _users;
        }

        [HttpGet("GetUserByName")]
        public User1 GetByName([FromQuery] string name)
        {
            return _users.FirstOrDefault(x => x.Name == name);
        }


        [HttpPost("UpdateUser")]
        public User1 UpdateUser([FromQuery] string name)
        {
            return _users.FirstOrDefault(x => x.Name == name);
        }
    }
}
