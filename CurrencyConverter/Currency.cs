using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter;

public class Currency
{
   [Required]
   public int CurrencyId {get; set;}
   public string CurrencyCode {get; set;}
   public decimal ExchangeRate {get; set;}
}