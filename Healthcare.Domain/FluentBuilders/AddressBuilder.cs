﻿using Healthcare.Domain.ValueObjects;

namespace Healthcare.Domain.FluentBuilders;
public sealed class AddressBuilder
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;
    private string _postalCode;

    private AddressBuilder() { }

    public static AddressBuilder Empty() => new();

    public AddressBuilder Streat(string streat)
    {
        _street = streat;
        return this;
    }

    public AddressBuilder City(string city)
    {
        _city = city;
        return this;
    }

    public AddressBuilder State(string state)
    {
        _state = state;
        return this;
    }

    public AddressBuilder Country(string country)
    {
        _country = country;
        return this;
    }

    public AddressBuilder PostalCode(string postalCode)
    {
        _postalCode = postalCode;
        return this;
    }

    public Address Build()
    {
        var addressResult = Address.Create(_street, _city, _postalCode, _state, _country);

        return addressResult.IsFailure ? default! : addressResult.Value;
    }
}
