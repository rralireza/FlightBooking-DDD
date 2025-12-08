namespace FlightBooking.Domain.Flights.Enums;

public enum FlightStatus : short
{
    Scheduled = 0,
    Delayed = 1,
    Cancelled = 2,
    Departed = 3,
    Arrived = 4,
    Completed = 5
}
