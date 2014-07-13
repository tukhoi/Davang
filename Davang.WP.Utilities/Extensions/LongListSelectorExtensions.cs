using Davang.Utilities.ApplicationServices;
using Davang.Utilities.Log;
using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davang.WP.Utilities.Extensions
{
    public static class LongListSelectorExtensions
    {
        public static void ScrollTo<TId>(this LongListSelector list, TId scrollToId)
        {
            try
            {
                if (list.ItemsSource == null || list.ItemsSource.Count == 0 || scrollToId == null) return;

                int i = 0;
                while (i < list.ItemsSource.Count && !scrollToId.Equals((list.ItemsSource[i] as BaseEntity<TId>).Id))
                    i++;
                if (i < list.ItemsSource.Count && list.ItemsSource[i] != null)
                    list.ScrollTo(list.ItemsSource[i]);
            }
            catch (Exception ex)
            {
                GA.LogException(ex);
            }
        }

        public static void ScrollToTop(this LongListSelector list)
        {
            try
            {
                if (list.ItemsSource == null || list.ItemsSource.Count == 0) return;
                list.ScrollTo(list.ItemsSource[0]);
            }
            catch (Exception ex)
            {
                GA.LogException(ex);
            }
        }
    }
}
