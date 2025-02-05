using VShopWeb.Products.Models;

namespace VShopWeb.Products.Repository.Contracts;

public interface ICategoryRepository
{
    Task<Category> Create(Category category);
    Task<Category> Update(Category category);
    Task<Category> Delete(int id);
    Task<Category> Get(string id);
    Task<IEnumerable<Category>> GetAll();
    Task<IEnumerable<Category>> GetAllWithProducts();
}
