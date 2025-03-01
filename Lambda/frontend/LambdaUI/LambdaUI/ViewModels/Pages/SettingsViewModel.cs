using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Media;
using System.Reflection;
using Wpf.Ui.Appearance;

namespace LambdaUI.ViewModels.Pages;

public partial class SettingsViewModel : ObservableObject
{
    private bool _isInitialized = false;

    [ObservableProperty]
    private string _appVersion = string.Empty;

    [ObservableProperty]
    private ApplicationTheme _currentApplicationTheme = ApplicationTheme.Unknown;

    partial void OnCurrentApplicationThemeChanged(ApplicationTheme oldValue, ApplicationTheme newValue)
    {
        ApplicationThemeManager.Apply(newValue);
    }

    private void InitializeViewModel()
    {
        CurrentApplicationTheme = ApplicationThemeManager.GetAppTheme();
        AppVersion = $"{GetAssemblyVersion()}";

        ApplicationThemeManager.Changed += OnThemeChanged;

        _isInitialized = true;
    }

    private void OnThemeChanged(ApplicationTheme currentApplicationTheme, Color systemAccent)
    {
        // Update the theme if it has been changed elsewhere than in the settings.
        if (CurrentApplicationTheme != currentApplicationTheme)
        {
            CurrentApplicationTheme = currentApplicationTheme;
        }
    }

    private static string GetAssemblyVersion()
    {
        return Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? string.Empty;
    }
}