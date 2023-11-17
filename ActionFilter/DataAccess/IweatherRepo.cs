namespace ActionFilter.DataAccess;

public interface IWeatherRepo
{
    Task<List<WeatherForecast?>> GetWeather();
    Task<WeatherForecast?> FindById(Guid id);

}