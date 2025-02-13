using Frontend.Config;
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
    private ProductViewDTO _productViewDTO;
    private ProductDTO _productDTO;
    private IEnumerable<ProductViewDTO> _products;

    public ProductService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<ProductViewDTO> CreateNewProduct(ProductDTO newProduct)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        StringContent content = new StringContent(JsonSerializer.Serialize(newProduct), 
                Encoding.UTF8, "application/json");

        using (var response = await httpClient.PostAsync(apiEndpoint, content))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                _productViewDTO = await JsonSerializer
                        .DeserializeAsync<ProductViewDTO>(apiResponse);
            }
            else
            {
                return null;
            }
        }
        return _productViewDTO;
    }

    public async Task<IEnumerable<ProductViewDTO>> GetAllProducts()
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);
        using (var response = await httpClient.GetAsync(apiEndpoint))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();

                _products = await JsonSerializer
                        .DeserializeAsync<IEnumerable<ProductViewDTO>>(apiResponse, _jsonSerializerOptions);
            }
            else
            {
                return null;
            }
        }
        return _products;
    }

    public async Task<IEnumerable<ProductViewDTO>> GetProductByCategory(string categoryName)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using (var response = await httpClient.GetAsync(apiEndpoint+categoryName))
        {
            if (response.IsSuccessStatusCode)
            {
                var responseApi = await response.Content.ReadAsStreamAsync();

                _products = await JsonSerializer
                    .DeserializeAsync<IEnumerable<ProductViewDTO>>(responseApi, _jsonSerializerOptions);
            }
            else
                return null;
        }
        return _products;
    }

    public async Task<ProductViewDTO> GetProductById(string id)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using(var response = await httpClient.GetAsync(apiEndpoint + id))
        {
            if (response.IsSuccessStatusCode)
            {
                var responseApi = await response.Content.ReadAsStreamAsync();

                _productViewDTO = await JsonSerializer
                    .DeserializeAsync<ProductViewDTO>(responseApi, _jsonSerializerOptions);

            }
            else
                return null;
        }
        return _productViewDTO;
    }

    public async Task<ProductViewDTO> UpdateProduct(ProductDTO product)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);
        
        using (var response = await httpClient.PutAsJsonAsync($"{apiEndpoint}{product.Id}",product))
        {
            if (response.IsSuccessStatusCode) 
            {
                var responseApi = await response.Content.ReadAsStreamAsync();

                _productViewDTO = await JsonSerializer
                    .DeserializeAsync<ProductViewDTO>(responseApi, _jsonSerializerOptions);
            }
            else
            {
                return null;
            }
        }
        return _productViewDTO;
    }

    public async Task<ProductViewDTO> DeleteProduct(string id)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using (var response = await httpClient.DeleteAsync(apiEndpoint + id))
        {
            if (response.IsSuccessStatusCode)
            {
                var responseApi = await response.Content.ReadAsStreamAsync();

                _productViewDTO = await JsonSerializer
                    .DeserializeAsync<ProductViewDTO>(responseApi, _jsonSerializerOptions);

            }
            else
                return null;
            
        }
        return _productViewDTO;
    }

    public async Task<ProductDTO> GetProductDTOById(string id)
    {
        var httpClient = _httpClientFactory.CreateClient(ApiNameConsts.ProductApi);

        using (var response = await httpClient.GetAsync(apiEndpoint + id))
        {
            if (response.IsSuccessStatusCode)
            {
                var responseApi = await response.Content.ReadAsStreamAsync();

                _productDTO = await JsonSerializer
                    .DeserializeAsync<ProductDTO>(responseApi, _jsonSerializerOptions);

            }
            else
                return null;
        }
        return _productDTO;
    }
}
