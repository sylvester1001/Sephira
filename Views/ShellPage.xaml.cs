using Microsoft.UI.Xaml.Navigation;

namespace Sepat.Views
{
    public sealed partial class ShellPage : Page
    {
        public ShellPage()
        {
            this.InitializeComponent();

            // Set the custom title bar
            App.MainWindow.SetTitleBar(AppTitleBar);
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            // Select the first item (Dashboard) on load
            NavView.SelectedItem = NavView.MenuItems[0];
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                ContentFrame.Navigate(typeof(SettingsPage),
                    null,
                    new Microsoft.UI.Xaml.Media.Animation.EntranceNavigationTransitionInfo());
                return;
            }

            if (args.SelectedItemContainer is NavigationViewItem item)
            {
                var tag = item.Tag?.ToString();
                var pageType = tag switch
                {
                    "Dashboard" => typeof(DashboardPage),
                    "MapFarming" => typeof(MapFarmingPage),
                    "PotionConfig" => typeof(PotionConfigPage),
                    "TradeConfig" => typeof(TradeConfigPage),
                    "NpcDetection" => typeof(NpcDetectionPage),
                    "Logs" => typeof(LogsPage),
                    _ => typeof(DashboardPage)
                };

                ContentFrame.Navigate(pageType,
                    null,
                    new Microsoft.UI.Xaml.Media.Animation.EntranceNavigationTransitionInfo());
            }
        }
    }
}
