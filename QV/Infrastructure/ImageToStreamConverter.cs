using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace QV.Infrastructure
{
    public class ImageToStreamConverter : IValueConverter
    {
        public object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            var im = (byte[])value;
            if (im != null && im.Length != 0)
                return ImageSource.FromStream(() => new BufferedStream(new MemoryStream(im)));
            return (ImageSource)null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new object();
        }
    }
}
