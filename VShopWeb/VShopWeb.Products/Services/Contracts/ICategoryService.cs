using VShopWeb.Products.DTOs;

namespace VShopWeb.Products.Services.Contracts;

public interface ICategoryService
{
    Task<List<CategoryViewDTO>> GetAllCategories();

    Task<CategoryViewDTO> GetById(string id);

    Task<List<CategoryViewDTO>> GetAllIncludeProduct();

    Task<CategoryViewDTO> Create(CategoryDTO entity);

    Task<CategoryViewDTO> Update(CategoryDTO entity);

    Task<CategoryViewDTO> Delete(string id);
    

}
