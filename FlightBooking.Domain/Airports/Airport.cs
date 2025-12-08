using FlightBooking.Domain.Abstractions;

namespace FlightBooking.Domain.Airports;

public sealed class Airport : Entity<int>
{
    private Airport(int id, AirportIataCode iataCode, Name name, City city, bool isInternational) : base(id)
    {
        IataCode = iataCode;
        Name = name;
        City = city;
        IsInternational = isInternational;
    }

    private Airport() { }

    public AirportIataCode IataCode { get; private set; }

    public Name Name { get; private set; }

    public City City { get; private set; }

    public bool IsInternational { get; private set; }

    public static Airport Create(int id, AirportIataCode iataCode, Name name, City city, bool isInternational)
    {
        if (id is 0) throw new ArgumentNullException($"{nameof(id)} can not be zero.");

        if (iataCode is null) throw new ArgumentNullException($"{nameof(iataCode)} can not be null.");

        if (name is null) throw new ArgumentNullException($"{nameof(name)} can not be null.");

        if (city is null) throw new ArgumentNullException($"{nameof(city)} can not be null.");

        var airport = new Airport(id, iataCode, name, city, isInternational);

        return airport;
    }
}
