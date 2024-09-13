using Microsoft.AspNetCore.Mvc;
using OnlineShop.Products.Application.Dtos;
using OnlineShop.Products.Application.Interfaces;

namespace OnlineShop.Products.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductCreateDto dto)
    {
        var response = await _productService.AddProductAsync(dto);

        return Ok(response);
    }
}
