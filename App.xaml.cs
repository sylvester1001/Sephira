using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
namespace Sepat
{
    public partial class App : Application
    {
        private Window? _window;

        public static Window MainWindow { get; private set; } = null!;

        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            _window = new Window();
            MainWindow = _window;

            // Enable Mica backdrop for the Windows 11 translucent feel
            _window.SystemBackdrop = new MicaBackdrop
            {
                Kind = MicaKind.Base
            };

            // Set window size
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(_window);
            var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
            var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
            appWindow.Resize(new Windows.Graphics.SizeInt32(1280, 820));
            appWindow.Title = "Sepat";

            // Set custom title bar
            _window.ExtendsContentIntoTitleBar = true;

            _window.Content = new ShellPage();
            _window.Activate();
        }
    }
}
