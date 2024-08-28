using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Application.Dtos;

public record CouponDto(
    Guid Id,
    string Code,
    string Description,
    int Amount,
    [Display(Name = "Discount Type")] string DiscountType,
    [Display(Name = "Start Date")] DateTime StateDate,
    [Display(Name = "End Date")] DateTime EndDate
    );
