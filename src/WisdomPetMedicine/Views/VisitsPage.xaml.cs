using WisdomPetMedicine.ViewModels;

namespace WisdomPetMedicine.Views;

public partial class VisitsPage : ContentPage
{
	public VisitsPage(VisitsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        (BindingContext as VisitsViewModel).SelectedClient = null;
    }
}