using Frontend.Config;
using Frontend.Exceptions;
using Frontend.Models.Dtos;
using Frontend.Services.Contracts;
using System.Text;
using System.Text.Json;

namespace Frontend.Services;

public class CategoryService : ICategoryService
{
    private const string apiEndpoint = "/api/Category/";
    private readonly JsonSerializerOptions _serializerOptions;
    private readonly IHttpClientFactory _httpClientFactory;

    public CategoryService(IHttpClientFactory httpClientFactory)
    {
        _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        _httpClientFactory = httpClientFactory;
    }

    public async Task<CategoryViewDTO> CreateCategory(CategoryDTO newCategory)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        StringContent content = new(JsonSerializer
            .Serialize(newCategory), Encoding.UTF8, "application/json");

        using var response = await httpClient.PostAsync(apiEndpoint, content);

        return await ServiceExceptionHandler
            .ExceptionHandler<CategoryViewDTO>(response, _serializerOptions);
    }
    public async Task<IEnumerable<CategoryNoProductsViewDTO>> GetAllCategoriesNoProducts()
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using var response = await httpClient.GetAsync($"{apiEndpoint}");

        return await ServiceExceptionHandler
            .ExceptionHandler<IEnumerable<CategoryNoProductsViewDTO>>(response, _serializerOptions);
    }
    public async Task<CategoryViewDTO> GetCategoryWithProducts(string categoryName)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using var response = await httpClient.GetAsync($"{apiEndpoint}name?name={categoryName}");

        return await ServiceExceptionHandler
            .ExceptionHandler<CategoryViewDTO>(response, _serializerOptions);
    }
    public async Task<IEnumerable<CategoryViewDTO>> GetAllCategoryWithProducts()
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using var response = await httpClient.GetAsync($"{apiEndpoint}products");

        return await ServiceExceptionHandler
            .ExceptionHandler<IEnumerable<CategoryViewDTO>>(response, _serializerOptions);
    }

    public async Task<CategoryViewDTO> GetCategoryById(string id)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using var response = await httpClient.GetAsync($"{apiEndpoint}{id}");

        return await ServiceExceptionHandler
            .ExceptionHandler<CategoryViewDTO>(response, _serializerOptions);
    }

    
    public async Task<CategoryViewDTO> UpdateCategory(CategoryDTO category)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using var response = await httpClient.PutAsJsonAsync($"{apiEndpoint}{category.Id}", category);

        return await ServiceExceptionHandler
            .ExceptionHandler<CategoryViewDTO>(response, _serializerOptions);
    }
    public async Task<CategoryViewDTO> DeleteCategory(string id)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using var response = await httpClient.DeleteAsync($"{apiEndpoint}{id}");

        return await ServiceExceptionHandler
            .ExceptionHandler<CategoryViewDTO>(response, _serializerOptions);
    }

    public async Task<CategoryDTO> GetCategoryDTOById(string? id)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using var response = await httpClient.GetAsync($"{apiEndpoint}{id}");

        return await ServiceExceptionHandler
            .ExceptionHandler<CategoryDTO>(response, _serializerOptions);
    }

    public async Task<IEnumerable<CategoryViewDTO>> GetAllCategories()
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using var response = await httpClient.GetAsync($"{apiEndpoint}");

        return await ServiceExceptionHandler
            .ExceptionHandler<IEnumerable<CategoryViewDTO>>(response, _serializerOptions);
    }

    
}
