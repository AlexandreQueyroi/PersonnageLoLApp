// using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
namespace PersonnageLoLApp;

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
		builder.UseMauiApp<App>().UseMauiCommunityToolkit();

#if DEBUG
		// builder.Logging.AddDebug();
		return builder.Build();
#endif

		return builder.Build();
	}
}
