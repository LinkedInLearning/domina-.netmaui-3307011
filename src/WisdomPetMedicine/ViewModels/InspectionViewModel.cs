using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WisdomPetMedicine.DataAccess;
using WisdomPetMedicine.Services;

namespace WisdomPetMedicine.ViewModels;
public partial class InspectionViewModel(WpmOutDbContext wpmOutDbContext, INavigationService navigationService) : ViewModelBase, IQueryAttributable
{
    private int ClientId { get; set; }

    [ObservableProperty]
    ObservableCollection<string> photos = new();

    [RelayCommand]
    private async Task TakePhoto()
    {
        var result = await MediaPicker.Default.CapturePhotoAsync();
        if (result != null)
        {
            Photos.Add(result.FullPath);
            SaveInspectionCommand.NotifyCanExecuteChanged();
        }
    }

    [RelayCommand]
    private async Task DeletePhoto(string file)
    {
        var result = await Shell.Current.DisplayAlert("Borrar foto", "¿Desea borrar?", "Ok", "Cancelar");
        if (result)
        {
            File.Delete(file);
            Photos.Remove(file);
            SaveInspectionCommand.NotifyCanExecuteChanged();
        }
    }

    [RelayCommand(CanExecute = nameof(CanSaveInspection))]
    private async Task SaveInspection()
    {
        var location = await GetCurrentLocation();

        var newInspection = new Inspection
        {
            ClientId = ClientId,
            Lat = location.Latitude,
            Lon = location.Longitude
        };
        foreach (var photo in Photos)
        {
            var newItem = new InspectionItem() 
            {
                Type = InspectionType.Photo,
                Media = await File.ReadAllBytesAsync(photo)
            };
            newInspection.Items.Add(newItem);
        }
        wpmOutDbContext.Add(newInspection);
        await wpmOutDbContext.SaveChangesAsync();
        await navigationService.GoToAsync("..");
    }

    private bool CanSaveInspection()
    {
        return Photos.Count > 0;
    }

    private async Task<Location> GetCurrentLocation()
    {
        GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(5));
        var location = await Geolocation.Default.GetLocationAsync(request);
        return location;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var clientId = int.Parse(query["id"].ToString());
        ClientId = clientId;
    }
}