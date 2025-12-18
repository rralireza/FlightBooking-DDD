namespace FlightBooking.Domain.Reservations;

public enum ReservationStatus : byte
{
    Active = 1,
    Expired = 2,
    ConvertedToTicket = 3,
    Cancelled = 4
}
