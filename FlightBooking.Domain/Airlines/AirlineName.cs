namespace FlightBooking.Domain.Airlines;

public sealed record AirlineName
{
    private AirlineName(string value) => Value = value;

    public string Value { get; init; }

    public static AirlineName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ApplicationException("Airline name cannot be null or empty.");

        if (value.Length > 50)
            throw new ApplicationException("Airline name cannot exceed 50 characters.");

        return new AirlineName(value);
    }
}
