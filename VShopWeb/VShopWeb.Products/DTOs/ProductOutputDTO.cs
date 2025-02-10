using System.Text.Json.Serialization;
using VShopWeb.Products.Models;

namespace VShopWeb.Products.DTOs;

public record ProductOutputDTO(
    string Id,
    string Name,
    string Description,
    decimal Price,
    long Stock,
    string CategoryName,
    string ImageUrl
    ) {
}
