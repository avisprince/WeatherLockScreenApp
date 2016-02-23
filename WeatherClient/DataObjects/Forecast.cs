using System.Runtime.Serialization;

namespace WeatherClient.DataObjects
{
    [DataContract]
    public class Forecast
    {
        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }

        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }

        [DataMember(Name = "currently")]
        public CurrentForecast CurrentForecast { get; set; }

        [DataMember(Name = "hourly")]
        public HourlyForecast HourlyForecast { get; set; }

        [DataMember(Name = "daily")]
        public DailyForecast DailyForecast { get; set; }
    }
}
