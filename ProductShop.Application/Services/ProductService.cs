using AutoMapper;
using ProductShop.Application.DTO.Category;
using ProductShop.Application.DTO.Product;
using ProductShop.Application.Services.Interface;
using ProductShop.Domain.Contracts;
using ProductShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Application.Services;
public class ProductService : IProductService
{
    private readonly IProductRepository _ProductRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository ProductRepository, IMapper mapper)
    {
        _ProductRepository = ProductRepository;
        _mapper = mapper;

    }
    public async Task<ProductDto> CreateAsync(CreateProductDto createProductDto)
    {
        var categor = _mapper.Map<Product>(createProductDto);
        var createdEntity = await _ProductRepository.CreateAsync(categor);
        var entity = _mapper.Map<ProductDto>(createdEntity);
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var Product = await _ProductRepository.GetByIdAsync(x => x.Id == id);
        await _ProductRepository.DeleteAsync(Product);
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var Product = await _ProductRepository.GetAllAsync();
        return _mapper.Map<List<ProductDto>>(Product);
    }

    public async Task<IEnumerable<ProductDto>> GetAllByFilterAsync(int? categoryId, int? brandId)
    {
        var res = await _ProductRepository.GetAllProductsAsync();
        if (categoryId > 0)
        {
            res = res.Where(x => x.CategoryId == categoryId);
        }
        if (brandId > 0)
        {
            res = res.Where(x => x.BrandId == brandId);
        }
        var finres = _mapper.Map<List<ProductDto>>(res);
        return finres;
    }

    public async Task<ProductDto> GetByIdAsync(int id)
    {
        var Product = await _ProductRepository.GetByIdAsync(x => x.Id == id);
        return _mapper.Map<ProductDto>(Product);

    }

    public async Task UpdateAsync(UpdateProductDto updateProductDto)
    {
        var Product = _mapper.Map<Product>(updateProductDto);
        await _ProductRepository.UpdateAsync(Product);
    }
}
