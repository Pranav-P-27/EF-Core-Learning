using ProductShop.Domain.Models;
using ProductShop.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Infrastructure.Common
{
    public class SeedData
    {
        public static async Task SeedDataAsync(ApplicationDbContext _dbContext)
        {
            if (_dbContext.brands.Any())
            {
                await _dbContext.AddRangeAsync(
                    
                new Brand
                {
                    BrandName = "Apple",
                    EstablishedYead =  new DateTime(2012, 1, 1)
                },
                new Brand
                {
                    BrandName = "Samsung",
                    EstablishedYead =  new DateTime(2007, 1, 1)
                },
                new Brand
                {
                    BrandName = "Sony",
                    EstablishedYead =  new DateTime(2000, 1, 1)
                },
                new Brand
                {
                    BrandName = "Hp",
                    EstablishedYead =  new DateTime(2009, 1, 1)
                },
                new Brand
                {
                    BrandName = "Lenovo",
                    EstablishedYead =  new DateTime(2010, 1, 1)
                },
                new Brand
                {
                    BrandName = "Acer",
                    EstablishedYead =  new DateTime(2006, 1, 1)
                });
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
