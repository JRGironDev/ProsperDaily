using System.Globalization;

namespace ProsperDaily;

public class AmountToCurrencyConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var isIncome = ((Label)parameter).Text;
        var amount = (decimal)value;
        if(isIncome == "True")
        {
            return $"+ {amount.ToString("C", CultureInfo.CurrentCulture)}";
        }
        else
        {
            return $"- {amount.ToString("C", CultureInfo.CurrentCulture)}";
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}