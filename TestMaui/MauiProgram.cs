using Microsoft.Extensions.Logging;

namespace TestMaui;

using AppActions.Icons.Maui;
using TestMaui.Pages;
using TestMaui.ViewModel;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Free-Solid-900.otf", "FAS");
                fonts.AddFont("Free-Regular-400.otf", "FAR");
                fonts.AddFont("BrandsRegular-400.otf", "FAB");
            })
             .ConfigureEssentials(essentials =>
             {
                 essentials
                     .UseAppActionIcons() // Add this line
                     .AddAppAction("home_sc", "Home", icon: AppActionIcon.Home)
                     .OnAppAction(App.HandleAppActions);
             }); ;

		builder.Services.AddSingleton<MainPage>();

        builder.Services.AddTransient<GamePage>();
        builder.Services.AddTransient<GameViewModel>();





#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}


}
