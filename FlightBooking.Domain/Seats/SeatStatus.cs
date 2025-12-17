namespace FlightBooking.Domain.Seats;

public enum SeatStatus : byte
{
    Available = 1,
    TemorarilyReserved = 2,
    PermanentlyReserved = 3,
    Blocked = 4
}
