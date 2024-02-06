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
        Visits = outDbContext.Orders.Select(s => s.ClientId)
                                   .Distinct()
                                   .Count();

        TotalAmount = outDbContext.Orders.Sum(s => (double)s.Total);
        TotalProducts = outDbContext.Orders.Sum(s => s.Items.Count);
    }
}