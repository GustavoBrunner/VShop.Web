using Frontend.Models.Dtos;
using Frontend.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetAllCategoryWithProducts();
        if (!categories.Any())
            return View("Error");

        return View(categories);
    }

    [HttpGet]
    public async Task<IActionResult> Register(string id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            var categoryUpdate = await _categoryService.GetCategoryDTOById(id);

            if (categoryUpdate == null)
                return View("Error");
            return View(categoryUpdate);
        }
        return View(new CategoryDTO());
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromForm] CategoryDTO categoryDTO)
    {
        if (categoryDTO == null)
            return View("Error");
        if (!string.IsNullOrEmpty(categoryDTO.Id))
        {
            var updateResult = await _categoryService.UpdateCategory(categoryDTO);
            if (updateResult == null)
            {
                return View("Error");
            }
            return RedirectToAction(nameof(Index));
        }
        var result = await _categoryService.CreateCategory(categoryDTO);
        if (result == null)
            return View("Error");

        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        if (string.IsNullOrEmpty(id)) 
            return View("Error");

        var category = await _categoryService.GetCategoryById(id);
        if (category == null)
            return View("Error");

        return View(category);
    }


    [HttpPost]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        if (string.IsNullOrEmpty(id))
            return View("Error");

        var result = await _categoryService.DeleteCategory(id);
        if(result == null)
            return View("Error");
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Products(string categoryName)
    {
        var category = await _categoryService.GetCategoryWithProducts(categoryName);
        if(category == null)
            return View("Error");
        return View(category);
    }



}
