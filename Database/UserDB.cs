using SQLite;
//using static Java.Util.Jar.Attributes;

namespace _6002CEM_SophiaDukhota.Database;

/*public class UserDB
{
    //SQLiteAsyncConnection Database;

    string _dbPath;
    private SQLiteConnection conn;

    public UserDB(string dbPath)
    {
        _dbPath = dbPath;

    }

    public void Init()
    {
        conn = new SQLiteConnection(_dbPath);
        conn.CreateTable<UserDB>();
    }

    public List<Users> GetAllUsers()
    {
        Init();
        return conn.Table<Users>().ToList();
    }

    public void AddUser(Users user)
    {
        conn = new SQLiteConnection(_dbPath);
        conn.Insert(user);
    }

    public void DeleteUser(int id)
    {
        conn = new SQLiteConnection(_dbPath);
        conn.Delete(new Users { UserID = id });
    } */

    /*
    public void CreateTable()
    {
        try
        {
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<UserDB>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }*/


    /*async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(ConfigDB.DatabasePath, ConfigDB.Flags);
        var result = await Database.CreateTableAsync<UserDB>();
    }
}*/