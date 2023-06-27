using _6002CEM_SophiaDukhota.Services;

namespace _6002CEM_SophiaDukhota.Views;

public partial class SearchHistoryPage : ContentPage
{
    RecipesDB database;

    public SearchHistoryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //listView.ItemsSource = await database.GetItemsAsync();
        if (database is null)
            database = new RecipesDB();

        await database.Init();
        var items = await database.GetItemsAsync();
        var searchTerms = items.Select(item => item.searchTerm).ToList();

        listView.ItemsSource = searchTerms;

        //listView.ItemsSource = await database.GetItemsAsync();
    }
}
