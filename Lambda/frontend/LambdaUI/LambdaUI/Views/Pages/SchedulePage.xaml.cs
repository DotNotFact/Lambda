using LambdaUI.ViewModels.Pages;
using System.Windows.Controls;

namespace LambdaUI.Views.Pages;

public partial class SchedulePage : Page
{
    public ScheduleViewModel ViewModel { get; }

    public SchedulePage(ScheduleViewModel viewModel)
    {
        ViewModel = viewModel; 
        DataContext = this;

        InitializeComponent();
    }
}
