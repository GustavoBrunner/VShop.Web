using System.ComponentModel.DataAnnotations;

namespace Frontend.Models.Dtos;

public record CategoryNoProductsViewDTO(
    string? Id,
    
    string Name,
    
    string Description
    ) {
}
