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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
        }

        public async Task UpdateAsync(Category category)
        {
            _dbcontext.Update(category);
            await _dbcontext.SaveChangesAsync();
            
        }
    }
}
