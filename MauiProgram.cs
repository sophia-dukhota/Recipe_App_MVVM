using Microsoft.Extensions.Logging;
using _6002CEM_SophiaDukhota.ViewModels;
using _6002CEM_SophiaDukhota.Views;
using _6002CEM_SophiaDukhota.Services;

using _6002CEM_SophiaDukhota.Auth0;

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

        builder.Services.AddSingleton<RecipesDB>();

        builder.Services.AddTransient<GetRecipesService>();

        builder.Services.AddTransient<MainAppPageViewModel>();
		builder.Services.AddTransient<MainAppPage>();

		builder.Services.AddTransient<RecipeDetailsViewModel>();
		builder.Services.AddTransient<RecipeDetailsPage>();

		builder.Services.AddTransient<SearchHistoryViewModel>();
		builder.Services.AddTransient<SearchHistoryPage>();


		
#if DEBUG
		builder.Logging.AddDebug();
#endif
        /*string dbPath = Path.Combine(FileSystem.AppDataDirectory, "UserDB.db");
		builder.Services.AddSingleton(s =>
		ActivatorUtilities.CreateInstance<Users>(s, dbPath));8*/

        //builder.Services.AddSingleton<MainAppPage>();

        builder.Services.AddSingleton(new Auth0Client(new()
        {
            Domain = "dev-jmopak2jnbykqjem.us.auth0.com",
            ClientId = "u36fr4mRIrgK5Tu43bsXQRviqXrs57dh",
            Scope = "openid profile",
            RedirectUri = "myapp://callback"
        }));

        return builder.Build();
	}
}