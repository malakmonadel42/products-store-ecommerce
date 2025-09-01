using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Data;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context) => _context = context;

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
            => await _context.Products.ToListAsync();

        // POST: api/products  (إضافة منتج واحد)
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product product)
        {
            // لو بيجي من الفرونت id، خليّه 0 عشان الـ Identity يشتغل وما يصير تعارض
            product.Id = 0;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(PostProduct), new { id = product.Id }, product);
        }

        // PUT: api/products/{id}  (تعديل منتج)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, [FromBody] Product updated)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            product.Name = updated.Name;
            product.Image = updated.Image;
            product.Price = updated.Price;
            product.Qty = updated.Qty;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/products/{id} (حذف منتج)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
