using BTLDotNET1.ViewModels.Pages.Employee;
using Wpf.Ui.Controls;

namespace BTLDotNET1.Views.Pages.Employee
{
    public partial class AddEmployeePage : INavigableView<AddEmployeeViewModel>
    {
        public AddEmployeeViewModel ViewModel { get; }

        public AddEmployeePage(AddEmployeeViewModel viewModel)
        {
            DataContext = viewModel;
            ViewModel = viewModel;
            InitializeComponent();
        }
    }
}