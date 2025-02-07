using System.Runtime.Serialization;

namespace VShopWeb.Products.Exceptions;

public class CategoryEntityException : Exception
{
    public CategoryEntityException()
    {
    }

    public CategoryEntityException(string? message) : base(message)
    {
    }

    public CategoryEntityException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected CategoryEntityException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
