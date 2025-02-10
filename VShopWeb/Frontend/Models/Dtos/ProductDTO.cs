using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Frontend.Models.Dtos;

public record ProductDTO (
    string? Id,

    [Required(ErrorMessage = "Product name is required!")]
    [MinLength(3)]
    [MaxLength(100)]
    string Name,

    [MinLength(3)]
    [StringLength(255)]
    string Description,

    [Required(ErrorMessage = "Product price is required!")]
    decimal Price,

    [Required(ErrorMessage = "Product stock is required!")]
    [Range(1, 9999)]
    [DefaultValue(200)]
    long Stock,

    [Required(ErrorMessage = "The product image is required!")]
    [MaxLength(255)]
    string ImageUrl

    //Category? Category
    ) {

}
