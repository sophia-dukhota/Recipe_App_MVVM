using Microsoft.Extensions.Logging;
using _6002CEM_SophiaDukhota.Database;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif
		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "UserDB.db");
		builder.Services.AddSingleton(s =>
		ActivatorUtilities.CreateInstance<Users>(s, dbPath));

		return builder.Build();
	}
}

