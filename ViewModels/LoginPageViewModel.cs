using System.Security.Cryptography;
using System.Windows.Input;
using System.Text;
//using Bumptech.Glide.Load.Model;

namespace _6002CEM_SophiaDukhota.ViewModels;

public class LoginPageViewModel : BaseViewModel
{
	public Models.LoginPageModel LoginPageModel { get; set; }
	public ICommand CheckUserCredsCommand { get; set; }

    //config for salting and hashing the password
    private const int saltSize = 32;
    private const int iterations = 100000;
    HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

    public string Username
    {
        get => LoginPageModel.username;
        set
        {
            LoginPageModel.username = value;
            OnPropertyChanged(nameof(Username));
            (CheckUserCredsCommand as Command).ChangeCanExecute();
        }
    }

    public string Password
    {
        get => LoginPageModel.password;
        set
        {
            LoginPageModel.password = value;
            OnPropertyChanged(nameof(Password));
            (CheckUserCredsCommand as Command).ChangeCanExecute();

        }
    }


    //change this to use .stringIsNullOrEmpty
    private bool ShouldCheckUserCreds() => Username != "" && Password != "";

    //modified from https://code-maze.com/csharp-hashing-salting-passwords-best-practices/ 
    private void CheckUserCreds() {
        //generates a salt of length saltSize
        var salt = RandomNumberGenerator.GetBytes(saltSize);
        //creates a hash byte array 
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(Password),
            salt, iterations, hashAlgorithm, saltSize);
        //sets password to hexstring of hash
        Password = Convert.ToHexString(hash);
    }

    public LoginPageViewModel()
    {
        LoginPageModel = new Models.LoginPageModel();
        CheckUserCredsCommand = new Command(execute: () => CheckUserCreds(), canExecute: ShouldCheckUserCreds);
    }
}
