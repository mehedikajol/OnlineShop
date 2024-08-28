using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dtos;
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
    public async Task<IResponse> GetAllAsync()
    {

        var response = await _couponService.GetAllCouponsAsync();
        return response;
    }

    [HttpGet("{id}")]
    public async Task<IResponse> GetAsync([FromRoute] Guid id)
    {
        var response = await _couponService.GetCouponByIdAsync(id);

        return response;
    }

    [HttpPost]
    public async Task<IResponse> CreateAsync([FromBody] CouponCreateDto dto)
    {
        var response = await _couponService.CreateCouponAsync(dto);
        return response;
    }

    [HttpPut("{id}")]
    public async Task<IResponse> UpdateAsync([FromRoute] Guid id, [FromBody] CouponUpdateDto dto)
    {
        if (id != dto.Id)
        {
            return new ErrorResponse("Invalid request", 400);
        }

        var coupon = await _couponService.GetCouponByIdAsync(id);

        if (coupon is null)
        {
            return new ErrorResponse("Coupon with provided id not found", 404);
        }

        var response = await _couponService.UpdateCouponAsync(dto);

        return response;
    }

    [HttpDelete("{id}")]
    public async Task<IResponse> DeleteAsync([FromRoute] Guid id)
    {

        var coupon = await _couponService.GetCouponByIdAsync(id);

        if (coupon is null)
        {
            return new ErrorResponse("Coupon with provided id not found", 404);
        }

        var response = await _couponService.DeleteCouponAsync(id);

        return response;
    }

}
