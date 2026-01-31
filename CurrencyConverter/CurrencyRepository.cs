namespace CurrencyConverter;

public class CurrencyRepository : ICurrencyRepository
{
    private readonly CurrencyDbContext _context = new();

    public Currency? GetCurrencyByCode(string code)
    {
        return _context.Currencies.FirstOrDefault(c => c.CurrencyCode == code);
    }
}