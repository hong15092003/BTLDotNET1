using BTLDotNET1.Models;
using BTLDotNET1.Services;
using System.Collections.ObjectModel;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace BTLDotNET1.ViewModels.Pages.Product
{
    public partial class AccessoryViewModel : ViewModel
    {
        [ObservableProperty] private string id = "";
        [ObservableProperty] private string? ma;
        [ObservableProperty] private string? moTa;
        [ObservableProperty] private string? tenNut = "Thêm";
        [ObservableProperty] private string? noiDungTimKiem;
        [ObservableProperty] ObservableCollection<PhuKien> goiY = new ObservableCollection<PhuKien>();

        private ISnackbarService _snackbarService;
        private readonly IGenericRepository<PhuKien> _repositoryAccessory;

        [ObservableProperty] ObservableCollection<PhuKien> danhSachPhuKien = new ObservableCollection<PhuKien>();


        public AccessoryViewModel(ISnackbarService snackbarService, IGenericRepository<PhuKien> repositoryAccessory)
        {
            _snackbarService = snackbarService;
            _repositoryAccessory = repositoryAccessory;
            _ = LoadData();
        }

        [RelayCommand]
        private async Task LoadData()
        {
            var phuKiens = await Task.Run(() => _repositoryAccessory.GetAllAsync());
            DanhSachPhuKien = new ObservableCollection<PhuKien>(phuKiens);
            GoiY = DanhSachPhuKien;
        }

        [RelayCommand]
        private async Task TimKiemPhuKien()
        {
            var phuKiens = await _repositoryAccessory.GetByNameAsync(a => a.MoTa.Contains(MoTa));
            DanhSachPhuKien = new ObservableCollection<PhuKien>(phuKiens);
        }

        private async void KiemTraPhuKien(string id)
        {
            PhuKien? PhuKien = await _repositoryAccessory.GetByIdAsync(id);
            if (PhuKien != null)
            {
                Id = PhuKien.Id;
                Ma = PhuKien.Ma;
                MoTa = PhuKien.MoTa;
                TenNut = "Cập nhật";
            }
            else
            {
                Id = "";
                Ma = "";
                MoTa = "";
                TenNut = "Thêm";
            }
        }

        [RelayCommand]
        private void SuaPhuKien(PhuKien PhuKien)
        {
            KiemTraPhuKien(PhuKien.Id);
        }

        [RelayCommand]
        private async Task ThemPhuKien()
        {
            PhuKien PhuKien = new PhuKien
            {
                Id = Id != "" ? Id : Guid.NewGuid().ToString(),
                Ma = Ma,
                MoTa = MoTa,
                CreateDate = DateOnly.FromDateTime(DateTime.Now),
                LastModifiedDate = DateOnly.FromDateTime(DateTime.Now),
                StatusDeleted = false
            };
            if (await _repositoryAccessory.AddOrUpdateAsync(PhuKien))
            {
                await LoadData();
                XoaDuLieu();
                OnOpenSnackbar("Thông báo", TenNut + " phụ kiện thành công", ControlAppearance.Success);
            }
            else
            {
                OnOpenSnackbar("Thông báo", TenNut + " phụ kiện thất bại", ControlAppearance.Danger);
            }
        }

        [RelayCommand]
        private async Task XoaPhuKien(PhuKien PhuKien)
        {
            if (await _repositoryAccessory.DeleteAsync(PhuKien.Id))
            {
                await LoadData();
                OnOpenSnackbar("Thông báo", "Xóa phụ kiện thành công", ControlAppearance.Success);
            }
            else
            {
                OnOpenSnackbar("Thông báo", "Xóa phụ kiện thất bại", ControlAppearance.Danger);
            }
        }

        [RelayCommand]
        private void XoaDuLieu()
        {
            Id = "";
            Ma = "";
            MoTa = "";
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