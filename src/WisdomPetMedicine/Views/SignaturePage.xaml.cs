using WisdomPetMedicine.ViewModels;

namespace WisdomPetMedicine.Views;

public partial class SignaturePage : ContentPage
{
	public SignaturePage(SignatureViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}