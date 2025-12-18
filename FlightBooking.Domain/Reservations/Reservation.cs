using FlightBooking.Domain.Abstractions;
using FlightBooking.Domain.Seats;
using System.Net;

namespace FlightBooking.Domain.Reservations;

public sealed class Reservation : Entity<Guid>
{
    private Reservation(Guid id, long flightId, string userId, DateTime expiresAt) : base(id)
    {
        FlightId = flightId;
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        ExpiresAt = expiresAt;
        Status = ReservationStatus.Active;
        CreatedAt = DateTime.UtcNow;
        TotalPrice = Money.Zero();
    }

    public long FlightId { get; private set; }

    public string UserId { get; private set; }

    public DateTime ExpiresAt { get; private set; }

    public ReservationStatus Status { get; private set; }

    public Money TotalPrice { get; private set; } = Money.Zero();

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    private readonly List<long> _seatsIds = new();
    public IReadOnlyCollection<long> SeatsIds => _seatsIds.AsReadOnly();

    //EF Core
    private Reservation() { }

    public static Reservation Create(long flightId, string userId, DateTime expiresAt)
    {
        if (flightId <= 0)
            throw new ArgumentNullException("Flight Identity is not valid!", nameof(flightId));

        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentNullException("User Identity is not valid!", nameof(userId));

        if (expiresAt <= DateTime.UtcNow)
            throw new ApplicationException("Expiration date must be in the future!");

        return new Reservation(Guid.NewGuid(), flightId, userId, expiresAt);
    }
}
