namespace _6002CEM_SophiaDukhota.Models;

using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

public class SearchHistoryItem
{
    [PrimaryKey]
    [AutoIncrement]
    public int Id { get; set; }
    public string searchTerm { get; set; }
}

public partial class Ingredient : ObservableObject
{
    public string ingredient { get; set; }
}