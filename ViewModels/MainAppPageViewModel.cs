using System.Text.Json;
using Microsoft.Maui.Controls;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using _6002CEM_SophiaDukhota.Models;
using _6002CEM_SophiaDukhota.Services;

namespace _6002CEM_SophiaDukhota.ViewModels;

//YOU MUST GIVE EDAMAN CREDIT
//https://developer.edamam.com/attribution

public class MainAppPageViewModel : BaseViewModel
{
    //public Models.MainAppPageModel MainAppPageModel { get; set; }
    //public ICommand GetRecipesCommand { get; set; }
    public Command GetRecipesCommand { get; }
    public Models.RecipesSearchModel recipesSearchModel { get; set; }

    public ObservableCollection<Recipe> recipes { get; } = new();
    GetRecipesService getRecipesService;

   /* public string Label
    {
        get => recipesSearchModel.hits[0].recipe.label;
        set
        {
            //var hits = RecipesSearchModel.hits[0].recipe.label = value;
            recipesSearchModel.hits[0].recipe.label = value;
            OnPropertyChanged(nameof(Label));
            (GetRecipesCommand as Command).ChangeCanExecute();
        }
    }*/

    /*
    public async Task<RecipesSearchModel> GetResponse() {
        //api keys
        const string appId = "8d3624e5";
        const string appKey = "2d8e6e78e5c2ea4d0050d41ddc1761a9";

        //create new HTTP client
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://api.edamam.com/api/recipes/v2");

        //get request
        var request = new HttpRequestMessage(HttpMethod.Get, "/search?q=chicken&app_id=" + appId + "&app_key=" + appKey);
        var response = await httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();

        //var responseModel = JsonSerializer.Deserialize<RecipesSearchModel>(responseString);
        recipesSearchModel = JsonSerializer.Deserialize<RecipesSearchModel>(responseString);
        //return responseModel;
        //_recipesSearchModel.Add(recipesSearchModel);
        return recipesSearchModel;
    }*/

    public MainAppPageViewModel(GetRecipesService getRecipesService)
    {
        //MainAppPageModel = new Models.MainAppPageModel();
        recipesSearchModel = new Models.RecipesSearchModel();
        //GetRecipesCommand = new Command(execute: async () => await GetResponse());
        this.getRecipesService = getRecipesService;
        GetRecipesCommand = new Command(async () => await GetRecipesAsync());
    }


    //code modified from https://www.youtube.com/watch?v=XmdBXuNPShs&t=2434s
    async Task GetRecipesAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            //between here
            var getRecipes = await getRecipesService.GetResponse();
            
            //and here
            if (recipes.Count != 0)
            {
                recipes.Clear();
            }

            foreach (var recipe in getRecipes)
                recipes.Add(recipe);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught" + ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
/* protected override void OnAppearing()
{
    base.OnAppearing();
    NavigationPage.SetHasBackButton(this, false);
}*/