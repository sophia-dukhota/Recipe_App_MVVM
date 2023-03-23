using System.Text.Json;
using Microsoft.Maui.Controls;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _6002CEM_SophiaDukhota.ViewModels;

//YOU MUST GIVE EDAMAN CREDIT
//https://developer.edamam.com/attribution

public class MainAppPageViewModel : BaseViewModel
{
    public Models.MainAppPageModel MainAppPageModel { get; set; }

    public ICommand GetRecipesCommand { get; set; }

    //private const string appId = "8d3624e5";
    //private const string appKey = "2d8e6e78e5c2ea4d0050d41ddc1761a9";

    public string TestReponse
    {
        get => MainAppPageModel.testResponse;
        set
        {
            MainAppPageModel.testResponse = value;
            OnPropertyChanged(nameof(TestReponse));
            (GetRecipesCommand as Command).ChangeCanExecute();
        }
    }

    public MainAppPageViewModel()
    {
        MainAppPageModel = new Models.MainAppPageModel();
        GetRecipesCommand = new Command(execute: async () => await GetResponse());

    }

    public async Task GetResponse() {

        const string appId = "8d3624e5";
        const string appKey = "2d8e6e78e5c2ea4d0050d41ddc1761a9";

        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://api.edamam.com/api/recipes/v2");

        var request = new HttpRequestMessage(HttpMethod.Get, "/search?q=chicken&app_id="+appId+"&app_key="+appKey);
        var response = await httpClient.SendAsync(request);
        TestReponse = await response.Content.ReadAsStringAsync();      
    }
}

/* protected override void OnAppearing()
{
    base.OnAppearing();
    NavigationPage.SetHasBackButton(this, false);
}*/