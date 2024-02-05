using WisdomPetMedicine.ViewModels;

namespace WisdomPetMedicine.Views;

public partial class DashboardPage : ContentPage
{
	public DashboardPage(DashboardViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
		(BindingContext as DashboardViewModel).LoadDashboard();
    }
}