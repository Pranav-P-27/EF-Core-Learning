using Microsoft.EntityFrameworkCore;
using ProductShop.Domain.Common;
using ProductShop.Domain.Contracts;
using ProductShop.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext _dbcontext;
        public GenericRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            
        }
        public async Task<T> CreateAsync(T entity)
        {
            var res = await _dbcontext.Set<T>().AddAsync(entity); 
            await _dbcontext.SaveChangesAsync();
            return res.Entity;
        }

        public async Task DeleteAsync(T entity) 
        {
            _dbcontext.Remove(entity);
            await _dbcontext.SaveChangesAsync();
            
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
          return await _dbcontext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> condition)
        {
             return await _dbcontext.Set<T>().AsNoTracking().FirstOrDefaultAsync(condition);
        }
    }
}
