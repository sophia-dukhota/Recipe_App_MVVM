using _6002CEM_SophiaDukhota.Database;

namespace _6002CEM_SophiaDukhota;

public partial class App : Application
{
	//public static Users users { get; private set; }

	public App()
	{
		InitializeComponent();

		//register routes
		Routing.RegisterRoute("SignUpPage", typeof(Views.SignUpPage));
		Routing.RegisterRoute("MainAppPage", typeof(Views.MainAppPage));
        //Routing.RegisterRoute(nameof(RecipeDetailsPage), typeof(Views.RecipeDetailsPage));
        Routing.RegisterRoute("RecipeDetailsPage", typeof(Views.RecipeDetailsPage));

        MainPage = new AppShell();
	}
}

