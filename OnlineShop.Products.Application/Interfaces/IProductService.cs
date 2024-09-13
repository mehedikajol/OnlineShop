using OnlineShop.Products.Application.Dtos;
using OnlineShop.SharedKernel.Responses;

namespace OnlineShop.Products.Application.Interfaces;

public interface IProductService
{
    Task<IResponse> GetAllProductsAsync();
    Task<IResponse> AddProductAsync(ProductCreateDto dto);
}
