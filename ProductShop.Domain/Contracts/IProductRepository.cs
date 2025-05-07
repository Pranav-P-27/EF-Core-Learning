using ProductShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Domain.Contracts
{
    public interface IProductRepository :IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetDetailsAsync(int id);

        Task UpdateAsync(Product product);
    }
}
