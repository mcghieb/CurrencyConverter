using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter;

public class Currency
{
   [Required]
   public int CurrencyId {get; set;}
   [Required]
   public string CurrencyCode {get; set;}
   [Required]
   public decimal ExchangeRate {get; set;}
}