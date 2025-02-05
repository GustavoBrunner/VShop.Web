using VShopWeb.Products.Models;

namespace VShopWeb.Products.Services.Contracts;

public interface IProductService 
{
    public Task<Product> Create(Product product);
    public Task<Product> GetById(int id);
    public Task<IEnumerable<Product>> GetAll();
    public Task<IEnumerable<Product>> GetAllIncludeCategory();
    public Task<Product> Update(Product product);
    public Task<Product> Delete(string id);

}
