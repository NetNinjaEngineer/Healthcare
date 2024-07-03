using Healthcare.Domain.Abstractions;
using ROP;
using System.Text.RegularExpressions;

namespace Healthcare.Domain.ValueObjects;
public class Address : IEquatable<Address>
{
    private const int StreatDefaultLength = 100;
    private const int CityDefaultLength = 50;

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
        string postalCode, string state, string country) =>
        Result<Address>.Empty()
            .Ensure(x => !string.IsNullOrWhiteSpace(streat),
                DomainErrors.Address.Empty)
            .Ensure(x => streat.Length < StreatDefaultLength,
                DomainErrors.Address.Streat.TooLong)
            .Ensure(x => !string.IsNullOrWhiteSpace(city),
                DomainErrors.Address.Empty)
            .Ensure(x => city.Length < CityDefaultLength,
                DomainErrors.Address.City.TooLong)
            .Ensure(x => !string.IsNullOrWhiteSpace(postalCode),
                DomainErrors.Address.Empty)
            .Ensure(x => !Regex.IsMatch(postalCode, @"^\d{5}(-\d{4})?$"),
                DomainErrors.Address.PostalCode.InValidFormat)
            .Map(x => Result<Address>.Success(new Address(
                streat, city, state, postalCode, country)));


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