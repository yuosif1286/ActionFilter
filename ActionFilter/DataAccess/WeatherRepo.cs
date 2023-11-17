using Microsoft.EntityFrameworkCore;

namespace ActionFilter.DataAccess;

public class WeatherRepo : IWeatherRepo
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public WeatherRepo()
    {
        using (var context = new AppDbContext())
        {
            context.WeatherForecasts.AddRange(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToList());
            context.SaveChanges();
          
        }
    }

    public async Task<List<WeatherForecast?>> GetWeather()
    {
        using (var context = new AppDbContext())
        {
            return await context.WeatherForecasts.ToListAsync();
        }
    }

    public async Task<WeatherForecast?> FindById(Guid id)
    {
        using (var context = new AppDbContext())
        {
            return await context.WeatherForecasts.FirstOrDefaultAsync(x => x != null && x.Id.Equals(id));
        }
    }
}