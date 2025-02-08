using AutoMapper;
using VShopWeb.Products.DTOs;
using VShopWeb.Products.Exceptions;
using VShopWeb.Products.Models;
using VShopWeb.Products.Repository.Contracts;
using VShopWeb.Products.Services.Contracts;

namespace VShopWeb.Products.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unityOfWork;
    private readonly IMapper _mapper;

    public ProductService(IUnitOfWork unityOfWork, IMapper mapper, ICategoryService categoryService)
    {
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    public async Task<ProductOutputDTO> Create(ProductInputDTO product)
    {
        if (product == null) 
            throw new ProductEntityException("Invalid product informed!");

        var entity = _mapper.Map<Product>(product);

        var category = await _unityOfWork.CategoryRepository.Get(entity.Category != null ?
                    entity.Category.Id : string.Empty);

        entity.Category = category;

        await _unityOfWork.ProductRepository.Create(entity);
        if(!await _unityOfWork.Commit())
            throw new ProductEntityException("Not possible to create entity!");
        
        return _mapper.Map<ProductOutputDTO>(entity);
    }


    public async Task<IEnumerable<ProductOutputDTO>> GetAllIncludeCategory()
    {
        var products = await _unityOfWork.ProductRepository.GetAllWithCategory();
        if (!products.Any())
            throw new ProductEntityException("No product found on system!");

        return _mapper.Map<List<ProductOutputDTO>>(products);
    }



    public async Task<ProductOutputDTO> GetById(string id)
    {
        var product = await _unityOfWork.ProductRepository.GetById(id) ?? 
            throw new Exception($"Product with id: {id} not found on system!");

        return _mapper.Map<ProductOutputDTO>(product);
    }


    public async Task<ProductOutputDTO> Update(ProductInputDTO product)
    {
        if (product == null)
            throw new ProductEntityException("Invalid product informed!");

        var entity = await _unityOfWork.ProductRepository.GetById(product.Id) ?? 
            throw new ProductEntityException("Entity not found on system!");

        MapProductToProduct(product, entity);

        await _unityOfWork.ProductRepository.Update(entity);

        if (!await _unityOfWork.Commit())
            throw new ProductEntityException("Was not possible to update entity!");
        return _mapper.Map<ProductOutputDTO>(entity);
    }


    public async Task<ProductOutputDTO> Delete(string id)
    {
        var entity = await _unityOfWork.ProductRepository.GetById(id) ?? 
            throw new ProductEntityException("Entity not found on system");


        await _unityOfWork.ProductRepository.Delete(entity);
        if(!await _unityOfWork.Commit())
            throw new ProductEntityException($"Unable to delete {entity.Name}");

        return _mapper.Map<ProductOutputDTO>(entity);
    }


    private void MapProductToProduct(ProductInputDTO from, Product to)
    {
        to.Category = from.Category;
        to.Name = from.Name;
        to.Description = from.Description;
        to.Price = from.Price;
        to.Stock = from.Stock;
    }

}
