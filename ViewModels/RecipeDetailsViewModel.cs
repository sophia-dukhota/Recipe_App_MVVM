using CommunityToolkit.Mvvm.ComponentModel;
using _6002CEM_SophiaDukhota.Models;
using System.Windows.Input;

namespace _6002CEM_SophiaDukhota.ViewModels;

[QueryProperty(nameof(Recipe), "Recipe")]
public partial class RecipeDetailsViewModel : BaseViewModel
{

    public ICommand GoToURL => new Command<string>(async (url) => await Launcher.OpenAsync(url));

    public RecipeDetailsViewModel()
	{

	}

    [ObservableProperty]
	Recipe recipe;
}