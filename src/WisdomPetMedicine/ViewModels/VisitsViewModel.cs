using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WisdomPetMedicine.DataAccess;
using WisdomPetMedicine.Services;
using WisdomPetMedicine.Views;

namespace WisdomPetMedicine.ViewModels;

public partial class VisitsViewModel : ViewModelBase
{
    private readonly INavigationService navigationService;

    [ObservableProperty]
    private int remainingVisits;

    [ObservableProperty]
    private ObservableCollection<Client> clients;

    [ObservableProperty]
    private Client selectedClient;

    [RelayCommand]
    private async Task CreateInspection()
    {
        await navigationService.GoToAsync($"{nameof(InspectionPage)}?id={SelectedClient.Id}");
    }

    [RelayCommand]
    private async Task CreateOrder()
    {
        await navigationService.GoToAsync($"{nameof(VisitDetailsPage)}?id={SelectedClient.Id}");
    }

    public VisitsViewModel(INavigationService navigationService)
    {
        var db = new WpmDbContext();
        Clients = new ObservableCollection<Client>(db.Clients);
        this.navigationService = navigationService;
    }
}