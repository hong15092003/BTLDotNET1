using BTLDotNET1.Models;
using BTLDotNET1.Services;
using System.Collections.ObjectModel;
using Wpf.Ui;

namespace BTLDotNET1.ViewModels.Pages.Product;

public partial class ProductDetailViewModel : ViewModel
{
    private readonly INavigationService navigationService;

    [ObservableProperty] private ObservableCollection<ChiTietSanPham> productDetailsList;

    [ObservableProperty] private SanPham parentProduct;

    private readonly IGenericRepository<ChiTietSanPham> _repositoryProductDetail;
    private readonly IGenericRepository<MauSac> _repositoryColor;
    private readonly IGenericRepository<PhuKien> _repositoryAccessory;

    public ProductDetailViewModel(
        IGenericRepository<PhuKien> repositoryAccessory,
        IGenericRepository<MauSac> repositoryColor,
        IGenericRepository<ChiTietSanPham> repositoryProductDetail
    )
    {
        _repositoryAccessory = repositoryAccessory;
        _repositoryColor = repositoryColor;
        _repositoryProductDetail = repositoryProductDetail;
    }

    public void AddParentProduct(SanPham product)
    {
        this.ParentProduct = product;
        LoadData();
    }

    private async void LoadData()
    {
        Console.WriteLine(ParentProduct);
        ProductDetailsList = await Task.Run(() => GetProductDetailsList());
    }

    private async Task<ObservableCollection<ChiTietSanPham>> GetProductDetailsList()
    {
        var productDetails = await _repositoryProductDetail.GetByNameAsync(x => x.IdSanPham == ParentProduct.Id);
        List<ChiTietSanPham> list = new List<ChiTietSanPham>();

        foreach (var pd in productDetails)
        {
            var color = await _repositoryColor.GetByIdAsync(pd.IdMauSac);
            var accessory = await _repositoryAccessory.GetByIdAsync(pd.IdPhuKien);
            list.Add(new ChiTietSanPham
            {
                IdSanPham = pd.Id,
                IdSanPhamNavigation = ParentProduct,
                IdMauSacNavigation = color,
                IdPhuKienNavigation = accessory,
                BoNhoTrong = pd.BoNhoTrong,
                Ram = pd.Ram,
                Gia = pd.Gia,
                SoLuong = pd.SoLuong,
                CreateDate = pd.CreateDate,
                LastModifiedDate = pd.LastModifiedDate,
                StatusDeleted = pd.StatusDeleted
            });
        }

        list = list.Where(x => x.StatusDeleted == false).OrderBy(p => p.BoNhoTrong).ToList();
        return new ObservableCollection<ChiTietSanPham>(list);
    }

    [RelayCommand]
    public void NavigateBack()
    {
        navigationService.GoBack();
    }
}
