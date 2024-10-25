using BTLDotNET1.ViewModels.Pages;
using BTLDotNET1.ViewModels.Pages.Product;
using System.Windows.Media;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace BTLDotNET1.Views.Pages.Product
{
    public partial class ProductPage : INavigableView<ProductViewModel>
    {
        public ProductViewModel ViewModel { get; }

        public ProductPage(ProductViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = viewModel;
            InitializeComponent();
            viewModel.contentDialogService.SetDialogHost(RootContentDialogPresenter);
        }
    }
}
