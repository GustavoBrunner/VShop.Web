using VShopWeb.Products.Models;

namespace VShopWeb.Products.Repository.Contracts;

public interface ICategoryRepository
{
    Task Create(Category category);
    Task Update(Category category);
    Task Delete(string id);
    Task<Category> Get(string id);
    Task<IEnumerable<Category>> GetAll();
    Task<IEnumerable<Category>> GetAllWithProducts();
}
