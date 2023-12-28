using WebApi.Models;

using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ApplicationDbContext context, ILogger<ProductsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return this._context.Products.ToArray();
        }


        //[HttpGet("{id}")]
        //[HttpGet()]
        //public async Task<IActionResult> GetWithRoute(int id)
        //public async Task<IActionResult> GetWithRoute([FromQuery]int id)
        //public async Task<IActionResult> GetWithRoute(int id, [FromQuery]int aux)
        //public async Task<IActionResult> GetWithRoute(int id, [FromHeader] int aux)
        //public async Task<IActionResult> GetWithRoute(int id, int aux)

        // GET api/<ProductsController>/5
        /// <summary>
        /// Test
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            this._context.Products.Add(product);
            await this._context.SaveChangesAsync();

            return CreatedAtAction(nameof(Post), new { id = product.Id }, product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] Product product)
        {
            var currentProduct = await _context.Products.FindAsync(product.Id);
            if (currentProduct == null)
            {
                return NotFound();
            }

            currentProduct.Name = product.Name;

            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await this._context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Remove(product);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}