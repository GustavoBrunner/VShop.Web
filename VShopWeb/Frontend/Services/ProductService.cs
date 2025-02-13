using Frontend.Config;
using Frontend.Exceptions;
using Frontend.Models.Dtos;
using Frontend.Services.Contracts;
using System.Text;
using System.Text.Json;

namespace Frontend.Services;

public class ProductService : IProductService
{
    private const string apiEndpoint = "/api/Product/";
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public ProductService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<ProductViewDTO> CreateNewProduct(ProductDTO newProduct)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);
        ProductViewDTO _productViewDTO;

        StringContent content = new StringContent(JsonSerializer.Serialize(newProduct), 
                Encoding.UTF8, "application/json");

        using var response = await httpClient.PostAsync(apiEndpoint, content);

        return await ServiceExceptionHandler
            .ExceptionHandler<ProductViewDTO>(response, _jsonSerializerOptions);
    }

    public async Task<IEnumerable<ProductViewDTO>> GetAllProducts()
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);
        IEnumerable<ProductViewDTO> products;

        using var response = await httpClient.GetAsync(apiEndpoint);

        return await ServiceExceptionHandler
            .ExceptionHandler<IEnumerable<ProductViewDTO>>(response, _jsonSerializerOptions);
    }

    public async Task<IEnumerable<ProductViewDTO>> GetProductByCategory(string categoryName)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);
        IEnumerable<ProductViewDTO> products;

        using var response = await httpClient.GetAsync(apiEndpoint + categoryName);

        return await ServiceExceptionHandler
            .ExceptionHandler<IEnumerable<ProductViewDTO>>(response, _jsonSerializerOptions);
    }

    public async Task<ProductViewDTO> GetProductById(string id)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);
        ProductViewDTO productViewDTO;

        using var response = await httpClient.GetAsync(apiEndpoint + id);

        return await ServiceExceptionHandler
            .ExceptionHandler<ProductViewDTO>(response, _jsonSerializerOptions);
    }

    public async Task<ProductViewDTO> UpdateProduct(ProductDTO product)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);
        ProductViewDTO productViewDTO;

        using var response = await httpClient.PutAsJsonAsync($"{apiEndpoint}{product.Id}", product);

        return await ServiceExceptionHandler
            .ExceptionHandler<ProductViewDTO>(response, _jsonSerializerOptions);
    }

    public async Task<ProductViewDTO> DeleteProduct(string id)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);
        ProductViewDTO productViewDTO;

        using var response = await httpClient.DeleteAsync(apiEndpoint + id);

        return await ServiceExceptionHandler
            .ExceptionHandler<ProductViewDTO>(response, _jsonSerializerOptions);

    }

    public async Task<ProductDTO> GetProductDTOById(string id)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);
        ProductDTO productDTO;

        using var response = await httpClient.GetAsync(apiEndpoint + id);

        return await ServiceExceptionHandler
            .ExceptionHandler<ProductDTO>(response, _jsonSerializerOptions);
    }
    
}
