﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShopWeb.Products.DTOs;
using VShopWeb.Products.Exceptions;
using VShopWeb.Products.Services.Contracts;

namespace VShopWeb.Products.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryViewDTO>>> GetAll()
    {
        try
        {
            var categories = await _categoryService.GetAllCategories();
            if (!categories.Any())
                return NotFound("No category found on system!");

            return Ok(categories);
        }
        catch(CategoryEntityException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("products/")]
    public async Task<ActionResult<IEnumerable<CategoryViewDTO>>> GetAllIncludeProduct()
    {
        try
        {
            var categories = await _categoryService.GetAllIncludeProduct();
            if (!categories.Any())
                return NotFound("No category found on system!");

            return Ok(categories);
        }
        catch (CategoryEntityException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryViewDTO>> GetById(string id)
    {
        try
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Id null or empty informed");

            var category = await _categoryService.GetById(id);
            if (category == null)
                return NotFound("Category not found on system!");

            return Ok(category);
        }
        catch(CategoryEntityException ex)  
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<ActionResult<CategoryViewDTO>> Create([FromBody] CategoryDTO categoryDTO)
    {
        try
        {
            if (categoryDTO == null)
                return BadRequest("Invalid category data!");

            var result = await _categoryService.Create(categoryDTO);
            if (result == null)
                return BadRequest($"Was not possible to create category {categoryDTO.Name}");

            return Ok(result);
        }
        catch (CategoryEntityException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<CategoryViewDTO>> Update(string id, [FromBody] CategoryDTO categoryDTO)
    {
        try
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Id null or empty");
            if (categoryDTO == null)
                return BadRequest("Invalid category data!");
            if (id != categoryDTO.Id)
                return BadRequest("Id and category Id must be the same!");

            var category = await _categoryService.GetById(id);
            if (category == null)
                return NotFound("Category not found on system!");

            var result = await _categoryService.Update(categoryDTO);

            if (result == null)
                return BadRequest($"Was not possible to edit category {categoryDTO.Name}");

            return Ok(result);

        }
        catch (CategoryEntityException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<CategoryViewDTO>> Delete(string id)
    {
        try
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("Invalid id informed, Null or Empty!");

            var category = await _categoryService.GetById(id);
            if (category == null)
                return NotFound("Category not found on system!");

            var result = await _categoryService.Delete(id);
            if (result == null)
                return BadRequest($"Was not possible to delete category: {category.Name}");

            return Ok(result);

        }
        catch(CategoryEntityException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
