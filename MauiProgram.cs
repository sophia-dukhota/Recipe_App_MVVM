using Microsoft.Extensions.Logging;
using _6002CEM_SophiaDukhota.Database;
using _6002CEM_SophiaDukhota.ViewModels;
using _6002CEM_SophiaDukhota.Views;
using _6002CEM_SophiaDukhota.Services;

namespace _6002CEM_SophiaDukhota;

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
		builder.Services.AddTransient<GetRecipesService>();
		builder.Services.AddTransient<MainAppPageViewModel>();
		builder.Services.AddTransient<MainAppPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif
		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "UserDB.db");
		builder.Services.AddSingleton(s =>
		ActivatorUtilities.CreateInstance<Users>(s, dbPath));

		return builder.Build();
	}
}

