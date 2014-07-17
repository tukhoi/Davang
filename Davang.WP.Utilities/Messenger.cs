using Coding4Fun.Toolkit.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DocBao.WP.Helper
{
    public class Messenger
    {
        public static void Initialize(string title, string toastImageUri, string backgroundImageUri = null, Brush foregroundColor = null)
        {
            _title = title;
            _toastImageUri = toastImageUri;
            _backgroundImageUri = backgroundImageUri;
            _foregroundColor = foregroundColor;
        }

        private static string _title;
        private static string _toastImageUri;
        private static string _backgroundImageUri;
        private static Brush _foregroundColor;

        public static void ShowToast(string message, string title = "", Action completedAction = null, int miliSecondsUntilHidden = 4000)
        {
            var toast = GetToastPrompt();

            EventHandler<PopUpEventArgs<string, PopUpResult>> toastCompleted = null;
            if (completedAction != null)
            {
                toastCompleted = ((sender, e) => completedAction.Invoke());
                toast.Completed += toastCompleted;
            }

            toast.Title = string.IsNullOrEmpty(title) ? _title : title;
            toast.Message = message;
            toast.MillisecondsUntilHidden = miliSecondsUntilHidden;
            toast.Show();
            //if (toastCompleted != null)
            //    toast.Completed -= toastCompleted;

            toast = null;
        }

        private static ToastPrompt GetToastPrompt()
        {
            var toast = new ToastPrompt();
            toast.FontSize = 20;
            toast.TextOrientation = System.Windows.Controls.Orientation.Vertical;
            toast.ImageSource = new BitmapImage(new Uri(_toastImageUri, UriKind.Relative));
            toast.TextWrapping = System.Windows.TextWrapping.Wrap;
            if (!string.IsNullOrEmpty(_backgroundImageUri))
            {
                var backgroundImage = new ImageBrush();
                backgroundImage.ImageSource = new BitmapImage(new Uri(_backgroundImageUri, UriKind.Relative));
                toast.Background = backgroundImage;
            }
            if (_foregroundColor != null)
                toast.Foreground = _foregroundColor;

            return toast;
        }

        //public static void ShowToast(string message, string title = "", Action completedAction = null, int miliSecondsUntilHidden = 4000)
        //{
        //    EventHandler<PopUpEventArgs<string, PopUpResult>> toastCompleted = null;
        //    if (completedAction != null)
        //    {
        //        toastCompleted = ((sender, e) => completedAction.Invoke());
        //        _toast.Completed += toastCompleted;
        //    }

        //    _toast.Title = string.IsNullOrEmpty(title) ? _title : title;
        //    _toast.Message = message;
        //    _toast.MillisecondsUntilHidden = miliSecondsUntilHidden;
        //    _toast.Show();
        //    if (toastCompleted != null)
        //        _toast.Completed -= toastCompleted;
        //}

        //public static void ShowToast(string message, string title = "")
        //{
        //    ShowToast(null, message, title);
        //}

        //private static void toast_Completed(object sender, PopUpEventArgs<string, PopUpResult> e)
        //{
        //    if (_completedAction != null)
        //    {
        //        _completedAction.Invoke();
        //        _completedAction = null;
        //    }
        //}
    }
}
