using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Restore.API.BL;
using Restore.API.BL.Constant;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductServices _productService;

        public ProductsController(ProductServices productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int? pageNumber, string? sortBy, bool ascending = true)
        {
            if (pageNumber < 1)
            {
                return BadRequest("Page number must be greater than 0");
            }
            var products = await _productService.GetAllProductsAsync(
                pageNumber ?? PagingConstant.DefaultPageNumber,
                PagingConstant.DefaultPageSize,
                sortBy ?? PagingConstant.DefaultSortBy,
                ascending);
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var createdProduct = await _productService.AddProductAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var updatedProduct = await _productService.UpdateProductAsync(product);

            if (updatedProduct == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProductAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}