using Microsoft.Extensions.Logging;
using EdGame.ViewModels;
using EdGame.Views;
namespace EdGame;

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
 		builder.Services.AddTransient<GamePage>();
        builder.Services.AddTransient<GatoViewModel>();

		return builder.Build();
	}
}
