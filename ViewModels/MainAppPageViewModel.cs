using System.Text.Json;
using Microsoft.Maui.Controls;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

using _6002CEM_SophiaDukhota.Models;
using _6002CEM_SophiaDukhota.Services;
using _6002CEM_SophiaDukhota.Auth0;
//using Android.App.AppSearch;

namespace _6002CEM_SophiaDukhota.ViewModels;

//YOU MUST GIVE EDAMAN CREDIT
//https://developer.edamam.com/attribution

public class MainAppPageViewModel : BaseViewModel
{
    public Models.MainAppPageModel MainAppPageModel { get; set; }
    public Models.RecipesSearchModel recipesSearchModel { get; set; }
    private readonly Auth0Client auth0Client;
    private readonly RecipesDB _recipesDB;

    public ObservableCollection<Recipe> recipes { get; } = new();
    public ObservableCollection<Recipe> searchResults { get; } = new();

    GetRecipesService getRecipesService;

    public Command SearchByNameCommand { get; }
    public Command SearchCommand { get; }
    public Command LoginClicked { get; }
    public Command ChangeThemeCommand { get; }

    //move this to model 
    public bool isThemeBtnClicked = false;
    public string themeName = string.Empty;

    public MainAppPageViewModel(GetRecipesService getRecipesService, RecipesDB recipesDB)
    {
        recipesSearchModel = new Models.RecipesSearchModel();
        this.getRecipesService = getRecipesService;

        SearchCommand = new Command<string>(async (string qparam) => { await GetSearchedRecipes(qparam); });
        ChangeThemeCommand = new Command(() => ChangeTheme());
    }

    public string FilterByName
    {
        get => MainAppPageModel.filterByName;
        set
        {
            MainAppPageModel.filterByName = value;
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
        if (isThemeBtnClicked == true) { themeName = "Light";}
        isThemeBtnClicked = !isThemeBtnClicked;

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

                //var primaryTextFound = dicts.TryGetValue(themeName + "PrimaryTextColor", out var primaryText);
                //if (primaryTextFound) { dicts[""]}
            }
        }
    }
}