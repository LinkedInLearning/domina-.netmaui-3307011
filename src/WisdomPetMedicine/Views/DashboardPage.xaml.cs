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
		var vm = BindingContext as DashboardViewModel;
		vm.LoadDashboard();

        VisualStateManager.GoToState(layout, vm.Clients == vm.Visits ? "Completed" : "InProgress");
    }
}