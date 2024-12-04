using BTLDotNET1.ViewModels.Pages.Product;
using Wpf.Ui.Controls;

namespace BTLDotNET1.Views.Pages.Product
{
    /// <summary>
    /// Interaction logic for BrandPage.xaml
    /// </summary>
    public partial class BrandPage : INavigableView<BrandViewModel>
    {
        public BrandViewModel ViewModel { get; }
        public BrandPage(BrandViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = viewModel;
        }


    }
}
