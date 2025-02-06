using AutoMapper;
using VShopWeb.Products.DTOs;
using VShopWeb.Products.Exceptions;
using VShopWeb.Products.Models;
using VShopWeb.Products.Repository.Contracts;
using VShopWeb.Products.Services.Contracts;

namespace VShopWeb.Products.Services;

public class ProductService : IProductService
{
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;

    public ProductService(IUnityOfWork unityOfWork, IMapper mapper)
    {
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    public async Task<ProductViewDTO> Create(ProductDTO product)
    {
        if (product == null) 
            throw new ProductEntityException("Invalid product informed!");

        var entity = _mapper.Map<Product>(product);

        await _unityOfWork.ProductRepository.Create(entity);
        if(!await _unityOfWork.Commit())
            throw new ProductEntityException("Not possible to create entity!");
        
        return _mapper.Map<ProductViewDTO>(entity);
    }
    public async Task<IEnumerable<ProductViewDTO>> GetAllIncludeCategory()
    {
        var products = await _unityOfWork.ProductRepository.GetAllWithCategory();
        if (!products.Any())
            throw new ProductEntityException("No product found on system!");

        return _mapper.Map<List<ProductViewDTO>>(products);
    }
    public async Task<IEnumerable<ProductViewDTO>> GetAll()
    {
        var products = await _unityOfWork.ProductRepository.GetAll();
        if(!products.Any())
            throw new ProductEntityException("No products found on system!");

        return _mapper.Map<List<ProductViewDTO>>(products);
    }

    public async Task<ProductViewDTO> GetById(string id)
    {
        var product = await _unityOfWork.ProductRepository.GetById(id) ?? 
            throw new Exception($"Product with id: {id} not found on system!");

        return _mapper.Map<ProductViewDTO>(product);
    }
    public async Task<ProductViewDTO> Update(ProductDTO product)
    {
        if (product == null)
            throw new ProductEntityException("Invalid product informed!");

        var entity = await _unityOfWork.ProductRepository.GetById(product.Id) ?? 
            throw new ProductEntityException("Entity not found on system!");

        MapProductToProduct(product, entity);
        await _unityOfWork.ProductRepository.Update(entity);

        if (!await _unityOfWork.Commit())
            throw new ProductEntityException("Was not possible to update entity!");
        return _mapper.Map<ProductViewDTO>(entity);
    }

    public async Task<ProductViewDTO> Delete(string id)
    {
        var entity = await _unityOfWork.ProductRepository.GetById(id) ?? 
            throw new ProductEntityException("Entity not found on system");


        await _unityOfWork.ProductRepository.Delete(entity);
        if(!await _unityOfWork.Commit())
            throw new ProductEntityException($"Unable to delete {entity.Name}");

        return _mapper.Map<ProductViewDTO>(entity);
    }


    private void MapProductToProduct(ProductDTO from, Product to)
    {
        to.Category = from.Category;
        to.Name = from.Name;
        to.Description = from.Description;
        to.Price = from.Price;
        to.Stock = from.Stock;
    }

}
