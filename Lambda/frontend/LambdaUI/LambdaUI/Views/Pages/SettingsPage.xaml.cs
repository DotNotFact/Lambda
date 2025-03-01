using LambdaUI.ViewModels.Pages;
using System.Windows.Controls;

namespace LambdaUI.Views.Pages;

public partial class SettingsPage : Page
{
    public SettingsViewModel ViewModel { get; }

    public SettingsPage(SettingsViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }
}
