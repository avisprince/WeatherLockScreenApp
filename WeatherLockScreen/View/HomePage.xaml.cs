using System;
using WeatherLockScreen.ViewModel;
using Windows.ApplicationModel.Background;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace WeatherLockScreen.View
{
    public sealed partial class HomePage : Page
    {
        private const string taskName = "WeatherBackgroundTask";
        private const string taskEntryPoint = "BackgroundTasks.WeatherBackgroundTask";

        private HomePageViewModel homePageViewModel;

        public HomePage()
        {
            this.homePageViewModel = new HomePageViewModel();
            this.DataContext = this.homePageViewModel;

            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.RegisterBackgroundTask();
        }
        
        private async void RegisterBackgroundTask()
        {
            var backgroundAccessStatus = await BackgroundExecutionManager.RequestAccessAsync();

            if (backgroundAccessStatus == BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity ||
                backgroundAccessStatus == BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity)
            {
                foreach (var task in BackgroundTaskRegistration.AllTasks)
                {
                    if (task.Value.Name == taskName)
                    {
                        task.Value.Unregister(true);
                    }
                }

                var taskBuilder = new BackgroundTaskBuilder();
                taskBuilder.Name = taskName;
                taskBuilder.TaskEntryPoint = taskEntryPoint;
                taskBuilder.SetTrigger(new TimeTrigger(15, false));
                taskBuilder.Register();
            }
        }

        private async void GetWeatherButton_Click(object sender, RoutedEventArgs e)
        {
            this.GetWeatherProgressBar.Visibility = Visibility.Visible;
            await this.homePageViewModel.UpdateLockScreen();
            this.GetWeatherProgressBar.Visibility = Visibility.Collapsed;
        }
    }
}
