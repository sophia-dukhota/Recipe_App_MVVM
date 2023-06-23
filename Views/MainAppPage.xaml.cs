using _6002CEM_SophiaDukhota.Models;
using _6002CEM_SophiaDukhota.ViewModels;
//using Android.App.AppSearch;
//using AndroidX.Lifecycle;

using _6002CEM_SophiaDukhota.Auth0;

namespace _6002CEM_SophiaDukhota.Views;

public partial class MainAppPage : ContentPage
{
    //public bool isSearchVisible { get { return false; } }
    private readonly Auth0Client auth0Client;

    public MainAppPage(MainAppPageViewModel mainAppPageViewModel, Auth0Client client)
    {
        InitializeComponent();
        BindingContext = mainAppPageViewModel;
        auth0Client = client;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var loginResult = await auth0Client.LoginAsync();

        if (!loginResult.IsError)
        {
            //LoginView.IsVisible = false;
            //HomeView.IsVisible = true;
            searchBar.IsVisible = true;
            LoginBtn.IsVisible = false;

        }
        else
        {
            await DisplayAlert("Error", loginResult.ErrorDescription, "OK");
        }
    }

    void FilterByName_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;
    }

    private async void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        var recipe = ((VisualElement)sender).BindingContext as Recipe;

        if (recipe == null)
            return;

        await Shell.Current.GoToAsync(("RecipeDetailsPage"), true, new Dictionary<string, object>
        {
            {"Recipe", recipe}
        });
    }

    void CheckBox_CheckedChanged(System.Object sender, Microsoft.Maui.Controls.CheckedChangedEventArgs e)
    {
        string themeName = string.Empty;
        if (e.Value == true) { themeName = "Dark"; }
        if (e.Value == false) { themeName = "Light"; }

        Preferences.Set("Theme", themeName);

        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            foreach (ResourceDictionary dicts in mergedDictionaries)
            {
                var getBackground = dicts.TryGetValue(themeName + "PageBackgroundColor", out var background);
                if (getBackground == true) { dicts["PageBackgroundColor"] = background; }

                //var getNavigationBarCo

                var getPrimary = dicts.TryGetValue(themeName + "PrimaryColor", out var primary);
                if (getPrimary == true) { dicts["Primary"] = primary; }

                var getSecondary = dicts.TryGetValue(themeName + "SecondaryColor", out var secondary);
                if (getSecondary == true) { dicts["Secondary"] = secondary; }

                //var primaryTextFound = dicts.TryGetValue(themeName + "PrimaryTextColor", out var primaryText);
                //if (primaryTextFound) { dicts[""]}
            }
        }
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        var logoutResult = await auth0Client.LogoutAsync();

        if (!logoutResult.IsError)
        {
            //HomeView.IsVisible = false;
            //LoginView.IsVisible = true;
        }
        else
        {
            await DisplayAlert("Error", logoutResult.ErrorDescription, "OK");
        }
    }
}

