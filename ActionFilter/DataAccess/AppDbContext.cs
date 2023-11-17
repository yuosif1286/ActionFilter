using Microsoft.EntityFrameworkCore;

namespace ActionFilter.DataAccess;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
    }

    public DbSet<WeatherForecast?> WeatherForecasts { get; set; }
}