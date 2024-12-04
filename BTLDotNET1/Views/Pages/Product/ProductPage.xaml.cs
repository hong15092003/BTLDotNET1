using BTLDotNET1.ViewModels.Pages.Product;
using Wpf.Ui.Controls;

namespace BTLDotNET1.Views.Pages.Product
{
    public partial class ProductPage : INavigableView<ProductViewModel>
    {
        public ProductViewModel ViewModel { get; }

        public ProductPage(ProductViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = viewModel;
        }
    }
}
