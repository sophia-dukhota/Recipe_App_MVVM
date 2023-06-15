using SQLite;

namespace _6002CEM_SophiaDukhota.Models;

public class SignUpModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string verifyPassword = string.Empty;

    public SignUpModel()
	{

	}
}
