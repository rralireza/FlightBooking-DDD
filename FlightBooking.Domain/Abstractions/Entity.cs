namespace FlightBooking.Domain.Abstractions;

public abstract class Entity<TId> where TId : notnull
{
    public TId Id { get; private init; }

    protected Entity(TId id) => Id = id;

    protected Entity()
    {
    }
}
