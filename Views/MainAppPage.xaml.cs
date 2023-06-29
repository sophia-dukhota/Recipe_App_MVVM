﻿using _6002CEM_SophiaDukhota.Models;
using _6002CEM_SophiaDukhota.ViewModels;
using _6002CEM_SophiaDukhota.Services;
//using Android.App.AppSearch;
//using AndroidX.Lifecycle;

using _6002CEM_SophiaDukhota.Auth0;

namespace _6002CEM_SophiaDukhota.Views;

public partial class MainAppPage : ContentPage
{
    //public bool isSearchVisible { get { return false; } }
    private readonly Auth0Client auth0Client;
    private string userID;
    MainAppPageViewModel mainAppPageViewModel;

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
            //searchBar.IsVisible = true;
            //LoginBtn.IsVisible = false;
            //LogoutBtn.IsVisible = true;
            //recipeCollectView.IsVisible = true;

            userID = loginResult.User.Identity.Name;
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

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        var logoutResult = await auth0Client.LogoutAsync();

        if (!logoutResult.IsError)
        {
            //HomeView.IsVisible = false;
            //LoginView.IsVisible = true;
            LoginBtn.IsVisible = true;
            LogoutBtn.IsVisible = false;
            searchBar.IsVisible = false;
            recipeCollectView.IsVisible = false;
        }
        else
        {
            await DisplayAlert("Error", logoutResult.ErrorDescription, "OK");
        }
    }
}
