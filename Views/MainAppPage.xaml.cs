namespace _6002CEM_SophiaDukhota.Views;

public partial class MainAppPage : ContentPage
{
	public MainAppPage()
	{
		InitializeComponent();
		List<string> plsWork = new List<string> {
			"Xiao",
			"Venti",
			"Zhongli"
		};
		plsWorkView.ItemsSource = plsWork;
    }
}
