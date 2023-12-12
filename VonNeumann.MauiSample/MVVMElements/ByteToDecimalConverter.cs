using System.Globalization;

namespace VonNeumann.MauiSample
{
    internal class ByteToDecimalConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            //Byte to string [ex: "12"]
            return $"Dec: {System.Convert.ToInt32(value).ToString()}";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
