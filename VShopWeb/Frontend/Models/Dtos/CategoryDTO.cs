using System.ComponentModel.DataAnnotations;

namespace Frontend.Models.Dtos;

public record CategoryDTO {
    public string? Id { get; init; }
    [Required(ErrorMessage = "Category name is required!")]
    [MaxLength(100)]
    public string Name { get; init; }
    [Required(ErrorMessage = "Category description is required!")]
    [MaxLength(255)]
    public string Description { get; init; }
    public IEnumerable<ProductDTO>? Products {  get; init; } 
}
