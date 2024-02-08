using WisdomPetMedicine.ViewModels;

namespace WisdomPetMedicine.Views;

public partial class OrdersPage : ContentPage
{
    public OrdersPage(OrdersViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}