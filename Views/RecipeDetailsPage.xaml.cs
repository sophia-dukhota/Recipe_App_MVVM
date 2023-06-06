using System.Windows.Input;
using _6002CEM_SophiaDukhota.ViewModels;

namespace _6002CEM_SophiaDukhota.Views;

public partial class RecipeDetailsPage : ContentPage
{
    public RecipeDetailsPage(RecipeDetailsViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();

		List<string> test = new List<string>() {
			"test1",
			"fuckin work",
			"pls"
		};

		//TestListView.ItemsSource = test;

    }
}