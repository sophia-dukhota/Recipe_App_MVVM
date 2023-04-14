using System.Text.Json;
using Microsoft.Maui.Controls;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using _6002CEM_SophiaDukhota.Models;

namespace _6002CEM_SophiaDukhota.ViewModels;

//YOU MUST GIVE EDAMAN CREDIT
//https://developer.edamam.com/attribution

public class MainAppPageViewModel : BaseViewModel
{
    public Models.MainAppPageModel MainAppPageModel { get; set; }
    public ICommand GetRecipesCommand { get; set; }

    /*public string ingredient
    {
        get => responseModel.;
        set
        {
            MainAppPageModel.testResponse = value;
            OnPropertyChanged(nameof(TestReponse));
            (GetRecipesCommand as Command).ChangeCanExecute();
        }
    }*/

    public async Task<RecipesSearchModel> GetResponse() {
        //api keys
        const string appId = "8d3624e5";
        const string appKey = "2d8e6e78e5c2ea4d0050d41ddc1761a9";

        //create new HTTP client
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://api.edamam.com/api/recipes/v2");

        //get request
        var request = new HttpRequestMessage(HttpMethod.Get, "/search?q=chicken&app_id="+appId+"&app_key="+appKey);
        var response = await httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();

        var responseModel = JsonSerializer.Deserialize<RecipesSearchModel>(responseString);
        return responseModel;
    }

    public MainAppPageViewModel()
    {
        MainAppPageModel = new Models.MainAppPageModel();
        GetRecipesCommand = new Command(execute: async () => await GetResponse());
    }
}

/* protected override void OnAppearing()
{
    base.OnAppearing();
    NavigationPage.SetHasBackButton(this, false);
}*/