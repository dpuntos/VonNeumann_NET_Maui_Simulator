using System.Globalization;

namespace VonNeumann.MauiSample
{
    internal class ByteToBinaryStringConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            //Byte to string [ex: "00000010"]
            return System.Convert.ToString((byte)value, 2).PadLeft(8, '0');
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
