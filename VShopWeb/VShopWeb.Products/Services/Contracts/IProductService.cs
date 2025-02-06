using VShopWeb.Products.DTOs;
using VShopWeb.Products.Models;

namespace VShopWeb.Products.Services.Contracts;

public interface IProductService 
{
    public Task<ProductViewDTO> Create(ProductDTO product);
    public Task<ProductViewDTO> GetById(string id);
    public Task<IEnumerable<ProductViewDTO>> GetAll();
    public Task<IEnumerable<ProductViewDTO>> GetAllIncludeCategory();
    public Task<ProductViewDTO> Update(ProductDTO product);
    public Task<ProductViewDTO> Delete(string id);

}
