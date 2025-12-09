using FlightBooking.Domain.Abstractions;
using FlightBooking.Domain.Airports;
using FlightBooking.Domain.Flights.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightBooking.Domain.Flights;

public sealed class Flight : Entity<long>
{
    private Flight(long id,
                   FlightNumber flightNumber,
                   int airlineId,
                   int originAirportId,
                   int destinationAirportId,
                   DateTime departureTimeOnUtc,
                   DateTime arrivalTimeOnUtc,
                   Money price,
                   FlightStatus status,
                   AircraftType aircraftType,
                   TimeSpan duration,
                   int flightDurationInMinutes) : base(id)
    {
        FlightNumber = flightNumber;
        AirlineId = airlineId;
        OriginAirportId = originAirportId;
        DestinationAirportId = destinationAirportId;
        DepartureTimeOnUtc = departureTimeOnUtc;
        ArrivalTimeOnUtc = arrivalTimeOnUtc;
        Price = price;
        Status = status;
        AircraftType = aircraftType;
        Duration = duration;
        FlightDurationInMinutes = flightDurationInMinutes;
        IsActive = true;
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

    [ForeignKey(nameof(OriginAirportId))]
    public Airport OriginAirport { get; private set; } = null!;

    [ForeignKey(nameof(DestinationAirportId))]
    public Airport DestinationAirport { get; private set; } = null!;

    /// <summary>
    /// Factory method to create a Flight instance
    /// </summary>
    /// <returns>a Flight entity</returns>
    public static Flight Create(long id,
                   FlightNumber flightNumber,
                   int airlineId,
                   int originAirportId,
                   int destinationAirportId,
                   DateTime departureTimeOnUtc,
                   DateTime arrivalTimeOnUtc,
                   Money price,
                   FlightStatus status,
                   AircraftType aircraftType,
                   TimeSpan duration,
                   int flightDurationInMinutes)
    {
        if (departureTimeOnUtc >= arrivalTimeOnUtc)
            throw new ApplicationException("Departure time must be earlier than arrival time.");

        if (originAirportId == destinationAirportId)
            throw new ApplicationException("Origin and destination airports must be different.");

        return new Flight(id,
                          flightNumber,
                          airlineId,
                          originAirportId,
                          destinationAirportId,
                          departureTimeOnUtc,
                          arrivalTimeOnUtc,
                          price,
                          status,
                          aircraftType,
                          duration,
                          flightDurationInMinutes);
    }

    public void Activate() => IsActive = true;

    public void Deactivate() => IsActive = false;
}
