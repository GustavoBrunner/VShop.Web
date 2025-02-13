using VShopWeb.Products.DTOs;

namespace VShopWeb.Products.Services.Contracts;

public interface ICategoryService
{
    Task<List<CategoryOutputDTO>> GetAllCategories();

    Task<CategoryOutputDTO> GetById(string id);

    Task<List<CategoryOutputDTO>> GetAllIncludeProduct();
    Task<CategoryOutputDTO> GetByName(string name);

    Task<CategoryOutputDTO> Create(CategoryInputDTO entity);

    Task<CategoryOutputDTO> Update(CategoryInputDTO entity);

    Task<CategoryOutputDTO> Delete(string id);
    

}
