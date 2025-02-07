using AutoMapper;
using VShopWeb.Products.DTOs;

namespace VShopWeb.Products.Models.Mappings;

public class MapperProfile : Profile
{
    public MapperProfile() 
    {
        CreateMap<ProductDTO, Product>()
            .ForMember(dest => dest.CategoryId, map => map.
                    MapFrom(src => src.Category != null ? src.Category.Id : string.Empty))
            .ForMember(src => src.Id, map => map.Ignore())
            .ConstructUsing(dto => new Product(dto.Name, dto.Description, 
                            dto.Price, dto.Stock, dto.ImageUrl));
            

            
        CreateMap<ProductDTO, ProductViewDTO>()
            .ConstructUsing(src => new ProductViewDTO(src.Name, 
                                            src.Description, src.Price, 
                                            src.Stock, src.ImageUrl));
        CreateMap<ProductViewDTO, ProductDTO>();
        CreateMap<ProductViewDTO, Product>()
            .ReverseMap();
            

        //categories
        CreateMap<CategoryViewDTO, CategoryDTO>()
            .ReverseMap();
        CreateMap<CategoryDTO, Category>()
            .ForMember(dto => dto.Id, map => map.Ignore())
            .ConstructUsing(dto => new Category(dto.Description, dto.Name));
        CreateMap<Category, CategoryDTO>();

        CreateMap<Category, CategoryViewDTO>()
            .ReverseMap();

    }
    
}
