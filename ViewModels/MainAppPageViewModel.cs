using System.Text.Json;
using Microsoft.Maui.Controls;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

using _6002CEM_SophiaDukhota.Models;
using _6002CEM_SophiaDukhota.Services;
using _6002CEM_SophiaDukhota.Auth0;
//using Android.App.AppSearch;

namespace _6002CEM_SophiaDukhota.ViewModels;

[QueryProperty(nameof(Ingredient), "ingredient")]
public partial class MainAppPageViewModel : BaseViewModel
{
    public Models.MainAppPageModel MainAppPageModel { get; set; }
    public Models.RecipesSearchModel recipesSearchModel { get; set; }
    private readonly Auth0Client auth0Client;
    private readonly RecipesDB _recipesDB;

    public ObservableCollection<Recipe> recipes { get; } = new();
    public ObservableCollection<Recipe> searchResults { get; } = new();

    GetRecipesService getRecipesService;

    public Command OnLoginClickedCommand { get; }
    public Command OnLogoutClickedCommand { get; }
    public Command SearchCommand { get; }
    public Command ChangeThemeCommand { get; }
    public Command GetTappedRecipeInfoCommand { get; }

    private string userID;

    //MOVE THIS TO MODEL
    public bool isThemeBtnClicked = false;
    public string themeName = string.Empty;

    private MainAppPageModel mainAppPageModel = new MainAppPageModel();


    [ObservableProperty]
    Ingredient ingredient;

    public MainAppPageViewModel(GetRecipesService getRecipesService, RecipesDB recipesDB, Auth0Client client)
    {
        mainAppPageModel = new MainAppPageModel();
        recipesSearchModel = new Models.RecipesSearchModel();
        auth0Client = client;
        _recipesDB = recipesDB;

        this.getRecipesService = getRecipesService;

        OnLoginClickedCommand = new Command(async () => await OnLoginClicked());
        OnLogoutClickedCommand = new Command(async () => await OnLogoutClicked());
        SearchCommand = new Command<string>(async (string qparam) => { await GetSearchedRecipes(qparam); });
        ChangeThemeCommand = new Command(() => ChangeTheme());
        GetTappedRecipeInfoCommand = new Command<Recipe>(async (Recipe recipe) => await GetTappedRecipeInfo(recipe));
    }

    public bool IsAuthenticated
    {
        get => mainAppPageModel.isAuthenticated;
        set
        {
            mainAppPageModel.isAuthenticated = value;
            OnPropertyChanged(nameof(IsAuthenticated));
        }
    }

    public bool IsNotAuthenticated
    {
        get => mainAppPageModel.isNotAuthenticated;
        set
        {
            mainAppPageModel.isNotAuthenticated = value;
            OnPropertyChanged(nameof(IsNotAuthenticated));
        }
    }

    public string FilterByName
    {
        get => mainAppPageModel.filterByName;
        set
        {
            mainAppPageModel.filterByName = value;
            OnPropertyChanged(nameof(FilterByName));
        }
    }

    async Task GetSearchedRecipes(string qparam)
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            await _recipesDB.SaveItemAsync(new SearchHistoryItem { searchTerm = qparam });

            var getRecipes = await getRecipesService.SearchRecipes(qparam);

            if (searchResults.Count != 0)
            {
                searchResults.Clear();
            }

            foreach (var recipe in getRecipes)
                searchResults.Add(recipe);

            OnPropertyChanged(nameof(searchResults));
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

    public void ChangeTheme()
    {

        if (isThemeBtnClicked == false) { themeName = "Dark"; }
        if (isThemeBtnClicked == true) { themeName = "Light"; }
        isThemeBtnClicked = !isThemeBtnClicked;

        Preferences.Set("Theme", themeName);

        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            foreach (ResourceDictionary dicts in mergedDictionaries)
            {
                var getBackground = dicts.TryGetValue(themeName + "PageBackgroundColor", out var background);
                if (getBackground == true) { dicts["PageBackgroundColor"] = background; }

                var getPrimary = dicts.TryGetValue(themeName + "PrimaryColor", out var primary);
                if (getPrimary == true) { dicts["Primary"] = primary; }

                var getSecondary = dicts.TryGetValue(themeName + "SecondaryColor", out var secondary);
                if (getSecondary == true) { dicts["Secondary"] = secondary; }

                var getTertiary = dicts.TryGetValue(themeName + "TertiaryColor", out var tertiary);
                if (getTertiary == true) { dicts["Tertiary"] = tertiary; }

                var getPrimaryText = dicts.TryGetValue(themeName + "PrimaryTextColor", out var primaryText);
                if (getPrimaryText == true) { dicts["PrimaryTextColor"] = primaryText; }

                var getSecondaryText = dicts.TryGetValue(themeName + "SecondaryTextColor", out var secondaryText);
                if (getSecondaryText == true) { dicts["SecondaryTextColor"] = secondaryText; }

                var getTertiaryText = dicts.TryGetValue(themeName + "TertiaryTextColor", out var tertiaryText);
                if (getTertiaryText == true) { dicts["TertiaryTextColor"] = tertiaryText; }

                var getTransparent = dicts.TryGetValue(themeName + "TransparentColor", out var transparent);
                if (getTransparent == true) { dicts["TransparentColor"] = transparent; }
            }
        }
    }

    private async Task GetTappedRecipeInfo(Recipe recipe)
    {
        if (recipe == null)
            return;

        await Shell.Current.GoToAsync(("RecipeDetailsPage"), true, new Dictionary<string, object>
        {
            {"Recipe", recipe}
        });
    }

    private async Task OnLoginClicked()
    {
        var loginResult = await auth0Client.LoginAsync();

        if (!loginResult.IsError)
        {
            IsAuthenticated = true;
            IsNotAuthenticated = false;
            userID = loginResult.User.Identity.Name;
        }
    }

    private async Task OnLogoutClicked()
    {
        var logoutResult = await auth0Client.LogoutAsync();

        if (!logoutResult.IsError)
        {
            IsNotAuthenticated = true;
            IsAuthenticated = false;
        }
    }
}