namespace _6002CEM_SophiaDukhota.Models;

public class MainAppPageModel
{
    public string filterByName = string.Empty;
    public bool isAuthenticated = false;
    public bool isVisibleOnLogout = true;

    public class Digest
    {
        public string label { get; set; }
        public string tag { get; set; }
        public string schemaOrgTag { get; set; }
        public int total { get; set; }
        public bool hasRDI { get; set; }
        public int daily { get; set; }
        public string unit { get; set; }
        public Sub sub { get; set; }
    }

    public class Hit
    {
        public Recipe recipe { get; set; }
        public Links _links { get; set; }
    }

    public class Images
    {
        public THUMBNAIL THUMBNAIL { get; set; }
        public SMALL SMALL { get; set; }
        public REGULAR REGULAR { get; set; }
        public LARGE LARGE { get; set; }
    }

    public class Ingredient
    {
        public string text { get; set; }
        public int quantity { get; set; }
        public string measure { get; set; }
        public string food { get; set; }
        public int weight { get; set; }
        public string foodId { get; set; }
    }

    public class LARGE
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Links
    {
        public Self self { get; set; }
        public Next next { get; set; }
    }

    public class Next
    {
        public string href { get; set; }
        public string title { get; set; }
    }

    public class Recipe
    {
        public string uri { get; set; }
        public string label { get; set; }
        public string image { get; set; }
        public Images images { get; set; }
        public string source { get; set; }
        public string url { get; set; }
        public string shareAs { get; set; }
        public int yield { get; set; }
        public List<string> dietLabels { get; set; }
        public List<string> healthLabels { get; set; }
        public List<string> cautions { get; set; }
        public List<string> ingredientLines { get; set; }
        public List<Ingredient> ingredients { get; set; }
        public int calories { get; set; }
        public int glycemicIndex { get; set; }
        public int totalCO2Emissions { get; set; }
        public string co2EmissionsClass { get; set; }
        public int totalWeight { get; set; }
        public List<string> cuisineType { get; set; }
        public List<string> mealType { get; set; }
        public List<string> dishType { get; set; }
        public List<string> instructions { get; set; }
        public List<string> tags { get; set; }
        public string externalId { get; set; }
        public TotalNutrients totalNutrients { get; set; }
        public TotalDaily totalDaily { get; set; }
        public List<Digest> digest { get; set; }
    }

    public class REGULAR
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Root
    {
        public int from { get; set; }
        public int to { get; set; }
        public int count { get; set; }
        public Links _links { get; set; }
        public List<Hit> hits { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
        public string title { get; set; }
    }

    public class SMALL
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Sub
    {
    }

    public class THUMBNAIL
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class TotalDaily
    {
    }

    public class TotalNutrients
    {
    }

}

