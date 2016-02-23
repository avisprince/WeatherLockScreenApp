using System.Runtime.Serialization;

namespace WeatherClient.DataObjects
{
    [DataContract]
    public class CurrentForecast
    {
        [DataMember(Name = "time")]
        public int Time { get; set; }

        [DataMember(Name = "summary")]
        public string Summary { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "temperature")]
        public double Temperature { get; set; }

        [DataMember(Name = "apparentTemperature")]
        public double ApparentTemperature { get; set; }
    }
}
