namespace CurrencyConverter;

public interface ICurrencyRepository
{
    public Currency? GetCurrencyByCode(string code);
}