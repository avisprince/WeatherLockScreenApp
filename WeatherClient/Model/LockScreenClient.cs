using System;
using System.Linq;
using WeatherClient.DataObjects;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace WeatherClient.Model
{
    public static class LockScreenClient
    {
        private static readonly char degree = (char)176;

        public static void SetLockScreenText(Forecast forecast)
        {
            var currentHour = forecast.HourlyForecast.Forecast.First();
            var currentTemp = Convert.ToInt32(currentHour.Temperature).ToString() + degree;
            var feelsLike = Convert.ToInt32(currentHour.ApparentTemperature).ToString() + degree;

            var todaysForecast = forecast.DailyForecast.Forecast.First();
            var highTemp = Convert.ToInt32(todaysForecast.MaxTemperature).ToString() + degree;
            var lowTemp = Convert.ToInt32(todaysForecast.MinTemperature).ToString() + degree;

            string line1 = "Right now: " + currentTemp + ". Feels like: " + feelsLike + ". " + currentHour.Summary + ".";
            string line2 = "High of " + highTemp + ". Low of " + lowTemp + ". Updated: " + DateTime.Now.ToString("h:mm tt");
            string line3 = todaysForecast.Summary;

            UpdateLockScreenText(line1, line2, line3);
        }

        public static void UpdateLockScreenText(string line1, string line2, string line3)
        {
            var tile = String.Format(
                "<tile>" +
                    "<visual>" +
                        "<binding template=\"TileWideText01\">" +
                            "<text id=\"1\">{0}</text>" +
                            "<text id=\"2\">{1}</text>" +
                            "<text id=\"3\">{2}</text>" +
                        "</binding>" +
                        //"<binding template=\"TileSquareText03\">" +
                        //    "<text id=\"1\">{0}</text>" +
                        //    "<text id=\"2\">{1}</text>" +
                        //    "<text id=\"3\">{2}</text>" +
                        //"</binding>" +
                    "</visual>" +
                "</tile>",
                line1, line2, line3);

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(tile);

            var tileNotification = new TileNotification(xmlDoc);
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
        }

        private static DateTime ConvertUnixToDateTime(int unixTimeStamp)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0);
            return epoch.AddSeconds(unixTimeStamp);
        }
    }
}
