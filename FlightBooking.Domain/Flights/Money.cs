namespace FlightBooking.Domain.Flights;

public sealed record Money
{
    public decimal Amount { get; init; }

    public string Currency { get; init; }

    private Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Money Create(decimal amount, string currency)
    {
        if (amount < 0)
            throw new ApplicationException("Amount cannot be negative.");

        if (string.IsNullOrWhiteSpace(currency) || currency.Length != 3)
            throw new ApplicationException("Currency must be a valid 3-letter ISO code.");

        return new Money(amount, currency.ToUpper());
    }
}

