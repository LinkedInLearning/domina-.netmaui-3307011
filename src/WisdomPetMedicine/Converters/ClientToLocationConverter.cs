using System.Globalization;
using WisdomPetMedicine.DataAccess;

namespace WisdomPetMedicine.Converters;
public class ClientToLocationConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is Client client ? new Location(client.Lat.Value, client.Lon.Value) : null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}