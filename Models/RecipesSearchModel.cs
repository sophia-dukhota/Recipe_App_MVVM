using CommunityToolkit.Mvvm.ComponentModel;
using _6002CEM_SophiaDukhota.ViewModels;

namespace _6002CEM_SophiaDukhota.Models;

public class Hit
{
    public Recipe recipe { get; set; }
}


//[ObservableObject]
public partial class Recipe : ObservableObject
{
    public string url { get; set; }
    //public string uri { get; set; }
    public string image { get; set; }
    public string label { get; set; }
    public string externalId { get; set; }
}

public class RecipesSearchModel
{

    public string q { get; set; }
    public int from { get; set; }
    public int to { get; set; }

    public List<Hit> hits { get; set; }
}