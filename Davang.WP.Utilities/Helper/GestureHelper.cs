using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Davang.WP.Utilities.Helper
{
    public class GestureHelper
    {
        public static GeneralTransform GetTransformNoTranslation(CompositeTransform transform)
        {
            CompositeTransform newTransform = new CompositeTransform();
            newTransform.Rotation = transform.Rotation;
            newTransform.ScaleX = transform.ScaleX;
            newTransform.ScaleY = transform.ScaleY;
            newTransform.CenterX = transform.CenterX;
            newTransform.CenterY = transform.CenterY;
            newTransform.TranslateX = 0;
            newTransform.TranslateY = 0;

            return newTransform;
        }

        public static Orientation GetDirection(double x, double y)
        {
            return Math.Abs(x) >= Math.Abs(y) ? System.Windows.Controls.Orientation.Horizontal : System.Windows.Controls.Orientation.Vertical;
        }
    }
}
