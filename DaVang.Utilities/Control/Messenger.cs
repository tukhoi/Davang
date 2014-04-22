using Coding4Fun.Toolkit.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Davang.Utilities.Control
{
    public class Messenger
    {
        public static void Initialize(string title, Uri toastImageUri)
        {
            _title = title;
            _toastImageUri = toastImageUri;
        }

        private static string _title;
        private static Uri _toastImageUri;

        public static void ShowToast(string message, string title = "")
        {
            ToastPrompt toast = new ToastPrompt();
            toast.TextWrapping = System.Windows.TextWrapping.Wrap;
            toast.Title = string.IsNullOrEmpty(title) ? _title : title;
            toast.Message = message;
            toast.FontSize = 20;
            toast.TextOrientation = System.Windows.Controls.Orientation.Vertical;
            toast.ImageSource = new BitmapImage(_toastImageUri);

            toast.Show();
        }
    }
}
