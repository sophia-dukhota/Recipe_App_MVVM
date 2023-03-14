namespace _6002CEM_SophiaDukhota.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    void Username_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.NewTextValue))
        {
            var viewModel = (BindingContext as ViewModels.LoginPageViewModel);
            viewModel.Username = e.NewTextValue;

        }
        else
        {
            var viewModel = (BindingContext as ViewModels.LoginPageViewModel);
            viewModel.Username = string.Empty;
        }
    }

    void Password_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.NewTextValue))
        {
            var viewModel = (BindingContext as ViewModels.LoginPageViewModel);
            viewModel.Password = e.NewTextValue;

        }
        else
        {
            var viewModel = (BindingContext as ViewModels.LoginPageViewModel);
            viewModel.Password = string.Empty;
        }
    }
}