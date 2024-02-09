using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Maps;
using System.Collections.ObjectModel;
using WisdomPetMedicine.DataAccess;

namespace WisdomPetMedicine.ViewModels;
public partial class MapViewModel(WpmDbContext wpmDbContext) : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<Client> clients = new(wpmDbContext.Clients);

    [RelayCommand]
    private void Load(Microsoft.Maui.Controls.Maps.Map map)
    {
        var mapSpan = MapSpan.FromCenterAndRadius(GetCentroid(Clients), Distance.FromKilometers(2))
                             .WithZoom(0.3);
        map.MoveToRegion(mapSpan);
    }

    private static Location GetCentroid(IEnumerable<Client> clients)
    {
        double avgLat = clients.Average(client => client.Lat ?? 0);
        double avgLon = clients.Average(client => client.Lon ?? 0);

        return new Location(avgLat, avgLon);
    }
}