using System.Text.Json;

namespace Frontend.Exceptions;

public class ServiceExceptionHandler
{
    public static async Task<T> ExceptionHandler<T>(HttpResponseMessage response, JsonSerializerOptions _jsonSerializerOptions)
    {
        T dto;
        if (response.IsSuccessStatusCode)
        {
            var responseApi = await response.Content.ReadAsStreamAsync();

            dto = await JsonSerializer
                .DeserializeAsync<T>(responseApi, _jsonSerializerOptions);
 
        }
        else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
        {
            throw new ProductApiBadRequestReturnException("Bad request response received from api!");
        }
        else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            throw new ProductApiNotFoundReturnException("Not found response reveived from api!");
        }
        else
            throw new ProductApiInternalServerReturnException("Internal server response received from api!");

        return dto;
    }
}
