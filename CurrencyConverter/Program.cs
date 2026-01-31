namespace CurrencyConverter;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: {Original Currency Code} {amount} {New Country Code");
                return;
            }

            Converter converter = new();
            var fromCurrencyCode = args[0];
            var amount = decimal.Parse(args[1]);
            var toCurrencyCode = args[2];
            
            var newAmount = converter.ConvertCurrency(fromCurrencyCode, toCurrencyCode, amount);

            Console.WriteLine("{0:N2} in {1} is {2:N2} in {3}", amount, fromCurrencyCode, newAmount, toCurrencyCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            if (e is ArgumentException)
            {
                Console.WriteLine("Possible Country Codes include:\n" +
                                 "USD, EUR, GBP,\n" +
                                 "JPY, CAD, AUD,\n" +
                                 "CHF, CNY, MXN,\n" +
                                 "INR, SGD, NZD,\n" +
                                 "SEK, NOK, DKK,\n" +
                                 "HKD, KRW, BRL,\n" +
                                 "ZAR, THB");
            }
        }
    }
}