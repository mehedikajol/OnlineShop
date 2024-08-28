using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using OnlineShop.Infrastructure.Data;

namespace OnlineShop.Infrastructure.Repositories;

internal class CouponRepository : Repository<Coupon>, ICouponRepository
{
    public CouponRepository(AppDbContext context) 
        : base(context)
    {
    }
}
