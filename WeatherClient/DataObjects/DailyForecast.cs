using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WeatherClient.DataObjects
{
    [DataContract]
    public class DailyForecast
    {
        [DataMember(Name = "summary")]
        public string Summary { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "data")]
        public List<DailyForecastInfo> Forecast { get; set; }
    }
}
