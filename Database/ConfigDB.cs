using SQLite;

namespace _6002CEM_SophiaDukhota.Database;

public class ConfigDB
{
    /*code modified from https://learn.microsoft.com/en-us/dotnet/maui/data-cloud/database-sqlite?view=net-maui-7.0
    public const string DatabaseFilename = "UserDB.db3";

    public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

    public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    */


}

[Table("Users")]
public class Users
{
    [PrimaryKey, AutoIncrement, Column("UserID")]
    public int UserID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}