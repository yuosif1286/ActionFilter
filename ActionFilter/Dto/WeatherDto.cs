namespace ActionFilter.Dto;

public class WeatherDto
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public String? OrderBy { get; set; }
}