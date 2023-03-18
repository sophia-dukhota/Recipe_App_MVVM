using System.Windows.Input;

namespace _6002CEM_SophiaDukhota.ViewModels;

public class SignUpViewModel : BaseViewModel
{
    public Models.SignUpModel SignUpModel { get; set; }

    public ICommand RegisterUserCommand { get; set; }

    public string Username
    {
        get => SignUpModel.username;
        set
        {
            SignUpModel.username = value;
            OnPropertyChanged(nameof(Username));
            (RegisterUserCommand as Command).ChangeCanExecute();
        }
    }

    public string Password
    {
        get => SignUpModel.password;
        set
        {
            SignUpModel.password = value;
            OnPropertyChanged(nameof(Password));
            (RegisterUserCommand as Command).ChangeCanExecute();
        }
    }

    public string VerifyPassword
    {
        get => SignUpModel.verifyPassword;
        set
        {
            SignUpModel.verifyPassword = value;
            OnPropertyChanged(nameof(VerifyPassword));
            (RegisterUserCommand as Command).ChangeCanExecute();
        }
    }

    //returns true when passwords are indentical and not empty, and username is not empty
    //make sure the passwords its checking are haSHED   
    public bool CredentialsIsValid() => (Password != "" && VerifyPassword != "")
        && (Password == VerifyPassword) && Username!= "";

    //CHANGE THIS IMPLEMENTATION
    //DONT FORGET TO HASH THEM 
    public void RegisterUser() {
        Password = "THE BUTTON CLICK WORKS";
    }

    public SignUpViewModel()
	{
        SignUpModel = new Models.SignUpModel();
        RegisterUserCommand = new Command(execute: () => RegisterUser(), canExecute: CredentialsIsValid);
    }
}