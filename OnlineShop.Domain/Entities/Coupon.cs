using OnlineShop.Domain.Entities.Base;
using OnlineShop.Domain.Enums;

namespace OnlineShop.Domain.Entities;

public class Coupon : Entity<Guid>
{
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Amount { get; set; }
    public DiscountType DiscountType { get; set; }
    public DateTime StateDate { get; set; }
    public DateTime EndDate { get; set; }
}
