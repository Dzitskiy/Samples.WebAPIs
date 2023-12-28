using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using OdataApp.Data;
using OdataApp.Data.Models;
using System.Linq;

namespace OdataApp.Controllers
{
    public class OdataUsersController : ODataController
    {
        private readonly AppDbContext _ctx;
        public OdataUsersController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        [EnableQuery]
        public IEnumerable<User> Get()
        {
            return _ctx.Users.Include(x => x.Comments).Include(x => x.Country).ToList();
        }

        [EnableQuery]
        public IActionResult Get([FromODataUri] int key)
        {
            var item = _ctx.Users.Include(x => x.Comments).SingleOrDefault(d => d.Id.Equals(key));

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        //[EnableQuery]
        //[HttpGet("odata/OdataUsers1/filter")]
        //public IActionResult Get(ODataQueryOptions<User> opts)
        //{
        //    var query = opts.ApplyTo(_ctx.Users.AsQueryable());

        //    var result = query;

        //    return Ok(result);
        //}
    }
}
