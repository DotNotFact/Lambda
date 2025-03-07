using LambdaUI.ViewModels.Pages;
using System.Windows;
using System.Windows.Controls;

namespace LambdaUI.Views.Pages;

public partial class RegisterPage : Page
{
    public RegisterPage(RegisterViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    } 
}
