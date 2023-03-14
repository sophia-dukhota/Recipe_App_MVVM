namespace _6002CEM_SophiaDukhota.Views;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
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
}
