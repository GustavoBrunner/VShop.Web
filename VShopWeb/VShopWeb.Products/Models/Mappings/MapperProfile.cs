using AutoMapper;
using VShopWeb.Products.DTOs;

namespace VShopWeb.Products.Models.Mappings;

public class MapperProfile : Profile
{
    public MapperProfile() 
    { 
        CreateMap<ProductDTO, Product>()
            .ForMember(dest => dest.CategoryId, opt => opt.
                    MapFrom(src => src.Category != null ? src.Category.Id : string.Empty))
            .ReverseMap();
        CreateMap<ProductDTO, ProductViewDTO>()
            .ConstructUsing(src => new ProductViewDTO(src.Name, 
                                            src.Description, src.Price, 
                                            src.Stock, src.Category));

        CreateMap<ProductViewDTO, ProductDTO>();
        CreateMap<ProductViewDTO, Product>()
            .ReverseMap();
    }
    
}
