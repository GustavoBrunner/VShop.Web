using AutoMapper;
using VShopWeb.Products.DTOs;

namespace VShopWeb.Products.Models.Mappings;

public class MapperProfile : Profile
{
    public MapperProfile() 
    {
        CreateMap<ProductInputDTO, Product>()
            .ForMember(dest => dest.CategoryId, map => map.
                    MapFrom(src => src.Category != null ? src.Category.Id : string.Empty))
            .ForMember(src => src.Id, map => map.Ignore())
            .ConstructUsing(dto => new Product(dto.Name, dto.Description, 
                            dto.Price, dto.Stock, dto.ImageUrl));
            

            
        CreateMap<ProductInputDTO, ProductOutputDTO>()
            .ConstructUsing(src => new ProductOutputDTO(src.Id,src.Name, 
                                            src.Description, src.Price, 
                                            src.Stock, src.ImageUrl));
        CreateMap<ProductOutputDTO, ProductInputDTO>();
        CreateMap<ProductOutputDTO, Product>()
            .ReverseMap();
            

        //categories
        CreateMap<CategoryOutputDTO, CategoryInputDTO>()
            .ReverseMap();
        CreateMap<CategoryInputDTO, Category>()
            .ForMember(dto => dto.Id, map => map.Ignore())
            .ConstructUsing(dto => new Category(dto.Description, dto.Name));
        CreateMap<Category, CategoryInputDTO>();

        CreateMap<Category, CategoryOutputDTO>()
            .ReverseMap();

    }
    
}
