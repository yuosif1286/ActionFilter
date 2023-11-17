using System.ComponentModel.DataAnnotations;

namespace ActionFilter;

public class WeatherForecast : IEntity
{
    [Required] public DateOnly Date { get; set; }
    [Required] public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    [MaxLength(2)] 
    public string? Summary { get; set; }
    [Key] public Guid Id { get; set; }
}