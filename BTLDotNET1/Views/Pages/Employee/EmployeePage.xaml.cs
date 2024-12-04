using BTLDotNET1.ViewModels;
using BTLDotNET1.ViewModels.Pages.Employee;
using System.Windows.Controls;
using Wpf.Ui.Controls;

namespace BTLDotNET1.Views.Pages.Employee
{
    /// <summary>
    /// Interaction logic for EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : INavigableView<EmployeeViewModel>
    {
        public EmployeeViewModel ViewModel { get; }
        public EmployeePage(EmployeeViewModel viewModel)
        {
            DataContext = viewModel;
            ViewModel = viewModel;
            InitializeComponent();
        }
    }
}
