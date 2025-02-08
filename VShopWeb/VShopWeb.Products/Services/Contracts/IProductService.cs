using VShopWeb.Products.DTOs;
using VShopWeb.Products.Models;

namespace VShopWeb.Products.Services.Contracts;

public interface IProductService 
{
    public Task<ProductOutputDTO> Create(ProductInputDTO product);
    public Task<ProductOutputDTO> GetById(string id);
    public Task<IEnumerable<ProductOutputDTO>> GetAllIncludeCategory();
    public Task<ProductOutputDTO> Update(ProductInputDTO product);
    public Task<ProductOutputDTO> Delete(string id);

}
