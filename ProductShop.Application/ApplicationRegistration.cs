using Microsoft.Extensions.DependencyInjection;
using ProductShop.Application.Common;
using ProductShop.Application.Services;
using ProductShop.Application.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Application
{
    public static class ApplicationRegistration 
    {
        public static IServiceCollection AddApplicationServices( this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IProductService, ProductService>();
            return services;
        }

    }
}
