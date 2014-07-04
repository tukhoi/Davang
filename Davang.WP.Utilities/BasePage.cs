﻿using Davang.Utilities.Log;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Davang.WP.Utilities
{
    public class BasePage : PhoneApplicationPage
    {
        static string BackgroundImageUri = "/Images/background.png";
        static string LayoutRoot = "LayoutRoot";

        public static void Initialize(string backgroundImageUri, string layoutRoot)
        {
            BackgroundImageUri = backgroundImageUri;
            LayoutRoot = layoutRoot;
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

        protected void SetProgressIndicator(bool isVisible = true, string message = "")
        {
            if (SystemTray.ProgressIndicator == null)
                SystemTray.ProgressIndicator = new ProgressIndicator();

            SystemTray.ProgressIndicator.IsIndeterminate = isVisible;
            SystemTray.ProgressIndicator.IsVisible = isVisible;
            SystemTray.ProgressIndicator.Text = message;
        }

        protected void BackToMainPage()
        {
            while (NavigationService.CanGoBack && NavigationService.BackStack.Count() > 1)
                NavigationService.RemoveBackEntry();
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
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

        protected bool IsMainPage()
        {
            return NavigationService.BackStack.Count() == 0;
        }

        protected void SetBackground()
        {
            SetBackground(LayoutRoot);
        }

        protected void SetBackground(string rootControlName = "")
        {
            var grid = this.FindName(rootControlName) as Grid;

            if (grid != null)
            {
                var background = new ImageBrush();
                background.ImageSource = new BitmapImage(new Uri(BackgroundImageUri, UriKind.Relative));
                grid.Background = background;
            }
        }

        protected void LogPage()
        {
            GA.LogPage(this.ToString());
        }

        protected void LogAdsClicked(string adsControlName)
        {
            GA.LogAdsClicked(this.ToString(), adsControlName);
        }
    }
}
