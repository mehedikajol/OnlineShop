using OnlineShop.Application.Extenstions;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Enums;

namespace OnlineShop.Application.Dtos;

public static class CouponMappingExtension
{
    public static Coupon ToCouponEntity(this CouponCreateDto dto)
    {
        return new Coupon
        {
            Code = dto.Code,
            Description = dto.Description,
            DiscountType = EnumExtension.GetValueFromDescription<DiscountType>(dto.DiscountType),
            Amount = dto.Amount,
            StateDate = dto.StateDate,
            EndDate = dto.EndDate,
        };
    }

    public static CouponDto ToCouponDto(this Coupon coupon)
    {
        return new CouponDto(
            coupon.Id,
            coupon.Code,
            coupon.Description,
            coupon.Amount,
            coupon.DiscountType.GetDescription(),
            coupon.StateDate,
            coupon.EndDate
            );
    }
}
