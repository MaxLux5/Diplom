using System.Globalization;
using System.Windows.Data;

namespace Diplom.Converters
{
    public class IsEqualOrLessThanConverter : IValueConverter
    {
        public static readonly IValueConverter Instance;
        static IsEqualOrLessThanConverter()
        {
            Instance = new IsEqualOrLessThanConverter();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int intValue = (int)value;
            int compareToValue = (int)parameter;

            return intValue <= compareToValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
