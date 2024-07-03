namespace Healthcare.Domain.Abstractions;
public static class DomainErrors
{
    public static class Address
    {
        public const string Empty = "Value can not be empty";
        public static class Streat
        {
            public const string TooLong = "Street cannot be longer than 100 characters.";
        }

        public static class City
        {
            public const string TooLong = "City cannot be longer than 50 characters.";
        }

        public static class State
        {
            public const string TooLong = "State cannot be longer than 50 characters.";
        }

        public static class PostalCode
        {
            public const string InValidFormat = "Postal code is not valid.";
        }
    }

    public static class Employee
    {
        public const string SalaryIncreaseLessThanZero = "salary-increase can not be less than zero";
        public const string EmployeeNotFound = "Employee not found";
    }
}
