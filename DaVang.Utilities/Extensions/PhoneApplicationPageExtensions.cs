﻿//using Microsoft.Phone.Controls;
//using Microsoft.Phone.Shell;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;

//namespace Davang.Utilities.Extensions
//{
//    public static class PhoneApplicationPageExtensions
//    {
//        public static void SetProgressIndicator(this PhoneApplicationPage page, bool isVisible, string message = "")
//        {
//            if (SystemTray.ProgressIndicator == null)
//                SystemTray.ProgressIndicator = new ProgressIndicator();

//            SystemTray.ProgressIndicator.IsIndeterminate = isVisible;
//            SystemTray.ProgressIndicator.IsVisible = isVisible;
//            SystemTray.ProgressIndicator.Text = message;
//        }

//        public static void BackToMainPage(this PhoneApplicationPage page)
//        {
//            var mainPageUri = "/MainPage.xaml";

//            string terms = page.NavigationContext.QueryString.GetQueryString("terms");
//            mainPageUri += !string.IsNullOrEmpty(terms) ? "?terms=" + terms : string.Empty;

//            page.NavigationService.Navigate(new Uri(mainPageUri, UriKind.Relative));
//        }

//        public static void BackToPreviousPage(this PhoneApplicationPage page)
//        {
//            page.NavigationService.GoBack();
//        }

//        public static void SetBackground(this PhoneApplicationPage page, Uri backgroundImageUri)
//        {
//            var background = new ImageBrush();
//            background.ImageSource = new BitmapImage(backgroundImageUri);
//            page.Background = background;
//        }
//    }
//}
