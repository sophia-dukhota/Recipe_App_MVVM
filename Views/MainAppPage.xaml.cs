using _6002CEM_SophiaDukhota.Models;
using _6002CEM_SophiaDukhota.ViewModels;
//using AndroidX.Lifecycle;

namespace _6002CEM_SophiaDukhota.Views;


public partial class MainAppPage : ContentPage
{
    public MainAppPage() { }
    //RecipesSearchModel recipesSearchModel { get; set; }
    //MainAppPageViewModel mainAppPageViewModel;
    public MainAppPage(MainAppPageViewModel mainAppPageViewModel)
    //public MainAppPage()
	{
		InitializeComponent();
        BindingContext = mainAppPageViewModel;
        //mainAppPageViewModel = new MainAppPageViewModel();
        //recipeSearchView.BindingContext = mainAppPageViewModel;
        //this.BindingContext = new MainAppPageViewModel();
        //BindingContext = mainAppPageViewModel = new MainAppPageViewModel();

        /*List<RecipesSearchModel> recipesSearchModel = new List<RecipesSearchModel>
        {
            new RecipesSearchModel { q="chicken", from=0, to=10, hits = new List<Hit>
            { new Hit{ recipe = new Recipe { uri = "someUri", label = "Chicken parm", externalId = "externalId"}},
                new Hit { recipe = new Recipe { uri = "another URI", label = "Crepes", externalId = "some stupid ID"} } } }
        };*/

        //recipeSearchView.ItemsSource = recipesSearchModel[0].hits;
        //recipeSearchView.ItemsSource = recipesSearchModel.hits;
        //recipeSearchView.ItemsSource = mainAppPageViewModel.RecipesSearchModel.hits;
    }
}
