using CommunityToolkit.Mvvm.ComponentModel;
using WisdomPetMedicine.DataAccess;

namespace WisdomPetMedicine.ViewModels;
public partial class DashboardViewModel : ViewModelBase
{
    private readonly WpmOutDbContext outDbContext;

    [ObservableProperty]
    int visits;

    [ObservableProperty]
    int clients;

    [ObservableProperty]
    decimal totalAmount;

    [ObservableProperty]
    int totalProducts;

    public DashboardViewModel(WpmOutDbContext wpmOutDbContext)
    {
        this.outDbContext = wpmOutDbContext;
        var db = new WpmDbContext();
        Clients = db.Clients.Count();
    }

    public void LoadDashboard()
    {
        Visits = outDbContext.Sales
            .ToList()
            .DistinctBy(s => s.ClientId)
            .ToList()
            .Count();
        
        TotalAmount = outDbContext.Sales.ToList().Sum(s => s.Quantity * s.Price);
        TotalProducts = outDbContext.Sales.Sum(s => s.Quantity);
    }
}