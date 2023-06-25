namespace _6002CEM_SophiaDukhota.Services;

using _6002CEM_SophiaDukhota.Models;
using SQLite;

public class RecipesDB
{
    SQLiteAsyncConnection Database;

    public RecipesDB()
    {
    }

    public async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await Database.CreateTableAsync<SearchHistoryItem>();
    }

    public async Task<int> SaveItemAsync(SearchHistoryItem itemModel)
    {
        await Init();
        return await Database.InsertAsync(itemModel);
    }

    /*public async Task List<SearchHistoryItem> GetItemsAsync()
    {
        await Init();
        return Database.Table<SearchHistoryItem>().ToListAsync();
    }*/

    public async Task<IEnumerable<SearchHistoryItem>> GetItemsAsync()
    {
        await Init();
        var items = await Database.Table<SearchHistoryItem>().ToListAsync();
        return items;
    }
}