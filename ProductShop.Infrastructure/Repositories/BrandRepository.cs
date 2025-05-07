using ProductShop.Domain.Contracts;
using ProductShop.Domain.Models;
using ProductShop.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Infrastructure.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository 
    {
        public BrandRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
        }

        public async Task UpdateAsync(Brand brand)
        {
            _dbcontext.Update(brand);
            await _dbcontext.SaveChangesAsync();

        }

    }
}
