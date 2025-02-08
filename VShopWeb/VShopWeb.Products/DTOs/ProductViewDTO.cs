using System.Text.Json.Serialization;
using VShopWeb.Products.Models;

namespace VShopWeb.Products.DTOs;

public record ProductViewDTO(
    string Id,
    string Name,
    string Description,
    decimal Price,
    long Stock,
    string ImageUrl
    ) {
}
