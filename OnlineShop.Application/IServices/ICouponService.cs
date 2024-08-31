using OnlineShop.Application.Dtos;
using OnlineShop.Application.Responses;

namespace OnlineShop.Application.IServices;

public interface ICouponService
{
    Task<IResponse> GetAllCouponsAsync();
    Task<IResponse> GetCouponByIdAsync(Guid id);
    Task<IResponse> GetCouponByCodeAsync(string code);
    Task<IResponse> CreateCouponAsync(CouponCreateDto dto);
    Task<IResponse> UpdateCouponAsync(CouponUpdateDto dto);
    Task<IResponse> DeleteCouponAsync(Guid id);
}
