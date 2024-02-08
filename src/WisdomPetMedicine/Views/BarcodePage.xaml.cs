using CommunityToolkit.Maui.Views;

namespace WisdomPetMedicine.Views;

public partial class BarcodePage : Popup
{
	public BarcodePage(int orderId, Size size)
	{
		InitializeComponent();
        Size = size;
        qrCode.Value = $"https://wisdompetmed.com?orderid={orderId}";
    }
}