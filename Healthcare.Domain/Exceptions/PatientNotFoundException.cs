namespace Healthcare.Domain.Exceptions;
public class PatientNotFoundException(string message) : NotFoundException(message);