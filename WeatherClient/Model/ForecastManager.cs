using System;
using System.Linq;
using System.Threading.Tasks;
using WeatherClient.DataObjects;
using Windows.Devices.Geolocation;

namespace WeatherClient.Model
{
    public static class ForecastManager
    {
        public static async Task<Forecast> UpdateForecast(bool updateGeoposition)
        {
            var forecast = await GetForecast(updateGeoposition);
            
            LockScreenClient.SetLockScreenText(forecast);

            return forecast;
        }

        private static async Task<Forecast> GetForecast(bool updateGeoposition)
        {
            var forecast = await DataManager.LoadForecast();

            // If the forecast cannot be loaded, make a web api call
            // If a request for an update is made, check the position first before making another web api call
            // Should notify user in lock screen that location must be on
            if (forecast == null || updateGeoposition)
            {
                var pos = await GetGeoposition();
                var latitude = pos.Coordinate.Latitude;
                var longitude = pos.Coordinate.Longitude;

                if (forecast == null || 
                    forecast.HourlyForecast.Forecast.Count == 0 ||
                    Math.Abs(forecast.Latitude - latitude) > 0.5 ||
                    Math.Abs(forecast.Longitude - longitude) > 0.5)
                {
                    return await GetAndSaveForecast(latitude, longitude);
                }
            }

            // If the forecast was from the previous day, make a call to the server
            // Use the stored lat, lon values
            var todaysForecast = forecast.DailyForecast.Forecast.First();
            var todaysForecastTime = ConvertUnixToDateTime(todaysForecast.Time);
            if (DateTime.Now.Day - todaysForecastTime.Day > 0)
            {
                return await GetAndSaveForecast(forecast.Latitude, forecast.Longitude);
            }

            // If the forecast is over an hour old, pop off the old forecast and get the next one
            var hourlyForecast = forecast.HourlyForecast.Forecast.First();
            var hourlyForecastTime = ConvertUnixToDateTime(hourlyForecast.Time);

            var hourDiff = DateTime.UtcNow.Hour - hourlyForecastTime.Hour;
            if (hourDiff > 0)
            {
                if (hourDiff >= forecast.HourlyForecast.Forecast.Count)
                {
                    return await GetAndSaveForecast(forecast.Latitude, forecast.Longitude);
                }

                forecast.HourlyForecast.Forecast.RemoveRange(0, hourDiff);
                await DataManager.SaveForecast(forecast);
            }

            return forecast;
        }

        private static async Task<Geoposition> GetGeoposition()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            var geolocator = new Geolocator();
            return await geolocator.GetGeopositionAsync();
        }

        private static async Task<Forecast> GetAndSaveForecast(double latitude, double longitude)
        {
            var forecast = await ForecastClient.GetForecast(latitude, longitude);
            await DataManager.SaveForecast(forecast);

            return forecast;
        }

        private static DateTime ConvertUnixToDateTime(int unixTimeStamp)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTimeStamp);
        }
    }
}
