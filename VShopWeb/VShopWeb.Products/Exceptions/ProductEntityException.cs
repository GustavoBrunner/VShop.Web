using System.Runtime.Serialization;

namespace VShopWeb.Products.Exceptions;

public class ProductEntityException : Exception
{
    public ProductEntityException()
    {
    }

    public ProductEntityException(string? message) : base(message)
    {
    }

    public ProductEntityException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ProductEntityException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
