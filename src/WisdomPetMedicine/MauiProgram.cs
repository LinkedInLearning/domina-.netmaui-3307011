﻿using WisdomPetMedicine.Extensions;
using CommunityToolkit.Maui;

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
        }).UseMauiCommunityToolkit();
        builder.ConfigureWisdomPetMedicine();
        return builder.Build();
    }
}