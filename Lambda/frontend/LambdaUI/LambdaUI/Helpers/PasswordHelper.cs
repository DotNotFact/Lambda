using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace LambdaUI.Helpers;

public static class PasswordHelper
{
    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.RegisterAttached(
            "Password",
            typeof(string),
            typeof(PasswordHelper),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnPasswordPropertyChanged));

    public static readonly DependencyProperty AttachProperty =
        DependencyProperty.RegisterAttached(
            "Attach",
            typeof(bool),
            typeof(PasswordHelper),
            new PropertyMetadata(false, Attach));

    private static void OnPasswordPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        if (sender is PasswordBox passwordBox)
        {
            passwordBox.PasswordChanged -= PasswordChanged;

            if (GetAttach(passwordBox))
            {
                passwordBox.PasswordChanged += PasswordChanged;
                // passwordBox.Password = GetPassword(passwordBox);
            }
        }
    }

    private static void Attach(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        if (sender is PasswordBox passwordBox)
        {
            if ((bool)e.NewValue)
            {
                passwordBox.PasswordChanged += PasswordChanged;
            }
            else
            {
                passwordBox.PasswordChanged -= PasswordChanged;
            }
        }
    }

    private static void PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (sender is PasswordBox passwordBox)
        {
            SetPassword(passwordBox, passwordBox.Password);
        }
    }

    public static void SetAttach(DependencyObject element, bool value)
    {
        element.SetValue(AttachProperty, value);
    }

    public static bool GetAttach(DependencyObject element)
    {
        return (bool)element.GetValue(AttachProperty);
    }

    public static string GetPassword(DependencyObject element)
    {
        return (string)element.GetValue(PasswordProperty);
    }

    public static void SetPassword(DependencyObject element, string value)
    {
        element.SetValue(PasswordProperty, value);
    }
}