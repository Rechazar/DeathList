using System;
using System.Globalization;
using Xamarin.Forms;

namespace DeathList.Views
{
    public class ChangeCompleteActionTextConverter : IValueConverter
    {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isCompleted = (bool)value;
            return isCompleted ? "Incomplete" : "Complete";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Not used since we only want to convert a boolean to text
            throw new NotImplementedException();
        }
    }
}
