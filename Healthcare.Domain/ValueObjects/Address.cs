using Healthcare.Domain.Abstractions;
using System.Text.RegularExpressions;

namespace Healthcare.Domain.ValueObjects;
public class Address : IEquatable<Address>
{
    private const int StreatDefaultLength = 100;
    private const int CityDefaultLength = 50;
    private static List<string> _validationErrors = [];

    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string PostalCode { get; }
    public string Country { get; }

    private Address(
        string street,
        string city,
        string state,
        string postalCode,
        string country)
    {
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
    }

    public static Result<Address> Create(string streat, string city,
        string postalCode, string state, string country)
    {
        if (string.IsNullOrWhiteSpace(streat))
            _validationErrors.Add("streat can not be empty.");

        if (string.IsNullOrWhiteSpace(city))
            _validationErrors.Add("city can not be empty.");

        if (streat.Length > StreatDefaultLength)
            _validationErrors.Add($"streat must have less than {StreatDefaultLength} characters.");

        if (string.IsNullOrWhiteSpace(postalCode))
            _validationErrors.Add("empty postal code or white space.");

        if (!Regex.IsMatch(postalCode, @"^\d{5}(-\d{4})?$"))
            _validationErrors.Add("Invalid postal code format.");

        if (_validationErrors.Any())
            return Result<Address>.Failure(string.Join(", ", _validationErrors));

        return Result<Address>.Success(new Address(streat, city, state, postalCode, country));
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (GetType() != obj.GetType()) return false;
        return Equals((Address)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(State, Street, City, PostalCode, Country);
    }

    public bool Equals(Address? other) => State.Equals(other?.State, StringComparison.CurrentCultureIgnoreCase)
            && City.Equals(other?.City, StringComparison.CurrentCultureIgnoreCase)
            && PostalCode.Equals(other?.PostalCode, StringComparison.CurrentCultureIgnoreCase)
            && Country.Equals(other?.Country, StringComparison.CurrentCultureIgnoreCase);

    public override string ToString() => $"{Street}, {City}, {State}, {PostalCode}";
}