using _6002CEM_SophiaDukhota.Models;

namespace _6002CEM_SophiaDukhota.Views;

public partial class MainAppPage : ContentPage
{
	public MainAppPage()
	{
		InitializeComponent();
		List<RecipesSearchModel> recipesSearchModel = new List<RecipesSearchModel>
		{
			new RecipesSearchModel { q="chicken", from=0, to=10, hits = new List<Hit>
			{ new Hit{ recipe = new Recipe { uri = "someUri", label = "Chicken parm", externalId = "externalId"}},
				new Hit { recipe = new Recipe { uri = "another URI", label = "Crepes", externalId = "some stupid ID"} } } },

            /* new RecipesSearchModel { q="beef", from=0, to=10, hits = new List<Hit>
            { new Hit{ recipe = new Recipe { uri = "someUri2", label = "label2", externalId = "externalId2"} } } }*/

        };

		//recipeSearchView.ItemsSource = recipesSearchModel;
        recipeSearchView.ItemsSource = recipesSearchModel[0].hits;
    }
}
