using OnlineShop.Application.Dtos;
using OnlineShop.Application.Extenstions;
using OnlineShop.Application.IServices;
using OnlineShop.Application.Responses;
using OnlineShop.Domain.Enums;
using OnlineShop.Domain.Repositories;

namespace OnlineShop.Infrastructure.Services;

internal class CouponService : ICouponService
{
    private readonly ICouponRepository _couponRepository;

    public CouponService(ICouponRepository couponRepository)
    {
        _couponRepository = couponRepository;
    }

    public async Task<IResponse> GetAllCouponsAsync()
    {
        var coupons = await _couponRepository.GetAllAsync();
        var couponDtos = coupons.Select(p => p.ToCouponDto()).ToList();
        return new SuccessResponse(couponDtos);
    }

    public async Task<IResponse> GetCouponByIdAsync(Guid id)
    {
        var coupon = await _couponRepository.GetAsync(id);
        if (coupon is null)
        {
            return new ErrorResponse("Coupon with requested id is not found.", 404);
        }

        return new SuccessResponse(coupon.ToCouponDto());
    }

    public async Task<IResponse> GetCouponByCodeAsync(string code)
    {
        var coupon = await _couponRepository.GetAsync(p => p.Code == code);
        if (coupon is null)
        {
            return new ErrorResponse("Coupon with requested code is not found.", 404);
        }

        return new SuccessResponse(coupon.ToCouponDto());
    }

    public async Task<IResponse> CreateCouponAsync(CouponCreateDto dto)
    {
        if (dto is null)
        {
            return new ErrorResponse("Invalid request", 400);
        }

        await _couponRepository.CreateAsync(dto.ToCouponEntity());
        return new SuccessResponse(null, "Coupon created successfully", 201);
    }

    public async Task<IResponse> UpdateCouponAsync(CouponUpdateDto dto)
    {
        if (dto is null)
        {
            return new ErrorResponse("Invalid request", 400);
        }

        var coupon = await _couponRepository.GetAsync(dto.Id);
        if (coupon is null)
        {
            return new ErrorResponse("Coupon with requested id is not found.", 404);
        }

        coupon.Code = dto.Code;
        coupon.Description = dto.Description;
        coupon.DiscountType = EnumExtension.GetValueFromDescription<DiscountType>(dto.DiscountType);
        coupon.Amount = dto.Amount;
        coupon.StateDate = dto.StateDate;
        coupon.EndDate = dto.EndDate;

        await _couponRepository.UpdateAsync(coupon);
        return new SuccessResponse(null, "Coupon updated successfully", 204);
    }

    public async Task<IResponse> DeleteCouponAsync(Guid id)
    {
        var coupon = await _couponRepository.GetAsync(id);
        if (coupon is null)
        {
            return new ErrorResponse("Coupon with requested id is not found.", 404);
        }

        return new SuccessResponse(null, "Coupon deleted successfully", 204);
    }
}
