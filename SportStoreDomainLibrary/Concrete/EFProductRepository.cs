using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SportStoreDomainLibrary.Abstract;
using SportStoreDomainLibrary.Entities;

namespace SportStoreDomainLibrary.Concrete
{
    public class EFProductRepository : iProductRepository
    {
        SportStoreDbContext _context;
        public EFProductRepository()
        {
            _context = new SportStoreDbContext();
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProductAsync(int productId)
        {
            var prod = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            if (prod != null)
            {
                _context.Products.Remove(prod);
                await _context.SaveChangesAsync();
            }
        }

        public  Task<List<Product>> GetProductAsync()
        {
            return _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            var prod= _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            return await prod;
        }

        public Task<List<Product>> GetProductByCategoryAsync(string categoryName)
        {
            return _context.Products.Where(p => p.Category == categoryName).ToListAsync();
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            if (!_context.Products.Any(p => p.ProductId == product.ProductId))
            {
                _context.Products.Attach(product);
            }
            _context.Entry<Product>(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
