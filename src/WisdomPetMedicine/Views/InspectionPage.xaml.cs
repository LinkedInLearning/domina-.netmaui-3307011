using WisdomPetMedicine.ViewModels;

namespace WisdomPetMedicine.Views;

public partial class InspectionPage : ContentPage
{
	public InspectionPage(InspectionViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}