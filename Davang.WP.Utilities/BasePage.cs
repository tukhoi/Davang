﻿using Davang.Utilities.Log;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public abstract class BasePage : PhoneApplicationPage
    {
        protected static string BackgroundImageUri;
        protected static string LayoutRootName;
        protected static string MainPage;

        public static void Initialize(string backgroundImageUri = "/Images/background.png", string layoutRoot = "LayoutRoot", string mainPage = "MainPage")
        {
            BackgroundImageUri = backgroundImageUri;
            LayoutRootName = layoutRoot;
            MainPage = mainPage;
        }

        public BasePage()
        {
            this.Loaded += BasePage_Loaded;
        }

        void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            SetBackground();
            LogPage();
            this.Loaded -= BasePage_Loaded;
        }

        protected void SetProgressIndicator(bool isVisible = true, string message = "")
        {
            if (SystemTray.ProgressIndicator == null)
                SystemTray.ProgressIndicator = new ProgressIndicator();

            SystemTray.ProgressIndicator.IsIndeterminate = isVisible;
            SystemTray.ProgressIndicator.IsVisible = isVisible;
            SystemTray.ProgressIndicator.Text = message;
        }

        protected void ActionOnChildControls<T>(DependencyObject obj, DependencyProperty propName, string propValue, Action<DependencyObject> action)
        {
            var count = VisualTreeHelper.GetChildrenCount(obj);
            if (count == 0)
                return;

            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(obj, i);

                if (child != null && child is T && child.GetValue(propName).Equals(propValue)) 
                    action(child);
                else
                    ActionOnChildControls<T>(child, propName, propValue, action);
            }
        }

        protected void BackToMainPage()
        {
            EmptyBackStack();
            NavigationService.Navigate(new Uri(MainPage, UriKind.Relative));
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

        protected void EmptyBackStack()
        {
            while (NavigationService.BackStack.Count() > 0)
                NavigationService.RemoveBackEntry();
        }

        protected void SetMainPage()
        {
            var thisPage = this.ToString().Split('.');
            if (thisPage.Length > 0)
                MainPage = string.Format("/{0}.xaml", thisPage[thisPage.Length - 1]);

            while (NavigationService.CanGoBack)
                NavigationService.RemoveBackEntry();
        }

        protected void SetAsSecondPage()
        {
            SetAsNPage(2);
        }

        protected void SetAsThirdPage()
        {
            SetAsNPage(3);
        }

        protected void SetAsNPage(int n)
        {
            while (NavigationService.BackStack.Count() > n-1)
                NavigationService.RemoveBackEntry();
        }

        protected bool IsMainPage()
        {
            return NavigationService.BackStack.Count() == 0;
        }

        protected void SetBackground()
        {
            SetBackground(LayoutRootName);
        }

        protected void SetBackground(string rootControlName = "")
        {
            var grid = this.FindName(rootControlName) as Grid;

            if (grid != null)
            {
                var background = new ImageBrush();
                background.ImageSource = new BitmapImage(new Uri(BackgroundImageUri, UriKind.Relative))
                    {
                        CreateOptions = BitmapCreateOptions.BackgroundCreation,
                    };
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
