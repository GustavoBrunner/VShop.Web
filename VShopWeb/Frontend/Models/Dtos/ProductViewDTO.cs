
namespace Frontend.Models.Dtos;

public record ProductViewDTO(
    string Id,

    string Name,

    string Description,

    decimal Price,

    long Stock,

    string ImageUrl,

    string CategoryName)
{
}
