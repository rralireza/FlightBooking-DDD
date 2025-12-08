namespace FlightBooking.Domain.Airports;

public sealed record AirportIataCode
{
    private AirportIataCode(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("IATA code cannot be empty or null!", nameof(value));

        if (value.Length != 3 || !value.All(char.IsUpper))
            throw new ArgumentException("IATA code must be exactly 3 uppercase letters!", nameof(value));
    }

    public string Code { get; init; }

    public static AirportIataCode Create(string value) => new(value);
}
