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
 		builder.Services.AddSingleton<GamePage>();
        builder.Services.AddSingleton<GatoViewModel>();

		return builder.Build();
	}
}
