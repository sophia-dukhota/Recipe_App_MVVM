using System.Security.Cryptography;
using System.Windows.Input;
using System.Text;
using System.ComponentModel;
//using Bumptech.Glide.Load.Model;

namespace _6002CEM_SophiaDukhota.ViewModels;

public class LoginPageViewModel : BaseViewModel
{

	public Models.LoginPageModel LoginPageModel { get; set; }
	public ICommand CheckUserCredsCommand { get; set; }
    public ICommand GoToSignUpCommand { get; set; }

    //config for salting and hashing the password
    private const int saltSize = 32;
    private const int iterations = 100000;
    HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

    private bool _incorrectCreds;
    public bool incorrectCreds

    {
        get { return _incorrectCreds; }
        set
        {
            _incorrectCreds = value;
            OnPropertyChanged(nameof(incorrectCreds));
        }
    }

    //sets username of loginpage to to Username, and calls 
    public string Username
    {
        get => LoginPageModel.username;
        set
        {
            LoginPageModel.username = value;
            OnPropertyChanged(nameof(Username));
            //updates canExecute (ShouldCheckUserCreds)
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


    //CHANGE this to use .stringIsNullOrEmpty
    private bool ShouldCheckUserCreds() => Username != "" && Password != "";

    //modified from https://code-maze.com/csharp-hashing-salting-passwords-best-practices/
    private string HashPassword() {
        //generates a salt of length saltSize
        var salt = RandomNumberGenerator.GetBytes(saltSize);
        //creates a hash byte array 
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(Password),
            salt,iterations, hashAlgorithm, saltSize);
        //sets password to hexstring of hash
        string hashedPassword = Convert.ToHexString(hash);
        return hashedPassword;
        //moified code end 
    }

    private async Task CheckUserCreds() {
        if (Username == "Excal" && Password == "swordfish")
        {
            await GoToMainAppPage();
        }
        else
        {
            incorrectCreds = true;
        }
            
    }

    private async Task GoToSignUp() {
        await Shell.Current.GoToAsync("/SignUpPage");
    }

    private async Task GoToMainAppPage()
    {
        await Shell.Current.GoToAsync("/MainAppPage");
    }

    public LoginPageViewModel()
    {
        LoginPageModel = new Models.LoginPageModel();
        CheckUserCredsCommand = new Command(execute: async () => await CheckUserCreds(), canExecute: ShouldCheckUserCreds);
        GoToSignUpCommand = new Command(execute: async () => await GoToSignUp());
    }
}