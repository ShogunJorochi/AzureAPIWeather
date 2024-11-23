using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly WeatherService _weatherService;

    public WeatherController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet("{cityName}")]
    public async Task<IActionResult> GetTemperature(string cityName)
    {
        var temperature = await _weatherService.GetTemperatureAsync(cityName);
        if (temperature.HasValue)
        {
            return Ok(new { Temperature = temperature.Value });
        }

        return NotFound("City not found or error retrieving data.");
    }
}