using LambdaUI.ViewModels.Pages;
using System.Windows.Controls;

namespace LambdaUI.Views.Pages;

public partial class AttendancePage : Page
{
    public AttendanceViewModel ViewModel { get; }

    public AttendancePage(AttendanceViewModel viewModel)
    {
        ViewModel = viewModel;

        DataContext = this;
        InitializeComponent();
    }
}
