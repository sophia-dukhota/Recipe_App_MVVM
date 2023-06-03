using CommunityToolkit.Mvvm.ComponentModel;
using _6002CEM_SophiaDukhota.Models;

namespace _6002CEM_SophiaDukhota.ViewModels;

[QueryProperty(nameof(Recipe), "Recipe")]
public partial class RecipeDetailsViewModel : BaseViewModel
{
	public RecipeDetailsViewModel()
	{

	}

    [ObservableProperty]
	Recipe recipe;
}