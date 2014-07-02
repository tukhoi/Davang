using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Davang.WP.Utilities
{
    public class BasePage : PhoneApplicationPage
    {
        static string _backgroundImage = "/Resources/Images/background.png";
        static string _layoutRoot = "LayoutRoot";
        static string _mainPage = "MainPage.xaml";

        public static void Initialize(string backgroundImage = "/Resources/Images/background.png", string layoutRoot = "LayoutRoot", string mainPage = "MainPage.xaml")
        {
            _backgroundImage = backgroundImage;
            _layoutRoot = layoutRoot;
            _mainPage = mainPage;
        }

        public BasePage()
        {
            this.Loaded += BasePage_Loaded;
        }

        void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            SetBackground();
            LogPage();
        }

        protected void SetProgressIndicator(bool isVisible, string message = "")
        {
            if (SystemTray.ProgressIndicator == null)
                SystemTray.ProgressIndicator = new ProgressIndicator();

            SystemTray.ProgressIndicator.IsIndeterminate = isVisible;
            SystemTray.ProgressIndicator.IsVisible = isVisible;
            SystemTray.ProgressIndicator.Text = message;
        }

        protected void BackToMainPage()
        {
            NavigationService.Navigate(new Uri(_mainPage, UriKind.Relative));
        }

        protected void BackToPreviousPage(short skip = 0)
        {
            RemovePreviousPage(skip);

            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
            else
                BackToMainPage();
        }

        protected void RemovePreviousPage(short count = 1)
        {
            for (short i = 0; i < count && NavigationService.BackStack.Count() > 0; i++)
                NavigationService.RemoveBackEntry();
        }

        protected void SetMainPage()
        {
            while (NavigationService.CanGoBack)
                NavigationService.RemoveBackEntry();
        }

        protected void SetBackground()
        {
            SetBackground(_layoutRoot);
        }

        protected void SetBackground(string rootControlName = "")
        {
            var grid = this.FindName(rootControlName) as Grid;

            if (grid != null)
            {
                var background = new ImageBrush();
                background.ImageSource = new BitmapImage(new Uri(_backgroundImage, UriKind.Relative));
                grid.Background = background;
            }
        }

        protected void LogPage()
        {
            GoogleAnalytics.EasyTracker.GetTracker().SendView(this.ToString());
        }

        protected void LogAdsClicked()
        {
            GoogleAnalytics.EasyTracker.GetTracker().SendEvent(this.ToString(), "Ads clicked", null, 0);
        }
    }
}
