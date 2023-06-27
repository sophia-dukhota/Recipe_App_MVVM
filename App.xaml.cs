

namespace _6002CEM_SophiaDukhota;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//register routes
		//Routing.RegisterRoute("SignUpPage", typeof(Views.SignUpPage));
		Routing.RegisterRoute("MainAppPage", typeof(Views.MainAppPage));
        //Routing.RegisterRoute(nameof(RecipeDetailsPage), typeof(Views.RecipeDetailsPage));
        Routing.RegisterRoute("RecipeDetailsPage", typeof(Views.RecipeDetailsPage));
		Routing.RegisterRoute("SearchHistoryPage", typeof(Views.SearchHistoryPage));

        MainPage = new AppShell();
	}
}