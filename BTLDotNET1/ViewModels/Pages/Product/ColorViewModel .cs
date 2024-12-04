using BTLDotNET1.Models;
using BTLDotNET1.Services;
using System.Collections.ObjectModel;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace BTLDotNET1.ViewModels.Pages.Product
{
    public partial class ColorViewModel : ViewModel
    {
        [ObservableProperty] private string id = "";
        [ObservableProperty] private string? ma;
        [ObservableProperty] private string? ten;
        [ObservableProperty] private string? tenNut = "Thêm";
        [ObservableProperty] private string? noiDungTimKiem;
        [ObservableProperty] ObservableCollection<MauSac> goiY = new ObservableCollection<MauSac>();

        private ISnackbarService _snackbarService;
        private readonly IGenericRepository<MauSac> _repositoryColor;

        [ObservableProperty] ObservableCollection<MauSac> danhSachMauSac = new ObservableCollection<MauSac>();

        public ColorViewModel(ISnackbarService snackbarService, IGenericRepository<MauSac> repositoryColor)
        {
            _snackbarService = snackbarService;
            _repositoryColor = repositoryColor;
            _ = LoadData();
        }

        [RelayCommand]
        private async Task LoadData()
        {
            var colors = await Task.Run(() => _repositoryColor.GetAllAsync());
            DanhSachMauSac = new ObservableCollection<MauSac>(colors);
            GoiY = DanhSachMauSac;
        }

        [RelayCommand]
        private async Task TimKiemMauSac()
        {
            var seachColor = await _repositoryColor.GetByNameAsync(c => c.Ten.Contains(Ten));
            DanhSachMauSac = new ObservableCollection<MauSac>(seachColor);
        }

        private async void KiemTraMauSac(string id)
        {
            var color = await _repositoryColor.GetByIdAsync(id);
            if (color != null)
            {
                Id = color.Id;
                Ma = color.Ma;
                Ten = color.Ten;
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
        private void SuaMauSac(MauSac MauSac)
        {
            KiemTraMauSac(MauSac.Id);
        }

        [RelayCommand]
        private async Task ThemMauSac()
        {
            MauSac MauSac = new MauSac
            {
                Id = Id != "" ? Id : Guid.NewGuid().ToString(),
                Ma = Ma,
                Ten = Ten,
                CreateDate = DateOnly.FromDateTime(DateTime.Now),
                LastModifiedDate = DateOnly.FromDateTime(DateTime.Now),
                StatusDeleted = false
            };
            if (await _repositoryColor.AddOrUpdateAsync(MauSac))
            {
                await LoadData();
                XoaDuLieu();
                OnOpenSnackbar("Thông báo", TenNut + " màu sắc thành công", ControlAppearance.Success);
            }
            else
            {
                OnOpenSnackbar("Thông báo", TenNut + " màu sắc thất bại", ControlAppearance.Danger);
            }
        }

        [RelayCommand]
        private async Task XoaMauSac(MauSac MauSac)
        {
            if (await _repositoryColor.DeleteAsync(MauSac.Id))
            {
                await LoadData();
                OnOpenSnackbar("Thông báo", "Xóa màu sắc thành công", ControlAppearance.Success);
            }
            else
            {
                OnOpenSnackbar("Thông báo", "Xóa màu sắc thất bại", ControlAppearance.Danger);
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