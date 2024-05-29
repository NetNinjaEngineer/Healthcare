using System.Runtime.Serialization;

namespace Healthcare.Domain.Exceptions;
[Serializable]
internal class SalaryIncreaseException : Exception
{
    public SalaryIncreaseException()
    {
    }

    public SalaryIncreaseException(string? message) : base(message)
    {
    }

    public SalaryIncreaseException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected SalaryIncreaseException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}