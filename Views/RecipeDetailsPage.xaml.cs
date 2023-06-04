using System.Windows.Input;
using _6002CEM_SophiaDukhota.ViewModels;

namespace _6002CEM_SophiaDukhota.Views;

public partial class RecipeDetailsPage : ContentPage
{
    //public ICommand GoToURL => new Command<string>(async (url) => await Launcher.OpenAsync(url));

    public RecipeDetailsPage(RecipeDetailsViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}