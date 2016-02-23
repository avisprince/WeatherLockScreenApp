using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using WeatherClient.DataObjects;
using Windows.Storage;

namespace WeatherClient.Model
{
    public static class DataManager
    {
        /// <summary>
        /// The file name containing the saved data
        /// </summary>
        private const string fileName = "forecast.txt";

        /// <summary>
        /// Save the forecast to disk
        /// </summary>
        /// <param name="forecast">The forecast to save</param>
        /// <returns></returns>
        public static async Task SaveForecast(Forecast forecast)
        {
            var saveFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

            using (var stream = await saveFile.OpenStreamForWriteAsync())
            {
                var serializer = new DataContractSerializer(typeof(Forecast));
                serializer.WriteObject(stream, forecast);

                await stream.FlushAsync();
            }
        }

        /// <summary>
        /// Loads the saved forecast from disk
        /// </summary>
        /// <returns>The saved forecast</returns>
        public static async Task<Forecast> LoadForecast()
        {
            var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(fileName);
            
            var serializer = new DataContractSerializer(typeof(Forecast));
            return (Forecast)serializer.ReadObject(stream);
        }
    }
}
