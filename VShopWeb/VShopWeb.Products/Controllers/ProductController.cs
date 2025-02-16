﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShopWeb.Products.DTOs;
using VShopWeb.Products.Exceptions;
using VShopWeb.Products.Services.Contracts;

namespace VShopWeb.Products.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductOutputDTO>> GetById(string id)
    {
        try
        {
            if (id == null)
                return BadRequest("Id can not be null!");

            var entity = await _productService.GetById(id);
            if (entity == null)
                return NotFound("Product not found on System!");

            return Ok(entity);
        }
        catch (ProductEntityException ex) 
        {
            return BadRequest(ex.Message);
        }
    }
    

    [HttpGet]
    public async Task<ActionResult<ProductOutputDTO>> GetAllIncludeCategory()
    {
        try
        {
            var entities = await _productService.GetAllIncludeCategory();

            if (entities == null)
                return NotFound("No products found on system!");

            return Ok(entities);
        }
        catch (ProductEntityException ex) 
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<ProductOutputDTO>> Create([FromBody] ProductInputDTO entity)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest("Product with invalid information!");
            
            var newProduct = await _productService.Create(entity);

            if (newProduct == null)
                return BadRequest("Was not possible to create product!");



            return Created("https://localhost:7176/Product", newProduct);
        }
        catch (ProductEntityException ex) 
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductOutputDTO>> Update(string id, [FromBody] ProductInputDTO entity)
    {
        try
        {
            if (id == null) return BadRequest("Id can not be null!");

            if (entity == null) return BadRequest("Invalid product informed!");

            if (id != entity.Id) return BadRequest("Product and informed id not equals!");

            var result = await _productService.Update(entity);

            if (result == null)
                return BadRequest("Was not possible to update entity");

            return Ok(result);
        }
        catch (ProductEntityException ex) 
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<ProductOutputDTO>> Delete(string id)
    {
        try
        {
            if (id == null) return BadRequest("Id must not be null!");

            var entity = await _productService.Delete(id);
            if (entity == null) return BadRequest("Entity either not found or was not possible to delete!");

            return Ok(entity);

        }
        catch (ProductEntityException ex)
        {
            return BadRequest(ex.Message);     
        }

    }

}
