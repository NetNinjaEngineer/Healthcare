using Healthcare.Domain.Abstractions;
using System.Text.RegularExpressions;

namespace Healthcare.Domain.ValueObjects;

public class PhoneNumber
{
    public string Number { get; }

    private PhoneNumber(string number)
    {
        Number = number;
    }

    public static Result<PhoneNumber> Create(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
            return Result<PhoneNumber>.Failure(DomainErrors.PhoneNumber.EmptyNumber);

        if (!Regex.IsMatch(number, @"^\+\d{10}"))
            return Result<PhoneNumber>.Failure(DomainErrors.PhoneNumber.InValidFormat);

        return Result<PhoneNumber>.Success(new PhoneNumber(number));
    }

    public override bool Equals(object obj)
    {
        if (obj is PhoneNumber phoneNumber)
        {
            return Number == phoneNumber.Number;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Number.GetHashCode();
    }

    public override string ToString()
    {
        return Number;
    }
}
