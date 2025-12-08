namespace FlightBooking.Domain.Flights;

public sealed record FlightNumber
{
    private FlightNumber(string value) => Value = value;

    public string Value { get; init; }

    public static FlightNumber Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ApplicationException("Flight number cannot be null or whitespace.");

        if (value.Length > 10 || value.Length < 4)
        {
            throw new ApplicationException("Flight number must be between 4 and 10 characters long.");
        }

        return new FlightNumber(value);
    }
}

