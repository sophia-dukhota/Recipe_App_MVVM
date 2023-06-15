using _6002CEM_SophiaDukhota.Database;

namespace _6002CEM_SophiaDukhota;

public partial class App : Application
{
	private static UsersDB usersDB;

	public static UsersDB UsersDB
	{
		get
		{
			if (usersDB == null)
			{
				usersDB = new UsersDB(Path.Combine(Environment.GetFolderPath(
					Environment.SpecialFolder.LocalApplicationData), "Users.db3"));
			}

			return usersDB;
		}
	}

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

