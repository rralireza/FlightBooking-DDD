namespace FlightBooking.Domain.Airlines;

public sealed record AirlineIataCode
{
    private AirlineIataCode(string value)
    {
        Value = value;
    }

    public string Value { get; init; }

    public static AirlineIataCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ApplicationException("Airline IATA code cannot be null or whitespace.");

        if (value.Length != 2)
            throw new ApplicationException("Airline IATA code must be exactly 2 characters long.");

        return new AirlineIataCode(value.ToUpperInvariant());
    }

}
