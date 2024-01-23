using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace LostArkManager.LOSTARK.Extensions
{
    public class ImageButton
    {
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.RegisterAttached("ImageSource", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null));

        public static void SetImageSource(UIElement element, ImageSource value)
        {
            element.SetValue(ImageSourceProperty, value);
        }

        public static ImageSource GetImageSource(UIElement element)
        {
            return (ImageSource)element.GetValue(ImageSourceProperty);
        }
    }
}
