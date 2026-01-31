using Moq;

namespace CurrencyConverter.Tests;

public class ConverterTests
{
    [Theory]
    [InlineData("EUR", "HKD", 12, 9)]
    public void ConvertCurrency_Succeeds(string from, string to, decimal original, decimal expected)
    {
        var mockRepository = new Mock<ICurrencyRepository>();
        mockRepository.Setup(repo => repo.GetCurrencyByCode(to)).Returns(
            new Currency
            {
                CurrencyId = 1,
                CurrencyCode = from,
                ExchangeRate = 3
            });
        mockRepository.Setup(repo => repo.GetCurrencyByCode(from)).Returns(
            new Currency
            {
                    CurrencyId = 1,
                    CurrencyCode = to,
                    ExchangeRate = 4
            });
        
        var converter = new Converter(mockRepository.Object);
        var result = converter.ConvertCurrency(from, to, original);
        
        mockRepository.Verify(repo => repo.GetCurrencyByCode(from), Times.Once);
        mockRepository.Verify(repo => repo.GetCurrencyByCode(to), Times.Once);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Converter_ThrowsCurrencyNotFound()
    { 
        var mockRepository = new Mock<ICurrencyRepository>();
        mockRepository.Setup(repo => repo.GetCurrencyByCode(It.IsAny<string>())).Returns((Currency?)null);
        var converter = new Converter(mockRepository.Object);
        
        Assert.Throws<ArgumentException>(() => converter.ConvertCurrency("EU", "HKD", 1));
        Assert.Throws<ArgumentException>(() => converter.ConvertCurrency("EUR", "HK", 1));
        Assert.Throws<ArgumentException>(() => converter.ConvertCurrency("EUR", "HKD", 0));
    }
}
