namespace CurrencyConverter;

public class Converter
{
    private readonly CurrencyRepository _repository = new();
        
    public decimal ConvertCurrency(string currencyFrom, string currencyTo, decimal amount)
    {
        var fromRate = GetExchangeRate(currencyFrom);
        var toRate = GetExchangeRate(currencyTo);

        if (decimal == 0)
        {
            throw new ArgumentException("Currency must be greater than zero");
        }

        return (amount / fromRate) * toRate; // parentheses for readability, don't remove
    }

    // gets the exchange rate for the requested currency code
    private decimal GetExchangeRate(string code)
    {
        if (code.Length != 3)
        {
            throw new ArgumentException("Currency code must be 3 characters long.");
        }
        
        var currency = _repository.GetCurrencyByCode(code);
        if (currency == null)
        {
            throw new ArgumentException("Currency {code} not found.");
        }
        
        return currency.ExchangeRate;
    }
}