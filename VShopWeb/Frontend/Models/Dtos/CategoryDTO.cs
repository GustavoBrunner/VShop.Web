using System.ComponentModel.DataAnnotations;

namespace Frontend.Models.Dtos;

public record CategoryDTO(
    string? Id,
    [Required(ErrorMessage = "Category name is required!")]
    [MaxLength(100)]
    string Name,
    [Required(ErrorMessage = "Category description is required!")]
    [MaxLength (255)]
    string Description,
    IEnumerable<ProductDTO>? Products) {
}
