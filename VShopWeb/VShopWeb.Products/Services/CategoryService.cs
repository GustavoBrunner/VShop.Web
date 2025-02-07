﻿using AutoMapper;
using VShopWeb.Products.DTOs;
using VShopWeb.Products.Exceptions;
using VShopWeb.Products.Models;
using VShopWeb.Products.Repository.Contracts;
using VShopWeb.Products.Services.Contracts;

namespace VShopWeb.Products.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;

    public CategoryService(IUnityOfWork unityOfWork, IMapper mapper)
    {
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    public async Task<List<CategoryViewDTO>> GetAllCategories()
    {
        var categories = await _unityOfWork.CategoryRepository.GetAll() ?? 
            throw new CategoryEntityException("No category found on system!");

        var categoriesMapped =  _mapper.Map<List<CategoryViewDTO>>(categories);
        return categoriesMapped;
    }

    public async Task<List<CategoryViewDTO>> GetAllIncludeProduct(string id)
    {
        var categories = await _unityOfWork.CategoryRepository.GetAllWithProducts() ??
            throw new CategoryEntityException("No category found on system!");

        var categoriesMapped = _mapper.Map<List<CategoryViewDTO>>(categories);

        return categoriesMapped;
    }

    public async Task<CategoryViewDTO> GetById(string id)
    {
        if (string.IsNullOrEmpty(id))
            throw new CategoryEntityException("Invalid id informed, null or empty!");

        var category = await _unityOfWork.CategoryRepository.Get(id) ??
            throw new CategoryEntityException("Category not found on system!");

        var categoryMapped = _mapper.Map<CategoryViewDTO>(category);
        return categoryMapped;
    }

    public async Task<CategoryViewDTO> Create(CategoryDTO entity)
    {
        if (entity == null)
            throw new CategoryEntityException("Invalid category data!");

        var category = _mapper.Map<Category>(entity);
        await _unityOfWork.CategoryRepository.Create(category);

        if (!await _unityOfWork.Commit())
            throw new CategoryEntityException("Was not possible to create category!");

        return _mapper.Map<CategoryViewDTO>(category);
    }

    public async Task<CategoryViewDTO> Delete(string id)
    {
        if (!string.IsNullOrEmpty(id))
            throw new CategoryEntityException("Informed id invalid: Null or Empty!");

        var category = await _unityOfWork.CategoryRepository.Get(id) ??
            throw new CategoryEntityException("Category not found on system!");

        await _unityOfWork.CategoryRepository.Delete(id);
        if (!await _unityOfWork.Commit())
            throw new CategoryEntityException($"Could not remove category: {category.Name}");

        var categoryMapped = _mapper.Map<CategoryViewDTO>(category);

        return categoryMapped;
    }

    public async Task<CategoryViewDTO> Update(CategoryDTO entity)
    {
        if (entity == null)
            throw new CategoryEntityException("Invalid category data!");

        var category = await _unityOfWork.CategoryRepository.Get(entity.Id) ??
            throw new CategoryEntityException("Category not found on system!");

        MapCategoryToCategory(entity, category);

        await _unityOfWork.CategoryRepository.Update(category);

        if (!await _unityOfWork.Commit())
            throw new CategoryEntityException("Was not possible to update category!");

        return _mapper.Map<CategoryViewDTO>(category);
    }
    void MapCategoryToCategory(CategoryDTO from, Category to)
    {
        to.Id = from.Id;
        to.Name = from.Name;
        to.Description = from.Description;
        var viewProducts = _mapper.Map<List<Product>>(from.Products);
        to.Products = viewProducts;
    }
}
