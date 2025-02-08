namespace VShopWeb.Products.DTOs;

public record CategoryOutputDTO(
    string Id,
    string Name,
    string Description,
    IEnumerable<ProductOutputDTO>? Products) {
}
