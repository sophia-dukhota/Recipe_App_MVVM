using _6002CEM_SophiaDukhota.Models;
using _6002CEM_SophiaDukhota.ViewModels;
using _6002CEM_SophiaDukhota.Services;
//using Android.App.AppSearch;
//using AndroidX.Lifecycle;

using _6002CEM_SophiaDukhota.Auth0;

namespace _6002CEM_SophiaDukhota.Views;

public partial class MainAppPage : ContentPage
{
    MainAppPageViewModel mainAppPageViewModel;

    public MainAppPage(MainAppPageViewModel mainAppPageViewModel)
    {
        InitializeComponent();
        BindingContext = mainAppPageViewModel;
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
}
