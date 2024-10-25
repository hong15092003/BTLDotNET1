using BTLDotNET1.ViewModels.Pages;
using BTLDotNET1.ViewModels.Pages.Product;
using Wpf.Ui.Controls;

namespace BTLDotNET1.Views.Pages.Product
{
    public partial class AddProductPage : INavigableView<AddProductViewModel>
    {
        public AddProductViewModel ViewModel { get; }

        public AddProductPage(AddProductViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}
