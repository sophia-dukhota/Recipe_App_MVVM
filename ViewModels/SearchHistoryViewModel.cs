using _6002CEM_SophiaDukhota.Services;
using _6002CEM_SophiaDukhota.Models;
using _6002CEM_SophiaDukhota.ViewModels;
using _6002CEM_SophiaDukhota.Auth0;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
//using Android.App.AppSearch;

namespace _6002CEM_SophiaDukhota.ViewModels;

public class SearchHistoryViewModel : BaseViewModel
{
    //private readonly RecipesDB _recipesDB;
    private RecipesDB _recipesDB;

    public MainAppPageViewModel mainAppPageViewModel;
    public SearchHistoryItem searchHistoryItem;

    public Command GetSearchedHistoryCommand { get; }
    public Command DeleteAllHistoryCommand { get; }
    public Command SearchInMainPageCommand { get; }

    public ObservableCollection<string> searchTerms { get; } = new();

    public SearchHistoryViewModel(RecipesDB recipesDB)
	{
        searchHistoryItem = new SearchHistoryItem();

        _recipesDB = recipesDB;
        

        GetSearchedHistoryCommand = new Command<string>(async
            (string qparam) => { await GetSearchedHistory(qparam); });

        DeleteAllHistoryCommand = new Command(async () => await DeleteAllHistory());
        //SearchInMainPageCommand = new Command(async () => await SearchInMainPage());

    }

    private async Task GetSearchedHistory(string qparam)
	{
		try
		{
            var searchTerms = await _recipesDB.GetSearchedItems(qparam);
        }

        catch (Exception ex)
		{
            Console.WriteLine("Exception caught" + ex.Message);
        }
	}

    private async Task DeleteAllHistory()
    {
        await _recipesDB.DeleteDatabase();
    }

    public async Task InitialiseDB()
    {
        if (_recipesDB is null)
            _recipesDB = new RecipesDB();

        await _recipesDB.Init();
        var items = await _recipesDB.GetItemsAsync();
        var searchTerms = items.Select(item => item.searchTerm).ToList();
        OnPropertyChanged(nameof(searchTerms));

        //listView.ItemsSource = searchTerms;
    }

    /*private async Task SearchInMainPage()
    {
        Ingredient ingredient = new Ingredient()
        {
            ingredient = "tofu"
        };

        if (ingredient == null)
            return;

        await Shell.Current.GoToAsync(("MainAppPage"), true, new Dictionary<string, object>
        {
            {"Ingredient", ingredient}
        });
    }*/
}
