using LambdaUI.ViewModels.Pages;
using System.Windows.Controls;

namespace LambdaUI.Views.Pages;
 
public partial class DocumentsPage : Page
{
    public DocumentsPage(DocumentsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
