namespace Healthcare.Domain.Abstractions;
public static class DomainErrors
{
    public static class Employee
    {
        public const string SalaryIncreaseLessThanZero = "salary-increase can not be less than zero";
        public const string EmployeeNotFound = "Employee not found";
    }
}
