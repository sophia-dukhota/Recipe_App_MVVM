namespace _6002CEM_SophiaDukhota.Views;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
        InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        testingSaveToDB.ItemsSource = await App.UsersDB.GetUsers();
    }

    void Username_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.NewTextValue))
        {
            var viewModel = (BindingContext as ViewModels.SignUpViewModel);
            viewModel.Username = e.NewTextValue;

        }
        else
        {
            var viewModel = (BindingContext as ViewModels.SignUpViewModel);
            viewModel.Username = string.Empty;
        }
    }

    void Password_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.NewTextValue))
        {
            var viewModel = (BindingContext as ViewModels.SignUpViewModel);
            viewModel.Password = e.NewTextValue;

        }
        else
        {
            var viewModel = (BindingContext as ViewModels.SignUpViewModel);
            viewModel.Password = string.Empty;
        }
    }

    void VerifyPassword_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.NewTextValue))
        {
            var viewModel = (BindingContext as ViewModels.SignUpViewModel);
            viewModel.VerifyPassword = e.NewTextValue;

        }
        else
        {
            var viewModel = (BindingContext as ViewModels.SignUpViewModel);
            viewModel.VerifyPassword = string.Empty;
        }
    }

    async void AddToDB(System.Object sender, System.EventArgs e)
    {
        await App.UsersDB.SaveUser(new Models.SignUpModel
        {
            username = usernameEntry.Text,
            password = passwordEntry.Text,
            verifyPassword = verifyPasswordEntry.Text
        });
    }
}
