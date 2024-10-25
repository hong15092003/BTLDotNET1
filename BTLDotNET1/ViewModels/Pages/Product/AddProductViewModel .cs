using BTLDotNET1.Models;
using System.Windows.Media;
using Wpf.Ui.Controls;

namespace BTLDotNET1.ViewModels.Pages.Product
{
    public partial class AddProductViewModel : ViewModel
    {
        private bool _isInitialized = false;

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        public void OnNavigatedFrom() { }

        private void InitializeViewModel()
        {
          
            _isInitialized = true;
        }
    }
}
