using VShopWeb.Products.Models;

namespace VShopWeb.Products.Repository.Contracts;

public interface IProductRepository
{
    Task<Product> GetById(string id);
    Task<IEnumerable<Product>> GetAllWithCategory();
    Task Create(Product product);
    Task Update(Product product);
    Task Delete(Product product);

}
