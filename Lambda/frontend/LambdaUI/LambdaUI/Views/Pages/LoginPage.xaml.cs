using LambdaUI.ViewModels.Pages;
using System.Windows.Controls;

namespace LambdaUI.Views.Pages;
 
public partial class LoginPage : Page
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
