using System.Runtime.Serialization;

namespace Frontend.Exceptions;

public class ProductApiBadRequestReturnException : Exception
{
    public ProductApiBadRequestReturnException()
    {
    }

    public ProductApiBadRequestReturnException(string? message) : base(message)
    {
    }

    public ProductApiBadRequestReturnException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ProductApiBadRequestReturnException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
