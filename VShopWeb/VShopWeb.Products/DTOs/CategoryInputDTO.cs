using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace VShopWeb.Products.DTOs;

public record CategoryInputDTO(
    string? Id,
    [Required(ErrorMessage = "Category name is required!")]
    [MaxLength(100)]
    string Name,
    [Required(ErrorMessage = "Category description is required!")]
    [MaxLength (255)]
    string Description, 
    IEnumerable<ProductInputDTO>? Products) {
}
