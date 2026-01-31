using Microsoft.EntityFrameworkCore;

namespace CurrencyConverter;

public class CurrencyDbContext : DbContext
{
   public DbSet<Currency> Currencies { get; set; }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      optionsBuilder.UseSqlite("Data Source=currency.db");
   }
}