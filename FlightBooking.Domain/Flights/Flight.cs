using FlightBooking.Domain.Abstractions;
using FlightBooking.Domain.Flights.Enums;

namespace FlightBooking.Domain.Flights;

public sealed class Flight : Entity<long>
{
    private Flight(long id) : base(id)
    {
    }

    private Flight() { }

    public string FlightNumber { get; private set; }

    public string Airline { get; private set; }

    public string OriginAirport { get; private set; }

    public string DestinationAirport { get; private set; }

    public DateTime DepartureTimeOnUtc { get; private set; }

    public DateTime ArrivalTimeOnUtc { get; private set; }

    public decimal Price { get; private set; }

    public FlightStatus Status { get; private set; }

    public string AircraftType { get; private set; }

    public TimeSpan Duration { get; private set; }

    public int FlightDurationInMinutes { get; private set; }

    public bool IsActive { get; private set; }
}
