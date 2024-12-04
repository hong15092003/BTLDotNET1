using BTLDotNET1.ViewModels.Pages.Product;
using Wpf.Ui.Controls;

namespace BTLDotNET1.Views.Pages.Product
{
    /// <summary>
    /// Interaction logic for ColorPage.xaml
    /// </summary>
    public partial class ColorPage : INavigableView<ColorViewModel>
    {
        public ColorViewModel ViewModel { get; }
        public ColorPage(ColorViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            DataContext = viewModel;
        }


    }
}
