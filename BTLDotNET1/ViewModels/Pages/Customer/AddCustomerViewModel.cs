using BTLDotNET1.Models;
using BTLDotNET1.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace BTLDotNET1.ViewModels.Pages.Customer
{
    public partial class AddCustomerViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IGenericRepository<ChiTietDiaChi> _repositoryAddressDetail;
        private readonly IGenericRepository<TinhTp> _repositoryCity;
        private readonly IGenericRepository<HuyenQuan> _repositoryDistrict;
        private readonly IGenericRepository<XaPhuong> _repositoryWard;
        private readonly IGenericRepository<KhachHang> _repositoryCustomer;
        private readonly ISnackbarService _snackBarService;

        #region Observable Properties
        [ObservableProperty] private ObservableCollection<TinhTp> cityList = new();
        [ObservableProperty] private ObservableCollection<HuyenQuan> districtList = new();
        [ObservableProperty] private ObservableCollection<XaPhuong> wardList = new();

        [ObservableProperty] private string email = string.Empty;
        [ObservableProperty] private string gender = string.Empty;
        [ObservableProperty] private string fullName = string.Empty;
        [ObservableProperty] private string id = string.Empty;
        [ObservableProperty] private string addressId = string.Empty;
        [ObservableProperty] private string customerCode = string.Empty;
        [ObservableProperty] private string addressDescription = string.Empty;
        [ObservableProperty] private DateOnly? birthDate;
        [ObservableProperty] private string phoneNumber = string.Empty;

        [ObservableProperty] private TinhTp selectedCity = new();
        [ObservableProperty] private HuyenQuan selectedDistrict = new();
        [ObservableProperty] private XaPhuong selectedWard = new();
        #endregion

        public AddCustomerViewModel(
            IGenericRepository<KhachHang> repositoryCustomer,
            IGenericRepository<ChiTietDiaChi> repositoryAddressDetail,
            IGenericRepository<TinhTp> repositoryCity,
            IGenericRepository<HuyenQuan> repositoryDistrict,
            IGenericRepository<XaPhuong> repositoryWard,
            ISnackbarService snackBarService,
            INavigationService navigationService
        )
        {
            _repositoryCustomer = repositoryCustomer;
            _repositoryAddressDetail = repositoryAddressDetail;
            _repositoryCity = repositoryCity;
            _repositoryDistrict = repositoryDistrict;
            _repositoryWard = repositoryWard;
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
        #endregion

        #region Relay Commands
        [RelayCommand]
        private async Task LoadData()
        {
            var cities = await _repositoryCity.GetAllAsync();
            var districts = new ObservableCollection<HuyenQuan>
            {
                new HuyenQuan { Ten = "Vui lòng chọn Tỉnh Thành Phố" }
            };
            var wards = new ObservableCollection<XaPhuong>
            {
                new XaPhuong { Ten = "Vui lòng chọn Quận Huyện" }
            };

            CityList = new ObservableCollection<TinhTp>(cities);
            DistrictList = new ObservableCollection<HuyenQuan>(districts);
            WardList = new ObservableCollection<XaPhuong>(wards);
        }

        [RelayCommand]
        private async Task AddOrUpdateCustomer()
        {
            if (!CheckValidateCustomer()) return;

            try
            {
                var customer = new KhachHang
                {
                    MaKh = CustomerCode,
                    HoTen = FullName,
                    GioiTinh = Gender,
                    NgaySinh = BirthDate,
                    Email = Email,
                    Sdt = PhoneNumber,
                    LastModifiedDate = DateOnly.FromDateTime(DateTime.Now),
                    StatusDeleted = false
                };

                if (string.IsNullOrEmpty(Id))
                {
                    // Add New Customer
                    customer.Id = Guid.NewGuid().ToString();
                    customer.MaKh = await GetNumberOfCustomer();
                    customer.CreateDate = DateOnly.FromDateTime(DateTime.Now);
                    AddressId = await AddAddress();
                    if (string.IsNullOrEmpty(AddressId))
                    {
                        OnOpenSnackBar("Thông Báo", "Không thể thêm địa chỉ", ControlAppearance.Danger);
                        return;
                    }
                    customer.IdDiaChi = AddressId;
                    bool isAddCustomerDone = await _repositoryCustomer.AddAsync(customer);
                    if (isAddCustomerDone)
                    {
                        OnOpenSnackBar("Thông Báo", "Thêm khách hàng thành công", ControlAppearance.Success);
                        ClearData();
                    }
                }
                else
                {
                    // Update Existing Customer
                    bool updateAddress = await UpdateAddress();
                    if (updateAddress)
                    {
                        customer.IdDiaChi = AddressId;
                        bool isUpdateCustomerDone = await _repositoryCustomer.UpdateAsync(customer);
                        if (isUpdateCustomerDone)
                        {
                            OnOpenSnackBar("Thông Báo", "Sửa khách hàng thành công", ControlAppearance.Success);
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
            CustomerCode = string.Empty;
            AddressDescription = string.Empty;
            BirthDate = null;
            PhoneNumber = string.Empty;
            SelectedCity = new TinhTp();
            SelectedDistrict = new HuyenQuan();
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

        private async Task<string> GetNumberOfCustomer()
        {
            var customerList = await _repositoryCustomer.GetByNameAsync(c => c.MaKh.StartsWith("KH"));
            string lastCustomerCode = customerList.OrderByDescending(c => c.MaKh).FirstOrDefault()?.MaKh ?? "KH0000";
            string[] newCustomerCode = lastCustomerCode.Split("KH");
            int newCode = int.Parse(newCustomerCode.Length > 1 ? newCustomerCode[1] : "0000") + 1;
            return "KH" + newCode.ToString("D4");
        }

        private async Task FillDataByCode(string customerCode)
        {
            if (string.IsNullOrEmpty(customerCode)) return;
            var customer = await _repositoryCustomer.GetByCodeAsync(kh => kh.MaKh == customerCode);
            if (customer != null)
            {
                Id = customer.Id;
                var addressDetail = await _repositoryAddressDetail.GetByIdAsync(customer.IdDiaChi);
                FullName = customer.HoTen;
                Gender = customer.GioiTinh;
                BirthDate = customer.NgaySinh;
                Email = customer.Email;
                PhoneNumber = customer.Sdt;
                AddressId = customer.IdDiaChi;
                SelectedWard = await _repositoryWard.GetByIdAsync(addressDetail!.IdXaPhuong) ?? new XaPhuong();
                SelectedDistrict = await _repositoryDistrict.GetByIdAsync(addressDetail.IdHuyenQuan) ?? new HuyenQuan();
                SelectedCity = await _repositoryCity.GetByIdAsync(addressDetail.IdTinhTp) ?? new TinhTp();
                AddressDescription = addressDetail.MoTa;
            }
        }

        private void FillDataToDistrict(TinhTp value)
        {
            if (value?.Id == null) return;
            var districts = _repositoryDistrict.GetByNameAsync(d => d.IdTinhTp == value.Id).Result;
            DistrictList = new ObservableCollection<HuyenQuan>(districts);
            SelectedDistrict = new HuyenQuan { Ten = "Vui lòng chọn Quận Huyện" };
            WardList = new ObservableCollection<XaPhuong>
            {
                new XaPhuong { Ten = "Vui lòng chọn Quận Huyện" }
            };
        }

        private void FillDataToWard(HuyenQuan value)
        {
            if (value?.Id == null) return;
            var wards = _repositoryWard.GetByNameAsync(w => w.IdHuyenQuan == value.Id).Result;
            WardList = new ObservableCollection<XaPhuong>(wards);
            SelectedWard = new XaPhuong { Ten = "Vui lòng chọn Xã Phường" };
        }

        private bool CheckValidateCustomer()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FullName))
                    throw new Exception("Tên khách hàng không được để trống.");
                if (string.IsNullOrWhiteSpace(Gender))
                    throw new Exception("Giới tính không được để trống.");
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
