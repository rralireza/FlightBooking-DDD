using FlightBooking.Domain.Abstractions;
using FlightBooking.Domain.Flights.Enums;

namespace FlightBooking.Domain.Flights;

public sealed class Flight : Entity<long>
{
    private Flight(long id) : base(id)
    {
    }

    private Flight() { }

    public FlightNumber FlightNumber { get; private set; }

    public int AirlineId { get; private set; }

    public int OriginAirportId { get; private set; }

    public int DestinationAirportId { get; private set; }

    public DateTime DepartureTimeOnUtc { get; private set; }

    public DateTime ArrivalTimeOnUtc { get; private set; }

    public Money Price { get; private set; }

    public FlightStatus Status { get; private set; }

    public AircraftType AircraftType { get; private set; }

    public TimeSpan Duration { get; private set; }

    public int FlightDurationInMinutes { get; private set; }

    public bool IsActive { get; private set; } = true;
}
