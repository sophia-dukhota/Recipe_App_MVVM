using _6002CEM_SophiaDukhota.Models;
using _6002CEM_SophiaDukhota.ViewModels;
//using Android.App.AppSearch;
//using AndroidX.Lifecycle;

namespace _6002CEM_SophiaDukhota.Views;


public partial class MainAppPage : ContentPage
{
    public MainAppPage(MainAppPageViewModel mainAppPageViewModel)
	{
		InitializeComponent();
        BindingContext = mainAppPageViewModel;
    }

    void FilterByName_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;
        //searchResults.ItemsSource = DataService.GetSearchResults(searchBar.Text);
    }
}
