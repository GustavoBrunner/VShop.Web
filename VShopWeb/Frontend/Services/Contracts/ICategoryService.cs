using Frontend.Models.Dtos;

namespace Frontend.Services.Contracts;

public interface ICategoryService
{
    Task<IEnumerable<CategoryNoProductsViewDTO>> GetAllCategoriesNoProducts();
    Task<IEnumerable<CategoryViewDTO>> GetAllCategories();
    Task<IEnumerable<CategoryViewDTO>> GetAllCategoryWithProducts();
    Task<CategoryViewDTO> GetCategoryWithProducts(string categoryName);
    Task<CategoryViewDTO> CreateCategory(CategoryDTO newCategory);
    Task<CategoryViewDTO> GetCategoryById(string id);
    Task<CategoryViewDTO> UpdateCategory(CategoryDTO category);
    Task<CategoryViewDTO> DeleteCategory(string id);
    Task<CategoryDTO> GetCategoryDTOById(string? id);
}
