using Newtonsoft.Json;
using System.Net;
using Test_web_app.Models;
using Test_web_app.Services.Interfaces;

namespace Test_web_app.Services
{
    public class ApiService : IApiService
    {
        private const string API_KEY = "ceca0dfec12ee134d93c97f0a45b0d6a";

        public WeatherResponse Get(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API_KEY}";

            var web = new WebClient();

            var response = web.DownloadString(url);

            WeatherResponse myDeserializedClass = JsonConvert.DeserializeObject<WeatherResponse>(response);

            myDeserializedClass.main.temp_max = myDeserializedClass.main.temp_max - 273.15;
            myDeserializedClass.main.temp_min = myDeserializedClass.main.temp_min - 273.15;

            return myDeserializedClass;

        }
    }
}
