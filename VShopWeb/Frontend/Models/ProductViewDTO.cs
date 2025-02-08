using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Frontend.Models;

public record ProductViewDTO(
    
    string Name,
    
    string Description,

    decimal Price,

    long Stock,

    string ImageUrl,

    string CategoryName){

}
