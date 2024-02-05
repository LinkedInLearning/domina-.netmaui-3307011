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
    double totalAmount;

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
        Visits = outDbContext.Sales.Select(s => s.ClientId)
                                   .Distinct()
                                   .Count();
        
        TotalAmount = outDbContext.Sales.Sum(s => s.Quantity * (double)s.Price);
        TotalProducts = outDbContext.Sales.Sum(s => s.Quantity);
    }
}