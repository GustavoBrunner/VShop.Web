using Frontend.Models.Dtos;
using Frontend.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Frontend.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProducts();
            if (!products.Any())
                return View("Error");

            return View(products);  
        }

        [HttpGet]
        public async Task<IActionResult> Register(string id)
        {
            var categories = await _categoryService.GetAllCategories();

            SelectList list = new(categories, "Id", "Name");
            ViewBag.Categories = list;

            if (!string.IsNullOrEmpty(id))
            {
                var product = await _productService.GetProductDTOById(id);

                if(product == null)
                    return View("Error");

                return View(product);
            }
            
            return View(new ProductDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] ProductDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            if (!string.IsNullOrEmpty(dto.Id)) 
            {
                //item update
                var updateResult = await _productService.UpdateProduct(dto);
                if (updateResult == null) 
                    return View("Error");

                return RedirectToAction("Index");

            }
            
            var result = await _productService.CreateNewProduct(dto);

            if (result == null)
                return View("Error");
             

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("Error");

            var product = await _productService.GetProductById(id);
            if (product == null)
                return View("Error");

            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            if(string.IsNullOrEmpty(id))
                return View("Error");

            var product = await _productService.DeleteProduct(id);

            if(product == null)
                return View("Error");

            return RedirectToAction(nameof(Index));
        }

    }
}
