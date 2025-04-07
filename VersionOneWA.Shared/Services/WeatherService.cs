using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace VersionOneWA.Shared.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "bbb429e6b13cf45490dcb8ef9e24894f";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherForecastResponse> GetWeatherForecastAsync(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&units=metric&appid={_apiKey}";
            var forecastResponse = await _httpClient.GetFromJsonAsync<WeatherForecastResponse>(url);

            var dailyForecast = forecastResponse.List
                .GroupBy(f => f.Dt_txt.Split(' ')[0])
                .Select(g => new WeatherDailyForecast
                {
                    Date = g.Key,
                    Temp = (float)Math.Round(g.Average(f => f.Main.Temp), 1), // Zaokrúhlenie na 1 desatinné miesto
                    Description = g.First().Weather[0].Description,
                    Icon = g.First().Weather[0].Icon  // Pridanie ikony
                })
                .Take(5)
                .ToList();

            forecastResponse.DailyForecast = dailyForecast;
            return forecastResponse;
        }

        public class WeatherForecastResponse
        {
            public List<WeatherData> List { get; set; }
            public List<WeatherDailyForecast> DailyForecast { get; set; }
        }
        public class WeatherDailyForecast
        {
            public string Date { get; set; }
            public float Temp { get; set; }
            public string Description { get; set; }
            public string Icon { get; set; }
        }
        public class WeatherData
        {
            public MainWeather Main { get; set; }
            public List<WeatherDescription> Weather { get; set; }
            public string Dt_txt { get; set; }
        }

        public class MainWeather
        {
            public float Temp { get; set; }
        }

        public class WeatherDescription
        {
            public string Description { get; set; }
            public string Icon { get; set; }
        }

    }
}
   
