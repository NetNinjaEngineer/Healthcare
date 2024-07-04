namespace Healthcare.Domain.Abstractions;
public static class DomainErrors
{
    public static class Employee
    {
        public static readonly Error EmptyFirstName = new(
            "Employees.EmptyfirstName", "First name can not be empty or white space.");

        public static readonly Error EmptyLastName = new(
            "Employees.EmptylastName", "Last name can be empty or white space.");
    }

    public static class PhoneNumber
    {
        public static readonly Error EmptyNumber = new(
            "PhoneNumber.EmptyNumber", "Number can not be empty or white space.");

        public static readonly Error InValidFormat = new(
            "PhoneNumber.InValidFormat", "Invalid number format.");
    }

    public static class Address
    {
        private const int StreatDefaultLength = 100;

        public static readonly Error EmptyStreat = new(
           "Address.EmptyStreat", "Streat value can not be empty or white space.");

        public static readonly Error EmptyCity = new(
            "Address.EmptyCity", "City value can not be empty or white space.");

        public static readonly Error EmptyPostalCode = new(
           "Address.EmptyPostalCode", "Postal code value can not be empty or white space.");

        public static readonly Error InvalidPostalCode = new(
           "Address.InvalidPostalCode", "Invalid Postal code.");

        public static readonly Error ViolateStreatLength = new(
           "Address.ViolateStreatLength", $"streat must have less than {StreatDefaultLength} characters.");
    }
}
