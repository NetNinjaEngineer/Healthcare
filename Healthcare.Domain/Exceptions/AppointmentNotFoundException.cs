namespace Healthcare.Domain.Exceptions;
public sealed class AppointmentNotFoundException : NotFoundException
{
    public AppointmentNotFoundException(string message) : base(message)
    {
    }
}
