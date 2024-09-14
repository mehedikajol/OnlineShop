using OnlineShop.Products.Application.Dtos;
using OnlineShop.SharedKernel.Responses;

namespace OnlineShop.Products.Application.Interfaces;

public interface IProductService
{
    Task<IResponse> GetAllProductsAsync();
    Task<IResponse> GetProductAsync(Guid id);
    Task<IResponse> AddProductAsync(ProductCreateDto dto);
    Task<IResponse> UpdateProductAsync(ProductUpdateDto dto);
    Task<IResponse> DeleteProductAsync(Guid id);
}
