using LambdaUI.ViewModels.Pages;
using LambdaUI.ViewModels.Windows;
using System.Windows.Controls;

namespace LambdaUI.Views.Pages;

/// <summary>
/// Логика взаимодействия для DashboardPage.xaml
/// </summary>
public partial class DashboardPage : Page
{
    public DashboardViewModel ViewModel { get; }
    public DashboardPage(DashboardViewModel viewModel)
    {
        ViewModel = viewModel;

        DataContext = this;
        InitializeComponent();

    }
}
