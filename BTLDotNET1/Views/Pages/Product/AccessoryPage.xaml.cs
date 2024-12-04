using BTLDotNET1.ViewModels.Pages.Product;
using Wpf.Ui.Controls;

namespace BTLDotNET1.Views.Pages.Product
{
    /// <summary>
    /// Interaction logic for AccessoryPage.xaml
    /// </summary>
    public partial class AccessoryPage : INavigableView<AccessoryViewModel>
    {
        public AccessoryViewModel ViewModel { get; }
        public AccessoryPage(AccessoryViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = viewModel;
        }


    }
}
