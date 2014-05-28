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

            _toast = new ToastPrompt();
            _toast.FontSize = 20;
            _toast.TextOrientation = System.Windows.Controls.Orientation.Vertical;
            _toast.ImageSource = new BitmapImage(_toastImageUri);
            _toast.TextWrapping = System.Windows.TextWrapping.Wrap;
            _toast.Completed += toast_Completed;
        }

        private static string _title;
        private static Uri _toastImageUri;
        private static Action _completedAction;
        private static ToastPrompt _toast;

        public static void ShowToast(string message, string title = "", Action completedAction = null)
        {
            if (completedAction != null)
                _completedAction = completedAction;
            
            _toast.Title = string.IsNullOrEmpty(title) ? _title : title;
            _toast.Message = message;
            _toast.Show();
        }

        //public static void ShowToast(string message, string title = "")
        //{
        //    ShowToast(null, message, title);
        //}

        private static void toast_Completed(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (_completedAction != null)
            {
                _completedAction.Invoke();
                _completedAction = null;
            }
        }
    }
}
