using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WeatherApiCommunication
{
    public class Client
    {
        static HttpClient client = new HttpClient();
        private static string apiKey = "32e7d04d86999102feb4439b0dc97b63";

        public static async Task<WeatherData> RunAsync(string city)
        {
            client.BaseAddress = new Uri("http://localhost:55268/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            WeatherData data = null;

            try
            {
                data = await GetProductAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return data;
        }

        static async Task<WeatherData> GetProductAsync(string path)
        {
            WeatherData weatherData = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                weatherData = await response.Content.ReadAsAsync<WeatherData>();
            }
            return weatherData;
        }
    }
}
