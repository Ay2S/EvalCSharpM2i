using EvalTechnique.Test.Client.BusinessObjects.Enums;
using EvalTechnique.Test.Client.ViewModel;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace EvalTechnique.Test.Client.Converters
{
    internal class VideoTypeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return Visibility.Collapsed;

            if (value is VideoListViewModel itemListVM
                && Enum.TryParse(parameter.ToString(), out VideoType videoType)
                && itemListVM.VideoType == videoType)
            {
                return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
