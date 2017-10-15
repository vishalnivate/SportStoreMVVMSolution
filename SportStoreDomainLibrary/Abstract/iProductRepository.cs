using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportStoreDomainLibrary.Entities;
namespace SportStoreDomainLibrary.Abstract
{
    public interface iProductRepository
    {
        Task<List<Product>> GetProductAsync();
        Task<List<Product>> GetProductByCategoryAsync(string categoryName);
        Task<Product> GetProductAsync(int productId);
        Task<Product> AddProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task DeleteProductAsync(int productId);
    }
}
