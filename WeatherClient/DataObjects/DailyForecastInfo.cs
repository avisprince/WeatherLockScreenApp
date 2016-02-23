using System.Runtime.Serialization;

namespace WeatherClient.DataObjects
{
    [DataContract]
    public class DailyForecastInfo
    {
        [DataMember(Name = "time")]
        public int Time { get; set; }

        [DataMember(Name = "summary")]
        public string Summary { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "temperatureMin")]
        public double MinTemperature { get; set; }

        [DataMember(Name = "temperatureMinTime")]
        public int MinTemperatureTime { get; set; }

        [DataMember(Name = "apparentTemperatureMin")]
        public double MinApparentTemperature { get; set; }

        [DataMember(Name = "temperatureMax")]
        public double MaxTemperature { get; set; }

        [DataMember(Name = "temperatureMaxTime")]
        public int MaxTemperatureTime { get; set; }

        [DataMember(Name = "apparentTemperatureMax")]
        public double MaxApparentTemperature { get; set; }
    }
}
