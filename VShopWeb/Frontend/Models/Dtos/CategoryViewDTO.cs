
namespace Frontend.Models.Dtos;

public record CategoryViewDTO(
    string? Id,
    
    string Name,
    
    string Description,

    IEnumerable<ProductDTO>? Products) {

}
