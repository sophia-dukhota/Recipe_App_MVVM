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
    public string image { get; set; }
    public string label { get; set; }
    public string externalId { get; set; }

    public float calories { get; set; }
    public List<string> ingredientLines { get; set; }
    public List<string> cautions { get; set; }
    public List<string> cuisineType { get; set; }
    public List<string> mealType { get; set; }
    public float yield { get; set; }
    public float glycemicIndex { get; set; }

}

public class RecipesSearchModel
{

    public string q { get; set; }
    public int from { get; set; }
    public int to { get; set; }

    public List<Hit> hits { get; set; }
}