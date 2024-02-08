using CommunityToolkit.Mvvm.ComponentModel;
using Humanizer;
using System.Collections.ObjectModel;
using WisdomPetMedicine.DataAccess;

namespace WisdomPetMedicine.ViewModels;
public partial class OrdersViewModel : ViewModelBase
{
    [ObservableProperty]
    ObservableCollection<OrderViewModel> orders;

    [ObservableProperty]
    OrderViewModel selectedOrder;

    public OrdersViewModel(WpmOutDbContext wpmOutDbContext, WpmDbContext wpmDbContext)
    {
        var ordersData = wpmOutDbContext.Orders
                                        .Select(o => new { o.Id, o.OrderDate, o.ClientId, ItemsCount = o.Items.Count, o.Total })
                                        .ToList();

        var clientNames = wpmDbContext.Clients
                                    .Where(c => ordersData.Select(o => o.ClientId).Contains(c.Id))
                                    .ToDictionary(c => c.Id, c => c.Name);

        var orderViewModels = ordersData.Select(o => new OrderViewModel(
            o.Id,
            o.OrderDate.Humanize(culture: System.Globalization.CultureInfo.GetCultureInfo("es")),
            o.ClientId,
            clientNames.TryGetValue(o.ClientId, out var name) ? name : "N/D",
            o.ItemsCount,
            (double)o.Total
        )).ToList();

        orders = orderViewModels != null ? new ObservableCollection<OrderViewModel>(orderViewModels) : new();
    }
}
public record OrderViewModel(int OrderId,
                             string OrderDate,
                             int ClientId,
                             string ClientName,
                             int TotalProducts,
                             double TotalAmount);
