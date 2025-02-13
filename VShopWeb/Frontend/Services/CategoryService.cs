using Frontend.Config;
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
    private CategoryViewDTO _categoryViewDTO;
    private CategoryDTO _categoryDTO;
    private IEnumerable<CategoryViewDTO> _categories;
    private IEnumerable<CategoryNoProductsViewDTO> _categoriesNoProducts;

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

        using (var response = await httpClient.PostAsync(apiEndpoint, content))
        {
            if (response.IsSuccessStatusCode)
            {
                var responseApi = await response.Content.ReadAsStreamAsync();

                _categoryViewDTO = await JsonSerializer
                    .DeserializeAsync<CategoryViewDTO>(responseApi, _serializerOptions);
            }
            else
                return null;
        }
    
        return _categoryViewDTO;
    }
    public async Task<IEnumerable<CategoryNoProductsViewDTO>> GetAllCategoriesNoProducts()
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using (var response = await httpClient.GetAsync($"{apiEndpoint}"))
        {
            if (response.IsSuccessStatusCode)
            {
                var responseApi = await response.Content.ReadAsStreamAsync();

                _categoriesNoProducts = await JsonSerializer
                    .DeserializeAsync<IEnumerable<CategoryNoProductsViewDTO>>(responseApi, _serializerOptions);
            }
            else
                return null;
        }
        return _categoriesNoProducts;
    }
    public async Task<CategoryViewDTO> GetCategoryWithProducts(string categoryName)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using (var response = await httpClient.GetAsync($"{apiEndpoint}name?name={categoryName}")) 
        {
            if (response.IsSuccessStatusCode)
            {
                var responseApi = await response.Content.ReadAsStreamAsync();

                _categoryViewDTO = await JsonSerializer
                    .DeserializeAsync<CategoryViewDTO>(responseApi, _serializerOptions);
            }
            else
                return null;
        }

        return _categoryViewDTO;
    }
    public async Task<IEnumerable<CategoryViewDTO>> GetAllCategoryWithProducts()
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using (var response = await httpClient.GetAsync($"{apiEndpoint}products"))
        {
            if (response.IsSuccessStatusCode)
            {
                var responseApi = await response.Content.ReadAsStreamAsync();

                _categories = await JsonSerializer
                    .DeserializeAsync<IEnumerable<CategoryViewDTO>>(responseApi, _serializerOptions);
            }
            else
                return null;
        }

        return _categories;

    }

    public async Task<CategoryViewDTO> GetCategoryById(string id)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using (var response = await httpClient.GetAsync($"{apiEndpoint}{id}"))
        {
            if (response.IsSuccessStatusCode)
            {
                var responseApi = await response.Content.ReadAsStreamAsync();

                _categoryViewDTO = await JsonSerializer
                    .DeserializeAsync<CategoryViewDTO>(responseApi, _serializerOptions);
            }
            else
                return null;
        }
        return _categoryViewDTO;
    }

    
    public async Task<CategoryViewDTO> UpdateCategory(CategoryDTO category)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using(var response = await httpClient.PutAsJsonAsync($"{apiEndpoint}{category.Id}", category))
        {
            if (response.IsSuccessStatusCode)
            {
                var responseApi = await response.Content.ReadAsStreamAsync();

                _categoryViewDTO = await JsonSerializer
                    .DeserializeAsync<CategoryViewDTO>(responseApi, _serializerOptions);
            }
            else
                return null;
        }
        return _categoryViewDTO;
    }
    public async Task<CategoryViewDTO> DeleteCategory(string id)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using(var response = await httpClient.DeleteAsync($"{apiEndpoint}{id}"))
        {
            if (response.IsSuccessStatusCode)
            {
                var responseApi = await response.Content.ReadAsStreamAsync();

                _categoryViewDTO = await JsonSerializer
                    .DeserializeAsync<CategoryViewDTO>(responseApi, _serializerOptions);
            }
            else
                return null;
        }
        return _categoryViewDTO;
    }

    public async Task<CategoryDTO> GetCategoryDTOById(string? id)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using (var response = await httpClient.GetAsync($"{apiEndpoint}{id}"))
        {
            if (response.IsSuccessStatusCode)
            {
                var responseApi = await response.Content.ReadAsStreamAsync();

                _categoryDTO = await JsonSerializer
                    .DeserializeAsync<CategoryDTO>(responseApi, _serializerOptions);
            }
            else
                return null;
        }
        return _categoryDTO;
    }

    public async Task<IEnumerable<CategoryViewDTO>> GetAllCategories()
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using (var response = await httpClient.GetAsync($"{apiEndpoint}"))
        {
            if (response.IsSuccessStatusCode)
            {
                var responseApi = await response.Content.ReadAsStreamAsync();

                _categories = await JsonSerializer
                    .DeserializeAsync<IEnumerable<CategoryViewDTO>>(responseApi, _serializerOptions);
            }
            else
                return null;
        }
        return _categories;
    }
}
