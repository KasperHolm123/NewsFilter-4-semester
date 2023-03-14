using Microsoft.Extensions.Logging;
using NewsFilter_4_semester.Pages;
using NewsFilter_4_semester.Services;
using NewsFilter_4_semester.ViewModels;

namespace NewsFilter_4_semester;

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
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddSingleton<SettingsPage>();
        builder.Services.AddSingleton<SettingsPageViewModel>();

		builder.Services.AddSingleton<FilterService>();

        return builder.Build();
	}
}
