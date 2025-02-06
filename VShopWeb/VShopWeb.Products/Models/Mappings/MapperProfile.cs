using AutoMapper;
using VShopWeb.Products.DTOs;

namespace VShopWeb.Products.Models.Mappings;

public class MapperProfile : Profile
{
    public MapperProfile() 
    { 
        CreateMap<Product, ProductDTO>()
            .ReverseMap();
        CreateMap<ProductDTO, ProductViewDTO>()
            .ConstructUsing(src => new ProductViewDTO(src.Name, 
                                            src.Description, src.Price, 
                                            src.Stock, src.Category));

        CreateMap<ProductViewDTO, ProductDTO>();
        CreateMap<ProductViewDTO, Product>()
            .ReverseMap();
        CreateMap<List<ProductDTO>, List<Product>>()
            .ReverseMap();
        CreateMap<List<Product>, List<ProductViewDTO>>();
        CreateMap<Product, Product>();
    }
}
