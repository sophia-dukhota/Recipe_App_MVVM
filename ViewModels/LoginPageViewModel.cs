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