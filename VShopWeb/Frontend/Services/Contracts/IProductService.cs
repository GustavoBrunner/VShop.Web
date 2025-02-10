using Frontend.Models.Dtos;

namespace Frontend.Services.Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductViewDTO>> GetAllProducts();
    Task<ProductViewDTO> GetProductById(string id);
    Task<IEnumerable<ProductViewDTO>> GetProductByCategory(string categoryName);
    Task<ProductViewDTO> CreateNewProduct(ProductDTO newProduct);
    Task<ProductViewDTO> UpdateProduct(ProductDTO product);
    Task<ProductViewDTO> DeleteProduct(string id);
}
