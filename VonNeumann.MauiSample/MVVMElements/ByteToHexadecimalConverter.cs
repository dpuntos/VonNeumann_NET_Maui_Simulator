using System.Globalization;

namespace VonNeumann.MauiSample
{
    internal class ByteToHexadecimalConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            //Byte to string [ex: "0A"]
            return $"Hex: {System.Convert.ToString((byte)value, 16).PadLeft(2, '0').ToUpper()}";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
