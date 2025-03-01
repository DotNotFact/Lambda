using LambdaUI.ViewModels.Pages;
using System.Windows.Controls;

namespace LambdaUI.Views.Pages;

public partial class ProfilesPage : Page
{
    public ProfilesPage(ProfilesViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
