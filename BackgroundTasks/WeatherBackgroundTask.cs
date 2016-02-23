using WeatherClient.Model;
using Windows.ApplicationModel.Background;

namespace BackgroundTasks
{
    public sealed class WeatherBackgroundTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();

            await ForecastManager.UpdateForecast(false);

            deferral.Complete();
        }
    }
}
