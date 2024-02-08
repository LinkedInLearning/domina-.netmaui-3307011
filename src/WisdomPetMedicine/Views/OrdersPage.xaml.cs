using CommunityToolkit.Maui.Views;
using WisdomPetMedicine.ViewModels;

namespace WisdomPetMedicine.Views;

public partial class OrdersPage : ContentPage
{
    public OrdersPage(OrdersViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        var orderId = (BindingContext as OrdersViewModel).SelectedOrder.OrderId;
        await this.ShowPopupAsync(new BarcodePage(orderId, new Size(Width, Height)));
    }
}