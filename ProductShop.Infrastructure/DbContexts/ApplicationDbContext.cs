using Microsoft.EntityFrameworkCore;
using ProductShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Infrastructure.DbContexts
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public System.Data.Entity.DbSet<Category> Category { get; set; }

        public System.Data.Entity.DbSet<Brand> brands { get; set; }

        public System.Data.Entity.DbSet<Product> Products { get; set; }


    }
}
