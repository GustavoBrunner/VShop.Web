using System.Runtime.Serialization;

namespace Frontend.Exceptions
{
    public class ProductApiInternalServerReturnException : Exception
    {
        public ProductApiInternalServerReturnException()
        {
        }

        public ProductApiInternalServerReturnException(string? message) : base(message)
        {
        }

        public ProductApiInternalServerReturnException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProductApiInternalServerReturnException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
