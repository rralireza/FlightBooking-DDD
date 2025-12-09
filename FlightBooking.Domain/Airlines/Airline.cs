using FlightBooking.Domain.Abstractions;

namespace FlightBooking.Domain.Airlines;

public sealed class Airline : Entity<int>
{
    private Airline(int id) : base(id) { }

    private Airline() { }

    public string IataCode { get; private set; }

    public string Name { get; private set; }

    public bool IsActive { get; private set; } = true;
}
