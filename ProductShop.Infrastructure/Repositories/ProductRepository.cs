using Microsoft.EntityFrameworkCore;
using ProductShop.Domain.Contracts;
using ProductShop.Domain.Models;
using ProductShop.Infrastructure.DbContexts;
using ProductShop.Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Domain.Models.Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Domain.Models.Product>> GetAllProductsAsync()
        {
            return await _dbcontext.Products.Include(x => x.Category).Include(x => x.Brand).AsNoTracking().ToListAsync();
        }

        public async Task<Domain.Models.Product> GetDetailsAsync(int id)
        {
            return await _dbcontext.Products.Include(x=>x.Category).Include(x=>x.Brand).AsNoTracking().FirstOrDefaultAsync(x=>x.Id ==id);
        }


        public async Task UpdateAsync(Domain.Models.Product product)
        {
            _dbcontext.Update(product);
            await _dbcontext.SaveChangesAsync();

        }
    }
}
