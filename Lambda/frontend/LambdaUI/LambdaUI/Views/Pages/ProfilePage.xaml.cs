using LambdaUI.ViewModels.Pages;
using System.Windows.Controls;

namespace LambdaUI.Views.Pages;
 
public partial class ProfilePage : Page
{
    public ProfileViewModel ViewModel { get; }

    public ProfilePage(ProfileViewModel viewModel)
    {
        ViewModel = viewModel;

        DataContext = this;
        InitializeComponent();

    }
}
