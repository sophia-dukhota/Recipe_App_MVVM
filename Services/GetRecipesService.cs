using System.Net.Http.Json;
using System.Text.Json;
using _6002CEM_SophiaDukhota.Models;

namespace _6002CEM_SophiaDukhota.Services;

public class GetRecipesService 
{
	List<Recipe> recipesList = new();
	HttpClient httpClient;

    //api keys
    const string appId = "8d3624e5";
    const string appKey = "2d8e6e78e5c2ea4d0050d41ddc1761a9";

    public GetRecipesService()
	{
		this.httpClient = new HttpClient();
	
	}

    public async Task<List<Recipe>> GetResponse()
    {
        if (recipesList.Count > 0)
        {
            return recipesList;
        }

        httpClient.BaseAddress = new Uri("https://api.edamam.com/api/recipes/v2");
        //httpClient.BaseAddress = new Uri("https://api.edamam.com");

        //get request
        //var request = new HttpRequestMessage(HttpMethod.Get, "/api/food-database/v2/parser" + appId + "&app_key=" + appKey);

        var request = new HttpRequestMessage(HttpMethod.Get, "/search?q=chicken&app_id=" + appId + "&app_key=" + appKey);
        var response = await httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var hitsList = (await response.Content.ReadFromJsonAsync<RecipesSearchModel>()).hits;
            recipesList = new List<Recipe>();
            foreach (var hit in hitsList)
                recipesList.Add(hit.recipe);
            Console.WriteLine(this.recipesList);
        }

        return recipesList;
    }

    public async Task<List<Recipe>> SearchRecipes(string qparam)
    {
        if (recipesList.Count > 0)
        {
            recipesList.Clear();
            //return recipesList;
        }

        if (httpClient.BaseAddress == null)
        {
            httpClient.BaseAddress = new Uri("https://api.edamam.com/api/recipes/v2");
        }

        //httpClient.BaseAddress = new Uri("https://api.edamam.com/api/recipes/v2");


        //get request
        var request = new HttpRequestMessage(HttpMethod.Get,
            "/search?q=" + qparam + "&app_id=" + appId + "&app_key=" + appKey);
        var response = await httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var hitsList = (await response.Content.ReadFromJsonAsync<RecipesSearchModel>()).hits;
            recipesList = new List<Recipe>();
            foreach (var hit in hitsList)
                recipesList.Add(hit.recipe);
            Console.WriteLine(this.recipesList);
        }

        return recipesList;
    }
}