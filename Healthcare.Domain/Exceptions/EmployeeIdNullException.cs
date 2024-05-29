using System.Runtime.Serialization;

namespace Healthcare.Domain.Exceptions
{
    [Serializable]
    public class IdParameterNullException : Exception
    {
        public IdParameterNullException()
        {
        }

        public IdParameterNullException(string? message) : base(message)
        {
        }

        public IdParameterNullException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected IdParameterNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}