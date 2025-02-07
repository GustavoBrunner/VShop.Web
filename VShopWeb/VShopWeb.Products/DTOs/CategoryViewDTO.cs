namespace VShopWeb.Products.DTOs;

public record CategoryViewDTO(
    string Name,
    string Description,
    IEnumerable<ProductViewDTO> Products) {
}
