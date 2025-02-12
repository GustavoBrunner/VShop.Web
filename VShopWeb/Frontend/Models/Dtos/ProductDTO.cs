using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Frontend.Models.Dtos;

public record ProductDTO
{
    public string? Id { get; init; } = string.Empty;

    [Required(ErrorMessage = "Product name is required!")]
    [MinLength(3)]
    [MaxLength(100)]
    public string Name { get; init; } = string.Empty;

    [MinLength(3)]
    [StringLength(255)]
    public string Description { get; init; } = string.Empty;

    [Required(ErrorMessage = "Product price is required!")]
    public decimal Price { get; init; }

    [Required(ErrorMessage = "Product stock is required!")]
    [Range(1, 9999)]
    [DefaultValue(200)]
    public long Stock { get; init; }

    public string CategoryId { get; init; } = string.Empty;

    [Required(ErrorMessage = "The product image is required!")]
    [MaxLength(255)]
    public string ImageUrl { get; init; } = string.Empty;

}
