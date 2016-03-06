using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherClient.DataObjects;

namespace WeatherClient.Model
{
    public static class ForecastClient
    {
        private static string baseUrl = "https://api.forecast.io/forecast/";

        private static string appId = "958f4aa4a898ea1f742fc3d7f10a8e58";

        public static async Task<Forecast> GetForecast(double latitude, double longitude)
        {
            var url = baseUrl + appId + "/" + latitude.ToString() + "," + longitude.ToString();

            var request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";

            var response = await request.GetResponseAsync() as HttpWebResponse;

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                var forecast = JsonConvert.DeserializeObject<Forecast>(sr.ReadToEnd());
                forecast.LastUpdate = DateTime.Now;
                forecast.Latitude = latitude;
                forecast.Longitude = longitude;

                return forecast;
            }
        }
    }
}
