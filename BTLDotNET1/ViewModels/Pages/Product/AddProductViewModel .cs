using BTLDotNET1.Models;
using BTLDotNET1.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace BTLDotNET1.ViewModels.Pages.Product
{
    public partial class AddProductViewModel : ViewModel
    {
        private readonly IGenericRepository<SanPham> _repositoryProduct;
        private readonly IGenericRepository<Hang> _repositoryBrand;
        private readonly IGenericRepository<ChiTietSanPham> _repositoryProductDetail;
        private readonly IGenericRepository<MauSac> _repositoryColor;
        private readonly IGenericRepository<PhuKien> _repositoryAccessory;
        private readonly ISnackbarService _snackbarService;

        #region private properties
        [ObservableProperty]
        private string id = "";
        [ObservableProperty]
        private string? code;
        [ObservableProperty]
        private string? name;
        [ObservableProperty]
        private string? description;
        [ObservableProperty]
        string saveButton = "Thêm Sản Phẩm";
        #endregion

        partial void OnCodeChanging(string? value)
        {
            _ = UpdateSaveButtonAsync();
        }

        private async Task UpdateSaveButtonAsync()
        {
            SaveButton = await CheckCode() ? "Cập Nhật" : "Thêm Sản Phẩm";
        }

        public void SetCode(string code)
        {
            this.Code = code;
        }

        #region ObservableCollection combobox properties
        [ObservableProperty]
        private ObservableCollection<Hang>? brandList;

        [ObservableProperty]
        private ObservableCollection<MauSac>? colorList;

        [ObservableProperty]
        private ObservableCollection<PhuKien>? accessoryList;
        #endregion

        #region properties detail product
        [ObservableProperty]
        private Hang? selectedBrand;
        [ObservableProperty]
        private MauSac? selectedColor;
        [ObservableProperty]
        private PhuKien? selectedAccessory;
        [ObservableProperty]
        private int inputRam;
        [ObservableProperty]
        private int inputStorage;
        #endregion

        #region ObservableCollection List properties
        [ObservableProperty]
        private ObservableCollection<MauSac>? productColorList;
        [ObservableProperty]
        private ObservableCollection<BoNho>? productStorageList;
        [ObservableProperty]
        private ObservableCollection<ChiTietSanPham>? productDetailList;
        #endregion

        public AddProductViewModel(
            ISnackbarService snackbarService,
            IGenericRepository<SanPham> repositoryProduct,
            IGenericRepository<Hang> repositoryBrand,
            IGenericRepository<ChiTietSanPham> repositoryProductDetail,
            IGenericRepository<MauSac> repositoryColor,
            IGenericRepository<PhuKien> repositoryAccessory)
        {
            _snackbarService = snackbarService;
            _repositoryProductDetail = repositoryProductDetail;
            _repositoryProduct = repositoryProduct;
            _repositoryBrand = repositoryBrand;
            _repositoryAccessory = repositoryAccessory;
            _repositoryColor = repositoryColor;
            LoadData().ConfigureAwait(false);
        }

        private async Task LoadData()
        {
            var brandListTask = await _repositoryBrand.GetAllAsync();
            var colorListTask = await _repositoryColor.GetAllAsync();
            var accessoryListTask = await _repositoryAccessory.GetAllAsync();

            //await Task.WhenAll(brandListTask, colorListTask, accessoryListTask);

            BrandList = new ObservableCollection<Hang>(brandListTask);
            ColorList = new ObservableCollection<MauSac>(colorListTask);
            AccessoryList = new ObservableCollection<PhuKien>(accessoryListTask);
        }

        public async Task<bool> CheckCode()
        {
            var product = await _repositoryProduct.GetByCodeAsync(sp => sp.Ma == Code);
            var products = await _repositoryProduct.GetByCodeAsync(sp => sp.Ma == Code);
            if (products is null) return false;

            SelectedBrand = await _repositoryBrand.GetByIdAsync(products.IdHang);
            var productDetails = await _repositoryProductDetail.GetByNameAsync(sp => sp.IdSanPham == products.Id);
            SelectedAccessory = await _repositoryAccessory.GetByIdAsync(productDetails.First().IdPhuKien);

            var productColors = (await _repositoryColor.GetAllAsync())
                .Join(productDetails, ms => ms.Id, ctsp => ctsp.IdMauSac, (ms, ctsp) => ms)
                .GroupBy(ms => ms.Ten)
                .Select(g => g.First())
                .ToList();

            var productStorages = productDetails
                .Select(ctsp => new BoNho { BoNhoRam = ctsp.Ram, BoNhoTrong = ctsp.BoNhoTrong })
                .GroupBy(bn => new { bn.BoNhoRam, bn.BoNhoTrong })
                .Select(g => g.First())
                .OrderBy(bn => bn.BoNhoTrong)
                .ToList();

            var productDetail = productDetails
                .OrderBy(ctsp => ctsp.BoNhoTrong)
                .Select(ctsp => new ChiTietSanPham
                {
                    Id = ctsp.Id,
                    IdMauSacNavigation = productColors.First(ms => ms.Id == ctsp.IdMauSac),
                    BoNhoTrong = ctsp.BoNhoTrong,
                    Ram = ctsp.Ram,
                    Gia = ctsp.Gia,
                    SoLuong = ctsp.SoLuong
                })
                .ToList();

            Id = products.Id;
            Name = products.Ten;
            ProductColorList = new ObservableCollection<MauSac>(productColors);
            ProductStorageList = new ObservableCollection<BoNho>(productStorages);
            ProductDetailList = new ObservableCollection<ChiTietSanPham>(productDetail);
            Description = productDetails.First().MoTa;

            return true;
        }

        [RelayCommand]
        public void AddColor()
        {
            if (ProductColorList == null)
            {
                ProductColorList = new ObservableCollection<MauSac>();
            }
            if (SelectedColor == null || ProductColorList.Any(item => item.Ten == SelectedColor.Ten)) return;
            ProductColorList.Add(SelectedColor);
            CreateProductDetail(SelectedColor);
        }

        [RelayCommand]
        public void AddStorage()
        {
            if (ProductStorageList == null)
            {
                ProductStorageList = new ObservableCollection<BoNho>();
            }
            if (InputRam <= 0 || InputStorage <= 0 || ProductStorageList.Any(item => item.BoNhoRam == InputRam && item.BoNhoTrong == InputStorage)) return;

            var newStorage = new BoNho { BoNhoRam = InputRam, BoNhoTrong = InputStorage };
            ProductStorageList.Add(newStorage);
            CreateProductDetail(newStorage);
        }

        public void CreateProductDetail(dynamic attribute)
        {
            if (ProductDetailList == null)
            {
                ProductDetailList = new ObservableCollection<ChiTietSanPham>();
            }

            if (attribute is MauSac && ProductStorageList != null)
            {
                foreach (var item in ProductStorageList)
                {
                    ProductDetailList.Add(
                        new ChiTietSanPham
                        {
                            Id = Guid.NewGuid().ToString(),
                            IdMauSacNavigation = attribute,
                            Ram = item.BoNhoRam,
                            BoNhoTrong = item.BoNhoTrong,
                            SoLuong = 0,
                            Gia = 0
                        });
                }
            }
            else if (attribute is BoNho && ProductColorList != null)
            {
                foreach (var item in ProductColorList)
                {
                    ProductDetailList.Add(
                        new ChiTietSanPham
                        {
                            Id = Guid.NewGuid().ToString(),
                            IdMauSacNavigation = item,
                            Ram = attribute.BoNhoRam,
                            BoNhoTrong = attribute.BoNhoTrong,
                            SoLuong = 0,
                            Gia = 0
                        });
                }
            }
        }

        private void RemoveProductPrice(MauSac attribute)
        {
            var itemsToRemove = ProductDetailList
                .Where(item => item.IdMauSacNavigation == attribute).ToList();
            foreach (var item in itemsToRemove)
            {
                ProductDetailList.Remove(item);
            }
        }

        private void RemoveProductPrice(BoNho attribute)
        {
            var itemsToRemove = ProductDetailList
                .Where(item => (item.Ram == attribute.BoNhoRam && item.BoNhoTrong == attribute.BoNhoTrong))
                .ToList();
            foreach (var item in itemsToRemove)
            {
                ProductDetailList.Remove(item);
            }
        }

        [RelayCommand]
        public void RemoveProductPrice(ChiTietSanPham productDetail)
        {
            ProductDetailList?.Remove(productDetail);
        }

        [RelayCommand]
        public void RemoveStorage(BoNho storage)
        {
            ProductStorageList?.Remove(storage);
            RemoveProductPrice(storage);
        }

        [RelayCommand]
        public void RemoveColor(MauSac productColor)
        {
            ProductColorList?.Remove(productColor);
            RemoveProductPrice(productColor);
        }

        private bool CheckValidateProduct()
        {
            try
            {
                if (string.IsNullOrEmpty(code)) throw new Exception("Mã sản phẩm không được để trống");
                if (string.IsNullOrEmpty(name)) throw new Exception("Tên sản phẩm không được để trống");
                if (SelectedBrand == null) throw new Exception("Hãng sản phẩm không được để trống");
                if (SelectedAccessory == null) throw new Exception("Phụ kiện sản phẩm không được để trống");
                if (ProductColorList.Count == 0) throw new Exception("Màu sản phẩm không được để trống");
                if (ProductStorageList.Count == 0) throw new Exception("Bộ nhớ sản phẩm không được để trống");
                if (ProductDetailList.Count == 0) throw new Exception("Giá sản phẩm không được để trống");
            }
            catch (Exception ex)
            {
                OnOpenSnackbar("Lỗi", ex.Message, ControlAppearance.Danger);
                return false;
            }
            return true;
        }

        private void OnOpenSnackbar(string title, string message, ControlAppearance appearance)
        {
            _snackbarService.Show(
                title,
                message,
                appearance,
                new SymbolIcon(SymbolRegular.DocumentError24),
                TimeSpan.FromSeconds(2)
            );
        }

        [RelayCommand]
        public async Task AddProduct()
        {
            if (!CheckValidateProduct()) return;

            var options = new DbContextOptionsBuilder<QLSBDTContext>().Options;
            using var context = new QLSBDTContext(options);
            var service = new SanPhamService(context, _repositoryProductDetail);

            var product = new SanPham
            {
                Id = Id != "" ? Id : Guid.NewGuid().ToString(),
                Ma = Code,
                Ten = Name,
                CreateDate = DateOnly.FromDateTime(DateTime.Now),
                LastModifiedDate = DateOnly.FromDateTime(DateTime.Now),
                StatusDeleted = false,
                IdHang = SelectedBrand.Id
            };

            var productDetails = ProductDetailList.Select(item => new ChiTietSanPham
            {
                Id = item.Id,
                IdSanPham = product.Id,
                IdMauSac = item.IdMauSacNavigation.Id,
                IdPhuKien = SelectedAccessory.Id,
                IdCtspKhuyenMai = "001",
                BoNhoTrong = item.BoNhoTrong,
                Ram = item.Ram,
                Gia = item.Gia,
                SoLuong = item.SoLuong,
                MoTa = Description,
                CreateDate = DateOnly.FromDateTime(DateTime.Now),
                LastModifiedDate = DateOnly.FromDateTime(DateTime.Now),
                StatusDeleted = false,
            }).ToList();

            await service.AddOrUpdateSanPhamAsync(product, productDetails);
            OnOpenSnackbar("Thông báo", SaveButton + " thành công", ControlAppearance.Success);
            ClearData();
        }

        [RelayCommand]
        public void ClearData()
        {
            Id = "";
            Name = "";
            Code = "";
            SelectedBrand = null;
            SelectedAccessory = null;
            SelectedColor = null;
            InputRam = 0;
            InputStorage = 0;
            ProductColorList?.Clear();
            ProductStorageList?.Clear();
            ProductDetailList?.Clear();
            Description = "";
        }
    }
}

public partial class BoNho
{
    public double? BoNhoRam { get; set; }
    public double? BoNhoTrong { get; set; }
}
