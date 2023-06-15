using _6002CEM_SophiaDukhota.Models;
using SQLite;

namespace _6002CEM_SophiaDukhota.Database;

public class UsersDB
{
    private readonly SQLiteAsyncConnection _database;

    public UsersDB(string dbPath)
	{
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<SignUpModel>();
	}

    //error here - can't find file
    public Task<List<SignUpModel>> GetUsers()
    {
        return _database.Table<SignUpModel>().ToListAsync();
    }

    public Task<int> SaveUser (SignUpModel user)
    {
        return _database.InsertAsync(user);
    }
}
