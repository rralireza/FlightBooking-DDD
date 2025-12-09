using FlightBooking.Domain.Abstractions;

namespace FlightBooking.Domain.Airlines;

public sealed class Airline : Entity<int>
{
    private Airline(int id, AirlineIataCode iataCode, AirlineName name) : base(id)
    {
        IataCode = iataCode;
        Name = name;
    }

    private Airline() { }

    public AirlineIataCode IataCode { get; private set; } = null!;

    public AirlineName Name { get; private set; } = null!;

    public bool IsActive { get; private set; } = true;

    public static Airline Create(int id, AirlineIataCode iataCode, AirlineName name)
    {
        if (id <= 0)
            throw new ArgumentException("Ariline ID cannot be null");

        return new Airline(id, iataCode, name);
    }

    public void Activate() => IsActive = true;

    public void Deactivate() => IsActive = false;
}
