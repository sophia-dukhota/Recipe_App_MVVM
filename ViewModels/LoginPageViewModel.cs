using System.Windows.Input;
//using Bumptech.Glide.Load.Model;

namespace _6002CEM_SophiaDukhota.ViewModels;

public class LoginPageViewModel : BaseViewModel
{
	public Models.LoginPageModel LoginPageModel { get; set; }
	public ICommand CheckUserCredsCommand { get; set; }

    private double _checkButtonWorks;

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

    /*
    public double checkButtonWorks
    {
        get => _checkButtonWorks;
        set
        {
            if (_checkButtonWorks != value)
            {
                _checkButtonWorks = 80;
                OnPropertyChanged(nameof(checkButtonWorks));
            }
        }
    }

*/

    //change this to use .stringIsNullOrEmpty
    private bool ShouldCheckUserCreds() => Username != "" && Password != "";

    private void CheckUserCreds() {
        Username = "defiantly not a swear";
    }

    public LoginPageViewModel()
    {
        LoginPageModel = new Models.LoginPageModel();
        CheckUserCredsCommand = new Command(execute: () => CheckUserCreds(), canExecute: ShouldCheckUserCreds);
    }
}
