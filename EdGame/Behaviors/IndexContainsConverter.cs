

using System.Globalization;

namespace EdGame.Behaviors.IndexContainsConverter;

 public class IndexContainsConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
        {
            if (value is List<int> winningButtons && parameter is string indexStr && int.TryParse(indexStr, out int index))
            {
                return winningButtons.Contains(index);
            }
            return false;
        }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}