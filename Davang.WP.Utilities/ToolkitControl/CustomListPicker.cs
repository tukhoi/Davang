using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Phone.Controls;

namespace Davang.WP.Utilities.ToolkitControl
{
    class CustomListPicker : ListPicker
    {
        public override void OnApplyTemplate()
        {
            BindBackground();
            base.OnApplyTemplate();
        }

        void BindBackground()
        {
            var canvas = GetTemplateChild("ItemsPresenterHost") as Canvas;
            int i = 1;
        }
    }
}
