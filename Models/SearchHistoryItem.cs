namespace _6002CEM_SophiaDukhota.Models;

using SQLite;

public class SearchHistoryItem
{
    [PrimaryKey]
    [AutoIncrement]
    public int Id { get; set; }
    public string searchTerm { get; set; }
}