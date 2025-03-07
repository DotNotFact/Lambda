using LambdaUI.ViewModels.Windows;
using LambdaUI.Views.Pages;
using Wpf.Ui.Controls;
using System.Windows;
using Wpf.Ui; 

namespace LambdaUI.Views.Windows;

public partial class MainWindow : IWindow
{
    public MainWindowViewModel ViewModel { get; }
    private readonly INavigationService _navigationService;

    public MainWindow(MainWindowViewModel viewModel, INavigationService navigationService)
    {
        Wpf.Ui.Appearance.SystemThemeWatcher.Watch(this);

        _navigationService = navigationService;
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
         
        navigationService.SetNavigationControl(RootNavigation);
        Loaded += (_, _) => RootNavigation.Navigate(typeof(LoginPage)); 
    } 

    private void OnNavigationSelectionChanged(object sender, RoutedEventArgs e)
    {
        if (sender is not NavigationView navigationView)
            return;

        RootNavigation.SetCurrentValue(
            NavigationView.HeaderVisibilityProperty,
            navigationView.SelectedItem?.TargetPageType != typeof(DashboardPage)
                ? Visibility.Visible
                : Visibility.Collapsed
        );

        // Навигация к выбранной странице
        if (navigationView.SelectedItem is NavigationViewItem item)
        {
            _navigationService.Navigate(item.TargetPageType ?? typeof(DashboardPage));
        }
    }

    private bool _isUserClosedPane;
    private bool _isPaneOpenedOrClosedFromCode;

    private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (_isUserClosedPane)
            return;

        _isPaneOpenedOrClosedFromCode = true;
        RootNavigation.SetCurrentValue(NavigationView.IsPaneOpenProperty, e.NewSize.Width > 1200);
        _isPaneOpenedOrClosedFromCode = false;
        // TODO: Реализовать логику для адаптивного дизайна
    }

    private void NavigationView_OnPaneClosed(NavigationView sender, RoutedEventArgs args)
    {
        if (_isPaneOpenedOrClosedFromCode)
        {
            return;
        }

        _isUserClosedPane = true;
    }

    private void NavigationView_OnPaneOpened(NavigationView sender, RoutedEventArgs args)
    {
        if (_isPaneOpenedOrClosedFromCode)
            return;

        _isUserClosedPane = false;
    }
}

public interface IWindow
{
    event RoutedEventHandler Loaded;
    void Show();
}