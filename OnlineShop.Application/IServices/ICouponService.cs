using OnlineShop.Application.Dtos;
using OnlineShop.Application.Responses;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.IServices;

public interface ICouponService
{
    Task<IResponse> GetAllCouponsAsync();
    Task<IResponse> GetCouponByIdAsync(Guid id);
    Task<IResponse> GetCouponByCodeAsync(string code);
    Task<IResponse> CreateCouponAsync(CouponCreateDto dto);
    Task<IResponse> UpdateCouponAsync(CouponUpdateDto dto);
    Task<IResponse> DeleteCouponAsync(Guid id);
    Task<IResponse> GetPaged(PaginatedRequest request);
}
