using BTLDotNET1.Models;
using BTLDotNET1.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace BTLDotNET1.ViewModels.Pages.Employee
{
    public partial class AddEmployeeViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IGenericRepository<ChiTietDiaChi> _repositoryAddressDetail;
        private readonly IGenericRepository<TinhTp> _repositoryCity;
        private readonly IGenericRepository<HuyenQuan> _repositoryDistrict;
        private readonly IGenericRepository<XaPhuong> _repositoryWard;
        private readonly IGenericRepository<NhanVien> _repositoryEmployee;
        private readonly IGenericRepository<VaiTro> _repositoryRole;
        private readonly ISnackbarService _snackBarService;

        #region Observable Properties
        [ObservableProperty] private ObservableCollection<HuyenQuan> districtList = new();
        [ObservableProperty] private ObservableCollection<TinhTp> cityList = new();
        [ObservableProperty] private ObservableCollection<VaiTro> roleList = new();
        [ObservableProperty] private ObservableCollection<XaPhuong> wardList = new();

        [ObservableProperty] private string email = string.Empty;
        [ObservableProperty] private string gender = string.Empty;
        [ObservableProperty] private string fullName = string.Empty;
        [ObservableProperty] private string id = string.Empty;
        [ObservableProperty] private string addressId = string.Empty;
        [ObservableProperty] private string employeeCode = string.Empty;
        [ObservableProperty] private string password = string.Empty;
        [ObservableProperty] private string addressDescription = string.Empty;
        [ObservableProperty] private DateOnly? birthDate;
        [ObservableProperty] private string phoneNumber = string.Empty;

        [ObservableProperty] private HuyenQuan selectedDistrict = new();
        [ObservableProperty] private TinhTp selectedCity = new();
        [ObservableProperty] private VaiTro selectedRole = new();
        [ObservableProperty] private XaPhuong selectedWard = new();
        #endregion

        public AddEmployeeViewModel(
            IGenericRepository<NhanVien> repositoryEmployee,
            IGenericRepository<VaiTro> repositoryRole,
            IGenericRepository<XaPhuong> repositoryWard,
            IGenericRepository<HuyenQuan> repositoryDistrict,
            IGenericRepository<TinhTp> repositoryCity,
            IGenericRepository<ChiTietDiaChi> repositoryAddressDetail,
            ISnackbarService snackBarService,
            INavigationService navigationService
        )
        {
            _repositoryEmployee = repositoryEmployee;
            _repositoryRole = repositoryRole;
            _repositoryWard = repositoryWard;
            _repositoryDistrict = repositoryDistrict;
            _repositoryCity = repositoryCity;
            _repositoryAddressDetail = repositoryAddressDetail;
            _snackBarService = snackBarService;
            _navigationService = navigationService;
            _ = LoadData();
        }

        #region Partial Methods for Property Changes
        partial void OnSelectedCityChanged(TinhTp value)
        {
            FillDataToDistrict(value);
        }

        partial void OnSelectedDistrictChanged(HuyenQuan value)
        {
            FillDataToWard(value);
        }

        partial void OnEmployeeCodeChanging(string value)
        {
            _ = FillDataByCode(value);
        }
        #endregion

        #region Relay Commands
        [RelayCommand]
        private async Task LoadData()
        {
            var roles = await _repositoryRole.GetAllAsync();
            var cities = await _repositoryCity.GetAllAsync();
            var districts = new ObservableCollection<HuyenQuan>
            {
                new HuyenQuan { Ten = "Vui lòng chọn Tỉnh Thành Phố" }
            };
            var wards = new ObservableCollection<XaPhuong>
            {
                new XaPhuong { Ten = "Vui lòng chọn Quận Huyện" }
            };

            RoleList = new ObservableCollection<VaiTro>(roles);
            CityList = new ObservableCollection<TinhTp>(cities);
            DistrictList = new ObservableCollection<HuyenQuan>(districts);
            WardList = new ObservableCollection<XaPhuong>(wards);
        }

        [RelayCommand]
        private async Task AddOrUpdateEmployee()
        {
            if (!CheckValidateEmployee()) return;

            try
            {
                var employee = new NhanVien
                {
                    MaNv = EmployeeCode,
                    HoTen = FullName,
                    GioiTinh = Gender,
                    NgaySinh = BirthDate,
                    Email = Email,
                    MatKhau = Password,
                    Sdt = PhoneNumber,
                    LastModifiedDate = DateOnly.FromDateTime(DateTime.Now),
                    StatusDeleted = false,
                    IdVaiTro = SelectedRole.Id
                };

                if (string.IsNullOrEmpty(Id))
                {
                    // Add New Employee
                    employee.Id = Guid.NewGuid().ToString();
                    employee.MaNv = await GetNumberOfEmployee();
                    employee.CreateDate = DateOnly.FromDateTime(DateTime.Now);
                    AddressId = await AddAddress();
                    if (string.IsNullOrEmpty(AddressId))
                    {
                        OnOpenSnackBar("Thông Báo", "Không thể thêm địa chỉ", ControlAppearance.Danger);
                        return;
                    }
                    employee.IdDiaChi = AddressId;
                    bool isAddEmployeeDone = await _repositoryEmployee.AddAsync(employee);
                    if (isAddEmployeeDone)
                    {
                        OnOpenSnackBar("Thông Báo", "Thêm nhân viên thành công", ControlAppearance.Success);
                        ClearData();
                    }
                }
                else
                {
                    // Update Existing Employee
                    bool updateAddress = await UpdateAddress();
                    if (updateAddress)
                    {
                        employee.IdDiaChi = AddressId;
                        bool isUpdateEmployeeDone = await _repositoryEmployee.UpdateAsync(employee);
                        if (isUpdateEmployeeDone)
                        {
                            OnOpenSnackBar("Thông Báo", "Sửa nhân viên thành công", ControlAppearance.Success);
                            ClearData();
                        }
                    }
                    else
                    {
                        OnOpenSnackBar("Thông Báo", "Xảy ra lỗi khi sửa địa chỉ", ControlAppearance.Danger);
                    }
                }
            }
            catch (Exception)
            {
                OnOpenSnackBar("Lỗi", "Đã xảy ra lỗi, vui lòng thử lại", ControlAppearance.Danger);
            }
        }

        [RelayCommand]
        private async Task ClearData()
        {
            Email = string.Empty;
            Gender = string.Empty;
            FullName = string.Empty;
            Id = string.Empty;
            AddressId = string.Empty;
            EmployeeCode = string.Empty;
            Password = string.Empty;
            AddressDescription = string.Empty;
            BirthDate = null;
            PhoneNumber = string.Empty;
            SelectedCity = new TinhTp();
            SelectedDistrict = new HuyenQuan();
            SelectedRole = new VaiTro();
            SelectedWard = new XaPhuong();
            await LoadData();
        }
        #endregion

        #region Private Methods
        private async Task<string> AddAddress()
        {
            var id = Guid.NewGuid().ToString();
            var addressDetail = new ChiTietDiaChi
            {
                Id = id,
                IdXaPhuong = SelectedWard.Id,
                IdHuyenQuan = SelectedDistrict.Id,
                IdTinhTp = SelectedCity.Id,
                MoTa = AddressDescription,
                CreateDate = DateOnly.FromDateTime(DateTime.Now),
                LastModifiedDate = DateOnly.FromDateTime(DateTime.Now),
                StatusDeleted = false
            };
            bool isAddressDone = await _repositoryAddressDetail.AddAsync(addressDetail);
            return isAddressDone ? id : string.Empty;
        }

        private async Task<bool> UpdateAddress()
        {
            var addressDetail = new ChiTietDiaChi
            {
                Id = AddressId,
                IdXaPhuong = SelectedWard.Id,
                IdHuyenQuan = SelectedDistrict.Id,
                IdTinhTp = SelectedCity.Id,
                MoTa = AddressDescription,
                LastModifiedDate = DateOnly.FromDateTime(DateTime.Now),
                StatusDeleted = false
            };
            var oldAddressDetail = await _repositoryAddressDetail.GetByIdAsync(AddressId);
            if (oldAddressDetail == null) return false;

            bool isValueHasChanged = oldAddressDetail.IdTinhTp != addressDetail.IdTinhTp ||
                oldAddressDetail.IdHuyenQuan != addressDetail.IdHuyenQuan ||
                oldAddressDetail.IdXaPhuong != addressDetail.IdXaPhuong ||
                oldAddressDetail.MoTa != addressDetail.MoTa;

            return !isValueHasChanged || await _repositoryAddressDetail.UpdateAsync(addressDetail);
        }

        private async Task<string> GetNumberOfEmployee()
        {
            string roleCode = SelectedRole.Id == "0001" ? "QL" : "NV";
            var employeeList = await _repositoryEmployee.GetByNameAsync(e => e.MaNv.StartsWith(roleCode));
            string lastEmployeeCode = employeeList.OrderByDescending(e => e.MaNv).FirstOrDefault()?.MaNv ?? $"{roleCode}0000";
            string[] newEmployeeCode = lastEmployeeCode.Split(roleCode);
            int newCode = int.Parse(newEmployeeCode.Length > 1 ? newEmployeeCode[1] : "0000") + 1;
            return roleCode + newCode.ToString("D4");
        }

        private async Task FillDataByCode(string employeeCode)
        {
            if (string.IsNullOrEmpty(employeeCode)) return;
            var employee = await _repositoryEmployee.GetByCodeAsync(nv => nv.MaNv == employeeCode);
            if (employee != null)
            {
                Id = employee.Id;
                var addressDetail = await _repositoryAddressDetail.GetByIdAsync(employee.IdDiaChi);
                FullName = employee.HoTen;
                Gender = employee.GioiTinh;
                BirthDate = employee.NgaySinh;
                Email = employee.Email;
                Password = employee.MatKhau;
                PhoneNumber = employee.Sdt;
                AddressId = employee.IdDiaChi;
                SelectedRole = await _repositoryRole.GetByIdAsync(employee.IdVaiTro) ?? new VaiTro();
                SelectedWard = await _repositoryWard.GetByIdAsync(addressDetail!.IdXaPhuong) ?? new XaPhuong();
                SelectedDistrict = await _repositoryDistrict.GetByIdAsync(addressDetail.IdHuyenQuan) ?? new HuyenQuan();
                SelectedCity = await _repositoryCity.GetByIdAsync(addressDetail.IdTinhTp) ?? new TinhTp();
                AddressDescription = addressDetail.MoTa;
            }
        }

        private async void FillDataToDistrict(TinhTp value)
        {
            if (value?.Id == null) return;
            var districts = await _repositoryDistrict.GetByNameAsync(d => d.IdTinhTp == value.Id);
            DistrictList = new ObservableCollection<HuyenQuan>(districts);
            SelectedDistrict = new HuyenQuan { Ten = "Vui lòng chọn Quận/Huyện" };
            WardList = new ObservableCollection<XaPhuong>
            {
                new XaPhuong { Ten = "Vui lòng chọn Xã/Phường" }
            };
        }

        private async void FillDataToWard(HuyenQuan value)
        {
            if (value?.Id == null) return;
            var wards = await _repositoryWard.GetByNameAsync(w => w.IdHuyenQuan == value.Id);
            WardList = new ObservableCollection<XaPhuong>(wards);
            SelectedWard = new XaPhuong { Ten = "Vui lòng chọn Xã/Phường" };
        }

        private bool CheckValidateEmployee()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FullName))
                    throw new Exception("Tên nhân viên không được để trống.");
                if (string.IsNullOrWhiteSpace(Gender))
                    throw new Exception("Giới tính không được để trống.");
                if (SelectedRole == null || string.IsNullOrWhiteSpace(SelectedRole.Id))
                    throw new Exception("Vui lòng chọn Vai Trò.");
                if (SelectedCity == null || string.IsNullOrWhiteSpace(SelectedCity.Id))
                    throw new Exception("Vui lòng chọn Tỉnh/Thành phố.");
                if (SelectedDistrict == null || string.IsNullOrWhiteSpace(SelectedDistrict.Id))
                    throw new Exception("Vui lòng chọn Quận/Huyện.");
                if (SelectedWard == null || string.IsNullOrWhiteSpace(SelectedWard.Id))
                    throw new Exception("Vui lòng chọn Xã/Phường.");
                if (string.IsNullOrWhiteSpace(PhoneNumber))
                    throw new Exception("Số điện thoại không được để trống.");
                if (!PhoneNumber.All(char.IsDigit))
                    throw new Exception("Số điện thoại chỉ chứa số.");
                if (!string.IsNullOrWhiteSpace(Email) && !IsValidEmail(Email))
                    throw new Exception("Email không hợp lệ.");
                if (string.IsNullOrWhiteSpace(Password))
                    throw new Exception("Mật khẩu không được để trống.");
                if (Password.Length < 6)
                    throw new Exception("Mật khẩu phải có ít nhất 6 ký tự.");
            }
            catch (Exception ex)
            {
                OnOpenSnackBar("Lỗi", ex.Message, ControlAppearance.Danger);
                return false;
            }
            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void OnOpenSnackBar(string title, string message, ControlAppearance appearance)
        {
            _snackBarService.Show(
                title,
                message,
                appearance,
                new SymbolIcon(SymbolRegular.DocumentError24),
                TimeSpan.FromSeconds(2)
            );
        }
        #endregion
    }
}
