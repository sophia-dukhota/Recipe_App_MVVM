namespace _6002CEM_SophiaDukhota.Models;

public class Hit
{
    public Recipe recipe { get; set; }
}

public class Recipe
{
    public string uri { get; set; }
    public string label { get; set; }
    public string externalId { get; set; }
}

public class RecipesSearchModel
{

    public string q { get; set; }
    public int from { get; set; }
    public int to { get; set; }

    public IList<Hit> hits { get; set; }
}