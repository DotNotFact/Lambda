using LambdaUI.ViewModels.Pages;
using System.Windows.Controls;

namespace LambdaUI.Views.Pages;

public partial class AdministrationPage : Page
{
    public AdministrationPage(AdministrationViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
