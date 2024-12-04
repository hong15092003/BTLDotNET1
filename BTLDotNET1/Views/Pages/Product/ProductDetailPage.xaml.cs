using BTLDotNET1.ViewModels.Pages.Product;
using Wpf.Ui.Controls;

namespace BTLDotNET1.Views.Pages.Product
{

    public partial class ProductDetailPage : INavigableView<ProductDetailViewModel>
    {

        public ProductDetailViewModel ViewModel { get; }
        public ProductDetailPage(ProductDetailViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
