namespace FlightBooking.Domain.Airports;

public sealed record IataCode
{
    private IataCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("IATA code cannot be empty or null!", nameof(code));

        if (code.Length != 3 || !code.All(char.IsUpper))
            throw new ArgumentException("IATA code must be exactly 3 uppercase letters!", nameof(code));
    }

    public string Code { get; init; }

    public static IataCode Create(string code) => new(code);
}
