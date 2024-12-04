using BTLDotNET1.Models;
using BTLDotNET1.Services;
using System.Collections.ObjectModel;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace BTLDotNET1.ViewModels.Pages.Product
{
    public partial class BrandViewModel : ViewModel
    {
        [ObservableProperty] private string id = "";
        [ObservableProperty] private string? ma;
        [ObservableProperty] private string? ten;
        [ObservableProperty] private string? tenNut = "Thêm";
        [ObservableProperty] private string? noiDungTimKiem;
        [ObservableProperty] ObservableCollection<Hang> goiY = new ObservableCollection<Hang>();

        private ISnackbarService _snackbarService;
        private IGenericRepository<Hang> _repositoryBrand;

        [ObservableProperty] ObservableCollection<Hang> danhSachHang = new ObservableCollection<Hang>();

        public BrandViewModel(ISnackbarService snackbarService, IGenericRepository<Hang> repositoryBrand)
        {
            _snackbarService = snackbarService;
            _repositoryBrand = repositoryBrand;
            _ = LoadData();
        }

        [RelayCommand]
        private async Task LoadData()
        {
            var hangs = await Task.Run(() => _repositoryBrand.GetAllAsync());
            DanhSachHang = new ObservableCollection<Hang>(hangs);
            GoiY = DanhSachHang;
        }

        [RelayCommand]
        private async Task TimKiemHang()
        {
            var timKiem = await _repositoryBrand.GetByNameAsync(b => b.Ten.Contains(Ten));
            DanhSachHang = new ObservableCollection<Hang>(timKiem);
        }

        private async void KiemTraHang(string id)
        {
            var brand = await _repositoryBrand.GetByIdAsync(id);
            if (brand != null)
            {
                Id = brand.Id;
                Ma = brand.Ma;
                Ten = brand.Ten;
                TenNut = "Cập nhật";
            }
            else
            {
                Id = "";
                Ma = "";
                Ten = "";
                TenNut = "Thêm";
            }
        }

        [RelayCommand]
        private void SuaHang(Hang Hang)
        {
            KiemTraHang(Hang.Id);
        }

        [RelayCommand]
        private async Task ThemHang()
        {
            Hang hang = new Hang
            {
                Id = Id != "" ? Id : Guid.NewGuid().ToString(),
                Ma = Ma,
                Ten = Ten,
                CreateDate = DateOnly.FromDateTime(DateTime.Now),
                LastModifiedDate = DateOnly.FromDateTime(DateTime.Now),
                StatusDeleted = false
            };
            if (await _repositoryBrand.AddOrUpdateAsync(hang))
            {
                //LoadData();
                await LoadData();
                XoaDuLieu();
                OnOpenSnackbar("Thông báo", TenNut + " hãng thành công", ControlAppearance.Success);
            }
            else
            {
                OnOpenSnackbar("Thông báo", TenNut + " hãng thất bại", ControlAppearance.Danger);
            }
        }

        [RelayCommand]
        private async void XoaHang(Hang hang)
        {
            if (await _repositoryBrand.DeleteAsync(hang.Id))
            {
                await LoadData();
                OnOpenSnackbar("Thông báo", "Xóa hãng thành công", ControlAppearance.Success);
            }
            else
            {
                OnOpenSnackbar("Thông báo", "Xóa hãng thất bại", ControlAppearance.Danger);
            }
        }

        [RelayCommand]
        private void XoaDuLieu()
        {
            Id = "";
            Ma = "";
            Ten = "";
            TenNut = "Thêm";
        }

        private void OnOpenSnackbar
        (
            string title,
            string message,
            ControlAppearance appearance
        )
        {
            _snackbarService.Show(
                title,
                message,
                appearance,
                new SymbolIcon(SymbolRegular.DocumentError24),
                TimeSpan.FromSeconds(2)
            );
        }
    }
}