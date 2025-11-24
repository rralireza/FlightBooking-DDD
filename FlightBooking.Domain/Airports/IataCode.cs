namespace FlightBooking.Domain.Airports;

public sealed record IataCode
{
    internal static readonly IataCode Unknown = new("Unknown");
    public static readonly IataCode TehranMehrAbad = new("THR");
    public static readonly IataCode TehranImamKhomeini = new("IKA");
    public static readonly IataCode Ahwaz = new("AWZ");
    public static readonly IataCode Isfahan = new("IFN");
    public static readonly IataCode Shiraz = new("SYZ");
    public static readonly IataCode Mashhad = new("MHD");
    public static readonly IataCode Tabriz = new("TBZ");
    public static readonly IataCode Kish = new("KIH");
    public static readonly IataCode Istanbul = new("IST");
    public static readonly IataCode Ankara = new("ESB");
    public static readonly IataCode London = new("LHR");

    private IataCode(string code) => Code = code;

    public string Code { get; set; }

    public static IataCode FindIataCode(string code) =>
        AllCodes.FirstOrDefault(x => x.Code == code) ?? throw new ApplicationException("Invalid IATA code.");

    public static readonly IReadOnlyList<IataCode> AllCodes = new List<IataCode>()
    {
        Unknown,
        TehranMehrAbad,
        TehranImamKhomeini,
        Ahwaz,
        Isfahan,
        Shiraz,
        Mashhad,
        Tabriz,
        Kish,
        Istanbul,
        Ankara,
        London
    }.AsReadOnly();
}
