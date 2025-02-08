namespace VShopWeb.Products.DTOs;

public record CategoryViewDTO(
    string Id,
    string Name,
    string Description,
    IEnumerable<ProductViewDTO>? Products) {
}
