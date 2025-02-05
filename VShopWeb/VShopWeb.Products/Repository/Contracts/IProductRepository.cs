using VShopWeb.Products.Models;

namespace VShopWeb.Products.Repository.Contracts;

public interface IProductRepository
{
    Task<Product> GetById(string id);
    Task<IEnumerable<Product>> GetAll();
    Task<IEnumerable<Product>> GetAllWithCategory();
    Task<Product> Create(Product product);
    Task<Product> Update(Product product);
    Task<Product> Delete(Product product);

}
