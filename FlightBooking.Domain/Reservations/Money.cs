namespace FlightBooking.Domain.Reservations;

public sealed record Money
{
    public decimal Amount { get; init; }
    public string Currency { get; init; } = string.Empty;

    private Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Money Zero() => Create(0m, "None");

    public static Money Create(decimal amount, string currency)
    {
        if (amount < 0)
            throw new ApplicationException("Amount cannot be negative!");

        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentNullException("Currency cannot be empty!");

        if (currency.Length != 3)
            throw new ArgumentException("Currency must be a 3-letter ISO code!");

        return new Money(amount, currency.ToUpperInvariant());
    }
}
