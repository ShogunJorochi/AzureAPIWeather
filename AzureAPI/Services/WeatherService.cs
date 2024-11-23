// Services/WeatherService.cs
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class WeatherService
{
    private readonly HttpClient _httpClient;

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<decimal?> GetTemperatureAsync(string cityName)
    {
        var apiKey = "90a0861c321e589612716a5304a4e33d"; 
        var url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric";

        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var weatherData = await response.Content.ReadFromJsonAsync<WeatherResponse>();
            return weatherData?.Main?.Temp; 
        }

        return null; 
    }
}

// response model according to the API's response structure
public class WeatherResponse
{
    public Main Main { get; set; }
}

public class Main
{
    public decimal Temp { get; set; }
}