using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Restore.API.BL
{
    public class ProductServices
    {
        private readonly StoreContext _context;

        public ProductServices(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(int pageNumber, int pageSize, string sortBy, bool ascending)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(sortBy))
            {
                query = ascending ? query.OrderBy(p => EF.Property<object>(p, sortBy)) : query.OrderByDescending(p => EF.Property<object>(p, sortBy));
            }

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        internal async Task GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}