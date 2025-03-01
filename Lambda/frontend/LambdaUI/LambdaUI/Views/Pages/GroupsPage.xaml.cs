using LambdaUI.ViewModels.Pages;
using System.Windows.Controls;

namespace LambdaUI.Views.Pages;
 
public partial class GroupsPage : Page
{
    public GroupsViewModel ViewModel { get; }

    public GroupsPage(GroupsViewModel viewModel)
    {
        ViewModel = viewModel;

        DataContext = this;
        InitializeComponent();

    }
}
