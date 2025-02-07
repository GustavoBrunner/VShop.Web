using System.Collections;

namespace VShopWeb.Products.DTOs;

public record CategoryDTO(
    string? Id, 
    string Name, 
    string Description, 
    IEnumerable<ProductDTO>? Products) {
}
