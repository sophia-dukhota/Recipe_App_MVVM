namespace _6002CEM_SophiaDukhota;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		Routing.RegisterRoute("SignUpPage", typeof(Views.SignUpPage));
		Routing.RegisterRoute("MainAppPage", typeof(Views.MainAppPage));

		MainPage = new AppShell();
	}
}

