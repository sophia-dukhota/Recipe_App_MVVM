using System.Text.Json;
using Microsoft.Maui.Controls;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using _6002CEM_SophiaDukhota.Models;
using _6002CEM_SophiaDukhota.Services;
//using Android.App.AppSearch;

namespace _6002CEM_SophiaDukhota.ViewModels;

//YOU MUST GIVE EDAMAN CREDIT
//https://developer.edamam.com/attribution

public class MainAppPageViewModel : BaseViewModel
{
    public Models.MainAppPageModel MainAppPageModel { get; set; }
    public Models.RecipesSearchModel recipesSearchModel { get; set; }

    public ObservableCollection<Recipe> recipes { get; } = new();
    public ObservableCollection<Recipe> searchResults { get; } = new();

    GetRecipesService getRecipesService;

    public Command GetRecipesCommand { get; }
    public Command SearchByNameCommand { get; }
    public Command SearchCommand { get; }

    public MainAppPageViewModel(GetRecipesService getRecipesService)
    {
        recipesSearchModel = new Models.RecipesSearchModel();
        this.getRecipesService = getRecipesService;
        //HARDCODED Q
        GetRecipesCommand = new Command(async () => await GetRecipesAsync());
        //SEARCH Q
        //SearchByNameCommand = new Command(async () => await GetSearchedRecipes());

        /* public ICommand PerformSearch => new Command<string>((string query) =>
         {
             SearchResults = DataService.GetSearchResults(query);
         });*/

        SearchCommand = new Command<string>(async (string qparam) => { await GetSearchedRecipes(qparam); });
}

    public string FilterByName
    {
        get => MainAppPageModel.filterByName;
        set
        {
            MainAppPageModel.filterByName = value;
            OnPropertyChanged(nameof(FilterByName));
            //updates canExecute (ShouldCheckUserCreds)
            //(CheckUserCredsCommand as Command).ChangeCanExecute();
        }
    }

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

    async Task GetSearchedRecipes(string qparam)
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            //between here
            var getRecipes = await getRecipesService.SearchRecipes(qparam);
            
            //and here
            if (searchResults.Count != 0)
            {
                searchResults.Clear();
            }

            foreach (var recipe in getRecipes)
                searchResults.Add(recipe);
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