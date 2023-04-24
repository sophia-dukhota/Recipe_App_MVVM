using System.Text.Json;
using Microsoft.Maui.Controls;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using _6002CEM_SophiaDukhota.Models;

namespace _6002CEM_SophiaDukhota.ViewModels;

//YOU MUST GIVE EDAMAN CREDIT
//https://developer.edamam.com/attribution

public partial class MainAppPageViewModel : BaseViewModel
{
    //public Models.MainAppPageModel MainAppPageModel { get; set; }
    public ICommand GetRecipesCommand { get; set; }
    public Models.RecipesSearchModel RecipesSearchModel { get; set; }
   

    public string Label
    {
        get => RecipesSearchModel.hits[0].recipe.label;
        set
        {
            //var hits = RecipesSearchModel.hits[0].recipe.label = value;
            RecipesSearchModel.hits[0].recipe.label = value;
            OnPropertyChanged(nameof(Label));
            (GetRecipesCommand as Command).ChangeCanExecute();
        }
    }

    public async Task<RecipesSearchModel> GetResponse() {
        //api keys
        const string appId = "8d3624e5";
        const string appKey = "2d8e6e78e5c2ea4d0050d41ddc1761a9";

        //create new HTTP client
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://api.edamam.com/api/recipes/v2");

        //get request
        var request = new HttpRequestMessage(HttpMethod.Get, "/search?q=chicken&app_id=" + appId + "&app_key=" + appKey);
        var response = await httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();

        //var responseModel = JsonSerializer.Deserialize<RecipesSearchModel>(responseString);
        RecipesSearchModel = JsonSerializer.Deserialize<RecipesSearchModel>(responseString);
        //return responseModel;
        return RecipesSearchModel;
    }

    public MainAppPageViewModel()
    {
        //MainAppPageModel = new Models.MainAppPageModel();
        RecipesSearchModel = new Models.RecipesSearchModel();
        GetRecipesCommand = new Command(execute: async () => await GetResponse());
    }
}
/* protected override void OnAppearing()
{
    base.OnAppearing();
    NavigationPage.SetHasBackButton(this, false);
}*/