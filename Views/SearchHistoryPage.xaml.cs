using _6002CEM_SophiaDukhota.Services;
using _6002CEM_SophiaDukhota.ViewModels;

namespace _6002CEM_SophiaDukhota.Views;

public partial class SearchHistoryPage : ContentPage
{
    RecipesDB database;
    public SearchHistoryViewModel searchHistoryViewModel;

    public SearchHistoryPage(SearchHistoryViewModel searchHistoryViewModel)
	{
		InitializeComponent();
        BindingContext = searchHistoryViewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //await searchHistoryViewModel.InitialiseDB();
        if (database is null)
            database = new RecipesDB();

        await database.Init();
        var items = await database.GetItemsAsync();
        var searchTerms = items.Select(item => item.searchTerm).ToList();

        listView.ItemsSource = searchTerms;
    }
}
