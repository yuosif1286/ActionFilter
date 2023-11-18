using ActionFilter.Paging;

namespace ActionFilter.DataAccess;

public interface IWeatherRepo
{
    Task<PagedList<WeatherForecast?>> GetWeather(int pageNumber,int pageSize,string? orderBy);
    Task<WeatherForecast?> FindById(Guid id);

}