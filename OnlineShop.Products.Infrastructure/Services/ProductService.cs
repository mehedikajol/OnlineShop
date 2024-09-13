using OnlineShop.Products.Application.Dtos;
using OnlineShop.Products.Application.Interfaces;
using OnlineShop.Products.Domain.Entities;
using OnlineShop.SharedKernel.Repositories;
using OnlineShop.SharedKernel.Responses;

namespace OnlineShop.Products.Infrastructure.Services;

internal class ProductService : IProductService
{
    private readonly IRepository<Product, Guid> _repository;

    public ProductService(IRepository<Product, Guid> repository)
    {
        _repository = repository;
    }

    public async Task<IResponse> GetAllProductsAsync()
    {
        var products = await _repository.GetAllAsync();

        var response = new SuccessResponse
        {
            Data = products,
            StatusCode = 200
        };

        return response;
    }

    public async Task<IResponse> AddProductAsync(ProductCreateDto dto)
    {
        var productToAdd = new Product
        {
            Title = dto.Title,
            Description = dto.Description,
            Price = dto.Price,
        };
        await _repository.CreateAsync(productToAdd);
        return new SuccessResponse(null, "Product created", 201);
    }
}
