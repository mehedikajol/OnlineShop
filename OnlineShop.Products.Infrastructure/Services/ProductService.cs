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
        try
        {
            var products = await _repository.GetAllAsync();

            var productsDto = products
                .Select(product => new ProductDto(product.Id, product.Title, product.Description, product.Price))
                .ToList();

            return new SuccessResponse(productsDto, "Products retrieved", 200);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

            return new ErrorResponse("Failed to retrieve products", 500);
        }

    }

    public async Task<IResponse> GetProductAsync(Guid id)
    {
        try
        {
            var product = await _repository.GetAsync(id);
            if (product is null)
                return new ErrorResponse("Product not found", 404);

            var productDto = new ProductDto(product.Id, product.Title, product.Description, product.Price);

            return new SuccessResponse(productDto, "Product updated", 204);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new ErrorResponse("Error fetching product", 500);
        }
    }

    public async Task<IResponse> AddProductAsync(ProductCreateDto dto)
    {
        try
        {
            var productToAdd = new Product(dto.Title, dto.Description, dto.Price);
            await _repository.CreateAsync(productToAdd);
            return new SuccessResponse(null, "Product created", 201);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new ErrorResponse("Error adding product", 500);
        }
    }

    public async Task<IResponse> UpdateProductAsync(ProductUpdateDto dto)
    {
        try
        {
            var productToUpdate = await _repository.GetAsync(dto.Id);
            if (productToUpdate is null)
                return new ErrorResponse("Product not found", 404);

            productToUpdate.Update(dto.Title, dto.Description, dto.Price);
            await _repository.UpdateAsync(productToUpdate);
            return new SuccessResponse(null, "Product updated", 204);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new ErrorResponse("Error updating product", 500);
        }
    }

    public async Task<IResponse> DeleteProductAsync(Guid id)
    {
        try
        {
            var product = await _repository.GetAsync(id);
            if (product is null)
                return new ErrorResponse("Product not found", 404);

            await _repository.DeleteAsync(id);

            return new SuccessResponse(null, "Product deleted", 204);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new ErrorResponse("Error deleting product", 500);
        }
    }
}