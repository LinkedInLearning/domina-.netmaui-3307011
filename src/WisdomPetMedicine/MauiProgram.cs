using WisdomPetMedicine.Extensions;
using CommunityToolkit.Maui;
using ZXing.Net.Maui.Controls;
using CommunityToolkit.Maui.Maps;
using Microsoft.Extensions.Configuration;

namespace WisdomPetMedicine;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.Configuration.AddEnvironmentVariables();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons");
        }).UseMauiCommunityToolkit()
          .UseBarcodeReader()
          .UseMauiMaps()
          .UseMauiCommunityToolkitMaps(builder.Configuration["BING_API_KEY"]);
        builder.ConfigureWisdomPetMedicine();
        return builder.Build();
    }
}