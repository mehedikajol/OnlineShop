using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.IServices;
using OnlineShop.Application.Responses;

namespace OnlineShop.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CouponsController : ControllerBase
{
    private readonly ICouponService _couponService;

    public CouponsController(ICouponService couponService)
    {
        _couponService = couponService;
    }

    [HttpGet]
    public async Task<IResponse> GetCoponsAsync() => await _couponService.GetAllCouponsAsync();
}
