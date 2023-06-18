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
        if(e.Value == true) { themeName = "Dark"; }
        if(e.Value == false) { themeName = "Light"; }

        Preferences.Set("Theme", themeName);

        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if(mergedDictionaries != null)
        {
            foreach(ResourceDictionary dicts in mergedDictionaries)
            {
                var primaryFound = dicts.TryGetValue(themeName + "PrimaryColor", out var primary);
                if(primaryFound) { dicts["Primary"] = primary; }

                var secondaryFound = dicts.TryGetValue(themeName + "SecondaryColor", out var secondary);
                if (primaryFound) { dicts["Secondary"] = secondary; }
            } 
        }
    }
}
