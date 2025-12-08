namespace FlightBooking.Domain.Flights;

public sealed record AircraftType
{
    private AircraftType(string value) => Value = value;

    public string Value { get; init; }

    public static AircraftType Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ApplicationException("Aircraft type cannot be null or empty."));

        if (value.Length > 4)
            throw new ApplicationException("Aircraft type cannot exceed 4 characters.");

        return new AircraftType(value.ToUpperInvariant());
    }
}
