// File: BTLDotNET1/ViewModels/Dialogs/EmployeeDetailsDialogViewModel.cs
using BTLDotNET1.Models;
using BTLDotNET1.Services;

namespace BTLDotNET1.ViewModels.Dialogs
{
    public partial class EmployeeDialogViewModel : ViewModel
    {
        [ObservableProperty]
        private NhanVien _selectedEmployee;
        private readonly IGenericRepository<NhanVien> _employeeRepository;
        private readonly IGenericRepository<ChiTietDiaChi> _addressRepository;
        private readonly IGenericRepository<XaPhuong> _wardRepository;
        private readonly IGenericRepository<HuyenQuan> _districtRepository;
        private readonly IGenericRepository<TinhTp> _cityRepository;


        public EmployeeDialogViewModel(
            IGenericRepository<NhanVien> employeeRepository,
            IGenericRepository<ChiTietDiaChi> addressRepository,
            IGenericRepository<XaPhuong> wardRepository,
            IGenericRepository<HuyenQuan> districtRepository,
            IGenericRepository<TinhTp> cityRepository)
        {
            _employeeRepository = employeeRepository;
            _addressRepository = addressRepository;
            _wardRepository = wardRepository;
            _districtRepository = districtRepository;
            _cityRepository = cityRepository;
        }

        public async void SeletedEmployee(NhanVien nv)
        {
            SelectedEmployee = await Task.Run(() => LoadAsync(nv));
        }

        public async Task<NhanVien> LoadAsync(NhanVien nv)
        {
            if (nv == null) return new();
            await LoadAddressAsync(nv);
            return nv;
        }

        private async Task LoadAddressAsync(NhanVien nv)
        {
            if (nv!.IdDiaChi == null) return;
            var address = await LoadAddressDetailsAsync(nv);
            var ward = await LoadWardDetailsAsync(address);
            var district = await LoadDistrictDetailsAsync(address);
            var city = await LoadCityDetailsAsync(address);

            SelectedEmployee.IdDiaChiNavigation = address;
            SelectedEmployee.IdDiaChiNavigation.IdXaPhuongNavigation = ward!;
            SelectedEmployee.IdDiaChiNavigation.IdHuyenQuanNavigation = district!;
            SelectedEmployee.IdDiaChiNavigation.IdTinhTpNavigation = city!;
        }

        private async Task<ChiTietDiaChi> LoadAddressDetailsAsync(NhanVien nv)
        {
            return await _addressRepository.GetByIdAsync(nv!.IdDiaChi) ?? new();
        }

        private async Task<XaPhuong> LoadWardDetailsAsync(ChiTietDiaChi address)
        {
            return await _wardRepository.GetByIdAsync(address!.IdXaPhuong) ?? new();
        }

        private async Task<HuyenQuan> LoadDistrictDetailsAsync(ChiTietDiaChi address)
        {
            return await _districtRepository.GetByIdAsync(address.IdHuyenQuan) ?? new();
        }

        private async Task<TinhTp> LoadCityDetailsAsync(ChiTietDiaChi address)
        {
            return await _cityRepository.GetByIdAsync(address.IdTinhTp) ?? new();
        }
    }
}
