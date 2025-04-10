using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoWebApi.Data;

using DemoWebApi.Domain.Entities;
using Unipluss.Sign.ExternalContract.Entities;
using Microsoft.EntityFrameworkCore;


namespace DemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DemoDbContext _demoDbContext;
        public ProductController(DemoDbContext demoDbContext)
        {
            _demoDbContext = demoDbContext;
        }

        /*************************************************/
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            //var products = _demoDbContext.Products.ToList();
            //return Ok(products);

            return _demoDbContext.Products;
        }

        /************************ READ *******************/


        [HttpGet("{id}")]
        public async Task<ActionResult<Product?>> GetById(int id)
        {
            var product = await _demoDbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            //return Ok(product);
            return await _demoDbContext.Products.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        /******************** CREATE *********************/

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            await _demoDbContext.Products.AddAsync(product);
            await _demoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        /********************** UPDATE *********************/

        [HttpPut]
        public async Task<ActionResult> Update(Product product)
        {
            _demoDbContext.Products.Update(product);
            await _demoDbContext.SaveChangesAsync();

            return Ok();
        }

        /********************** DELETE *********************/

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var productGetByIdResult = await GetById(id);
            if (productGetByIdResult.Value is null)
                return NotFound();
            _demoDbContext.Remove(productGetByIdResult.Value);
            await _demoDbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
