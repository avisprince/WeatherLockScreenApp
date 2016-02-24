using System.ComponentModel;
using System.Threading.Tasks;
using WeatherClient.DataObjects;
using WeatherClient.Model;

namespace WeatherLockScreen.ViewModel
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        public Forecast Forecast
        {
            get;
            private set;
        }

        private string status;
        public string Status
        {
            get
            {
                return this.status;
            }
            set
            {
                if (this.status != value)
                {
                    this.status = value;
                    this.NotifyPropertyChanged("Status");
                }
            }
        }

        public async Task UpdateLockScreen()
        {
            this.Status = "Loading...";
            this.Forecast = await ForecastManager.UpdateForecast(true);
            this.Status = "Done! Go check your lock screen.";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
