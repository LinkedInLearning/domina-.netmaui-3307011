using WisdomPetMedicine.Extensions;
using CommunityToolkit.Maui;
using ZXing.Net.Maui.Controls;

namespace WisdomPetMedicine;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons");
        }).UseMauiCommunityToolkit()
          .UseBarcodeReader();
        builder.ConfigureWisdomPetMedicine();
        return builder.Build();
    }
}