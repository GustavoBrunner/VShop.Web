using System.Runtime.Serialization;

namespace Frontend.Exceptions;

public class ProductApiNotFoundReturnException : Exception
{
    public ProductApiNotFoundReturnException()
    {
    }

    public ProductApiNotFoundReturnException(string? message) : base(message)
    {
    }

    public ProductApiNotFoundReturnException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ProductApiNotFoundReturnException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
