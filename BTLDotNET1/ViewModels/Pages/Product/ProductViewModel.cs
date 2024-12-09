using BTLDotNET1.Models;
using BTLDotNET1.Services;
using BTLDotNET1.Views.Pages.Product;
using System.Collections.ObjectModel;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace BTLDotNET1.ViewModels.Pages.Product
{
    public partial class ProductViewModel : ViewModel
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly INavigationService _navigationService;
        private readonly ISnackbarService _snackbarService;
        public IContentDialogService ContentDialogService { get; } = new ContentDialogService();
        private readonly IGenericRepository<SanPham> _repositoryProduct;
        private readonly IGenericRepository<Hang> _repositoryBrand;
        private readonly IGenericRepository<ChiTietSanPham> _repositoryProductDetail;

        public ProductViewModel(
            IServiceProvider serviceProvider,
            INavigationService navigationService,
            ISnackbarService snackbarService,
            IGenericRepository<SanPham> repositoryProduct,
            IGenericRepository<Hang> repositoryBrand,
            IGenericRepository<ChiTietSanPham> repositoryProductDetail

)
        {
            _serviceProvider = serviceProvider;
            _snackbarService = snackbarService;
            _repositoryProduct = repositoryProduct;
            _repositoryBrand = repositoryBrand;

            _navigationService = navigationService;
            Task _ = LoadData();
            _repositoryProductDetail = repositoryProductDetail;
            _repositoryProductDetail = repositoryProductDetail;
        }

        [ObservableProperty]
        private bool isAllChecked;

        [ObservableProperty]
        private bool isChecked;

        [ObservableProperty]
        private ObservableCollection<SanPham>? productsList;

        [ObservableProperty]
        private ObservableCollection<SanPham>? suggestedProductsList;

        [ObservableProperty]
        private SanPham? searchedProduct;

        [RelayCommand]
        private async Task LoadData()
        {
            var productListTask = await _repositoryProduct.GetAllAsync();
            if (productListTask != null)
            {
                foreach (var product in productListTask)
                {
                    product.IdHangNavigation = await _repositoryBrand.GetByIdAsync(product.IdHang) ?? new Hang();
                }
                ProductsList = new ObservableCollection<SanPham>(productListTask);
                SuggestedProductsList = ProductsList;
            }

        }

        [RelayCommand]
        public void EditMultipleProductsList(SanPham product)
        {
            var addProductViewModel = _serviceProvider.GetService(typeof(AddProductViewModel)) as AddProductViewModel;
            addProductViewModel.SetCode(product.Ma);
            _navigationService.Navigate(typeof(AddProductPage), addProductViewModel);
        }

        [RelayCommand]
        public async Task DeleteProduct(SanPham product)
        {
            var productDetailsOfProduct = await _repositoryProductDetail.GetByNameAsync(pd => pd.IdSanPham == product.Id);
            foreach (var productDetail in productDetailsOfProduct)
            {
                bool isDeleteProductDetail = await _repositoryProductDetail.DeleteAsync(productDetail.Id);
                if (isDeleteProductDetail)
                {
                    productDetailsOfProduct.ToList().Remove(productDetail);
                }
            }
            if (productDetailsOfProduct.Count() == 0)
            {
                bool isDelete = await _repositoryProduct.DeleteAsync(product.Id);
                if (isDelete)
                {
                    OnOpenSnackbar("Thông báo", "Xóa sản phẩm thành công", ControlAppearance.Success);
                    await LoadData();
                }
                else
                {
                    OnOpenSnackbar("Thông báo", "Xóa sản phẩm thất bại", ControlAppearance.Danger);
                }
            }
            else if (productDetailsOfProduct.Count() > 0)
            {
                foreach (var productDetail in productDetailsOfProduct)
                {
                    productDetail.StatusDeleted = true;
                    await _repositoryProductDetail.UpdateAsync(productDetail);

                }
                product.StatusDeleted = true;
                await _repositoryProduct.UpdateAsync(product);
                OnOpenSnackbar("Thông báo", "Xóa sản phẩm thành công", ControlAppearance.Success);
                await LoadData();
            }
        }

        [RelayCommand]
        public void NavigateToNextPage(SanPham product)
        {
            if (product == null) return;

            var productDetailViewModel = _serviceProvider.GetService(typeof(ProductDetailViewModel)) as ProductDetailViewModel;
            productDetailViewModel!.AddParentProduct(product);
            _navigationService.NavigateWithHierarchy(typeof(ProductDetailPage), productDetailViewModel);
        }

        private void OnOpenSnackbar(string title, string message, ControlAppearance appearance)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                _snackbarService.Show(
                    title,
                    message,
                    appearance,
                    new SymbolIcon(SymbolRegular.DocumentError24),
                    TimeSpan.FromSeconds(2));
            });
        }

    }
}
