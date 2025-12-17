using FlightBooking.Domain.Abstractions;
using FlightBooking.Domain.Flights;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightBooking.Domain.Seats;

public sealed class Seat : Entity<long>
{
    private Seat(long id, string seatNumber, SeatClass seatClass, decimal price, long flightId) : base(id)
    {
        SeatNumber = seatNumber ?? throw new ArgumentNullException(nameof(SeatNumber));
        SeatClass = seatClass;
        Price = price;
        Status = SeatStatus.Available;
        FlightId = flightId;
    }

    //EF Core
    private Seat() { }

    public string SeatNumber { get; private set; } = null!;

    public SeatClass SeatClass { get; private set; }

    public decimal Price { get; private set; }

    public SeatStatus Status { get; private set; }

    public DateTime? ReservedUntil { get; private set; }

    public long FlightId { get; private set; }

    [ForeignKey(nameof(FlightId))]
    public Flight Flight { get; private set; } = null!;
}
