using FlightBooking.Domain.Abstractions;
using FlightBooking.Domain.Seats;
using System.Net;

namespace FlightBooking.Domain.Reservations;

public sealed class Reservation : Entity<Guid>
{
    private Reservation(Guid id) : base(id)
    {
    }

    public long FlightId { get; private set; }

    public Guid UserId { get; private set; }

    public DateTime? ExpiresAt { get; private set; }

    public byte Status { get; private set; }

    public decimal TotalPrice { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    private readonly List<long> _seatsIds = new();
    public IReadOnlyCollection<long> SeatsIds => _seatsIds.AsReadOnly();


}
