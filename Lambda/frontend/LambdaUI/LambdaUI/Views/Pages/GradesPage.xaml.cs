using LambdaUI.ViewModels.Pages;
using System.Windows.Controls;

namespace LambdaUI.Views.Pages;

public partial class GradesPage : Page
{
    public GradesViewModel ViewModel { get; }

    public GradesPage(GradesViewModel viewModel)
    {
        ViewModel = viewModel;

        DataContext = this;
        InitializeComponent();

    }
}
