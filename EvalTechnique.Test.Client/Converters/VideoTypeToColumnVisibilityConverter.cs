using EvalTechnique.Test.Client.BusinessObjects.Enums;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace EvalTechnique.Test.Client.Converters
{
    internal class VideoTypeToColumnVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return
                Enum.TryParse(value?.ToString(), out VideoType videoType) && videoType == VideoType.All
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
