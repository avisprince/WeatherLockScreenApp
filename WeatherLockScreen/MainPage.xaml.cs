using System;
using Windows.ApplicationModel.Background;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace WeatherLockScreen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            BackgroundAccessStatus status = await BackgroundExecutionManager.RequestAccessAsync();
            Status.Text = GetBadgeAcessMessage(status);
        }

        private string GetBadgeAcessMessage(BackgroundAccessStatus status)
        {
            string message = string.Empty;

            switch (status)
            {
                case BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity:
                    message = "May use active real-time connectivity.";
                    break;
                case BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity:
                    message = "Always on real-time connectivity.";
                    break;
                case BackgroundAccessStatus.Denied:
                    message = "User denied lock screen badge access.";
                    break;
                case BackgroundAccessStatus.Unspecified:
                default:
                    message = "Unknown lock screen badge access status.";
                    break;
            }

            return message;
        }

        private async void SendBadge_Click(object sender, RoutedEventArgs e)
        {
            //string badge = String.Format("<badge value=\"{0}\"/>", Message.Text);
            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.LoadXml(badge);
            //BadgeNotification badgeNotification = new BadgeNotification(xmlDoc);
            //BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(badgeNotification);
            //Status.Text = "Lock Screen Badge was sent.";
        }

        private void SendTile_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
