using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShopWeb.Products.DTOs;
using VShopWeb.Products.Services.Contracts;

namespace VShopWeb.Products.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("/{string:id}")]
    public async Task<ActionResult<ProductViewDTO>> GetById(string id)
    {
        if (id == null)
            return BadRequest("Id can not be null!");

        var entity = await _productService.GetById(id);
        if(entity == null)
            return NotFound("Product not found on System!");

        return Ok(entity);
    }

}
