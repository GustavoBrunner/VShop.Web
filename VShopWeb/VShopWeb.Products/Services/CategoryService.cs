using AutoMapper;
using VShopWeb.Products.DTOs;
using VShopWeb.Products.Exceptions;
using VShopWeb.Products.Models;
using VShopWeb.Products.Repository.Contracts;
using VShopWeb.Products.Services.Contracts;

namespace VShopWeb.Products.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unityOfWork, IMapper mapper)
    {
        _unitOfWork = unityOfWork;
        _mapper = mapper;
    }

    public async Task<List<CategoryOutputDTO>> GetAllCategories()
    {
        var categories = await _unitOfWork.CategoryRepository.GetAll() ?? 
            throw new CategoryEntityException("No category found on system!");

        var categoriesMapped =  _mapper.Map<List<CategoryOutputDTO>>(categories);
        return categoriesMapped;
    }

    public async Task<List<CategoryOutputDTO>> GetAllIncludeProduct()
    {
        var categories = await _unitOfWork.CategoryRepository.GetAllWithProducts() ??
            throw new CategoryEntityException("No category found on system!");

        var categoriesMapped = _mapper.Map<List<CategoryOutputDTO>>(categories);

        return categoriesMapped;
    }

    public async Task<CategoryOutputDTO> GetById(string id)
    {
        if (string.IsNullOrEmpty(id))
            throw new CategoryEntityException("Invalid id informed, null or empty!");

        var category = await _unitOfWork.CategoryRepository.Get(id) ??
            throw new CategoryEntityException("Category not found on system!");

        var categoryMapped = _mapper.Map<CategoryOutputDTO>(category);
        return categoryMapped;
    }

    public async Task<CategoryOutputDTO> Create(CategoryInputDTO entity)
    {
        if (entity == null)
            throw new CategoryEntityException("Invalid category data!");

        var category = _mapper.Map<Category>(entity);
        await _unitOfWork.CategoryRepository.Create(category);

        if (!await _unitOfWork.Commit())
            throw new CategoryEntityException("Was not possible to create category!");

        return _mapper.Map<CategoryOutputDTO>(category);
    }

    public async Task<CategoryOutputDTO> Delete(string id)
    {
        if (string.IsNullOrEmpty(id))
            throw new CategoryEntityException("Informed id invalid: Null or Empty!");

        var category = await _unitOfWork.CategoryRepository.Get(id) ??
            throw new CategoryEntityException("Category not found on system!");

        await _unitOfWork.CategoryRepository.Delete(id);
        if (!await _unitOfWork.Commit())
            throw new CategoryEntityException($"Could not remove category: {category.Name}");

        var categoryMapped = _mapper.Map<CategoryOutputDTO>(category);

        return categoryMapped;
    }

    public async Task<CategoryOutputDTO> Update(CategoryInputDTO entity)
    {
        if (entity == null)
            throw new CategoryEntityException("Invalid category data!");

        var category = await _unitOfWork.CategoryRepository.Get(entity.Id) ??
            throw new CategoryEntityException("Category not found on system!");

        MapCategoryToCategory(entity, category);

        await _unitOfWork.CategoryRepository.Update(category);

        if (!await _unitOfWork.Commit())
            throw new CategoryEntityException("Was not possible to update category!");

        return _mapper.Map<CategoryOutputDTO>(category);
    }
    public async Task<CategoryOutputDTO> GetByName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new CategoryEntityException("Name can not be null or empty");

        var category = await _unitOfWork.CategoryRepository.GetByName(name) ??
            throw new CategoryEntityException("Category not found on System!");

        var mappedCategory = _mapper.Map<CategoryOutputDTO>(category);

        return mappedCategory;

    }
    void MapCategoryToCategory(CategoryInputDTO from, Category to)
    {
        to.Id = from.Id;
        to.Name = from.Name;
        to.Description = from.Description;
        var viewProducts = _mapper.Map<List<Product>>(from.Products);
        to.Products = viewProducts;
    }

    
}
