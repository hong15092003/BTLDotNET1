using BTLDotNET1.Models;
using BTLDotNET1.Services;
using Microsoft.IdentityModel.Tokens;
using System.Collections.ObjectModel;
using System.Windows.Automation;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace BTLDotNET1.ViewModels.Pages.Sell
{
    public partial class SellViewModel : ObservableObject
    {
        private readonly IGenericRepository<HoaDon> _repositoryInvoice;
        private readonly IGenericRepository<HoaDonChiTiet> _repositoryInvoiceDetail;
        private readonly IGenericRepository<KhachHang> _repositoryCustomer;
        private readonly IGenericRepository<ChiTietSanPham> _repositoryProductDetail;
        private readonly IGenericRepository<SanPham> _repositoryProduct;
        private readonly IGenericRepository<MauSac> _repositoryColor;
        private readonly ISnackbarService _snackBarService;
        private readonly INavigationService _navigationService;
        private readonly ISessionService _sessionService;

        #region Observable Properties

        [ObservableProperty] private string ma = string.Empty;

        [ObservableProperty] private string idKh = string.Empty;

        [ObservableProperty] private string idNv = string.Empty;

        [ObservableProperty] private DateOnly ngayTao = DateOnly.FromDateTime(DateTime.Now);

        [ObservableProperty] private DateOnly? ngayThanhToan;

        [ObservableProperty] private decimal phanTramGiamGia = 0;

        [ObservableProperty] private decimal tienKhachDua = 0;

        [ObservableProperty] private string hinhThucThanhToan = string.Empty;

        [ObservableProperty] private string trangThai = "Đang Chờ";

        [ObservableProperty] private ObservableCollection<KhachHang> customers = new();


        [ObservableProperty] private ObservableCollection<SanPham> products = new();

        [ObservableProperty] private ObservableCollection<ChiTietSanPham> productDetails = new();

        [ObservableProperty] private ObservableCollection<MauSac> colors = new();

        [ObservableProperty] private ObservableCollection<HoaDonChiTiet> invoiceDetails = new();

        [ObservableProperty] private int isHaveValue;

        [ObservableProperty] private ObservableCollection<string> paymentMethods = ["Tiền mặt", "Ngân Hàng"];

        [ObservableProperty] private KhachHang selectedCustomer;

        [ObservableProperty] private string selectedPaymentMethod = "Tiền Mặt";

        [ObservableProperty] private decimal totalAmount = 0;

        [ObservableProperty] private decimal discountAmount = 0;

        [ObservableProperty] private decimal finalAmount = 0;

        [ObservableProperty] private decimal changeDue = 0;

        [ObservableProperty] private string searchProductText = string.Empty;

        [ObservableProperty] private MauSac selectedColor = new();

        [ObservableProperty] private string selectedRam = string.Empty;

        [ObservableProperty] private string selectedStorage = string.Empty;



        #endregion

        #region Unique ComboBox Items

        [ObservableProperty] private ObservableCollection<double?> uniqueRamItems = new();
        [ObservableProperty] private ObservableCollection<double?> uniqueStorageItems = new();

        #endregion


        public SellViewModel(
            IGenericRepository<HoaDon> repositoryInvoice,
            IGenericRepository<HoaDonChiTiet> repositoryInvoiceDetail,
            IGenericRepository<KhachHang> repositoryCustomer,
            IGenericRepository<SanPham> repositoryProduct,
            IGenericRepository<ChiTietSanPham> repositoryProductDetail,
            IGenericRepository<MauSac> repositoryColor,
            ISnackbarService snackBarService,
            INavigationService navigationService,
            ISessionService sessionService
        )
        {
            _repositoryInvoice = repositoryInvoice;
            _repositoryInvoiceDetail = repositoryInvoiceDetail;
            _repositoryCustomer = repositoryCustomer;
            _repositoryProductDetail = repositoryProductDetail;
            _repositoryProduct = repositoryProduct;
            _repositoryColor = repositoryColor;
            _snackBarService = snackBarService;
            _navigationService = navigationService;
            _sessionService = sessionService;
            _ = LoadDataAsync();
        }

        partial void OnSearchProductTextChanged(string value)
        {
        }

        partial void OnTienKhachDuaChanging(decimal value)
        {
            CalculateTotals();
        }

        partial void OnPhanTramGiamGiaChanging(decimal value)
        {
            CalculateTotals();
        }

        #region Relay Commands

        [RelayCommand]
        private async Task LoadDataAsync()
        {
            Customers = new ObservableCollection<KhachHang>(await _repositoryCustomer.GetAllAsync());
            Products = new ObservableCollection<SanPham>(await _repositoryProduct.GetAllAsync());
            ProductDetails = new ObservableCollection<ChiTietSanPham>(await _repositoryProductDetail.GetAllAsync());
            Colors = new ObservableCollection<MauSac>(await _repositoryColor.GetAllAsync());
            UniqueRamItems = new ObservableCollection<double?>(
                ProductDetails.Select(p => p.Ram).Distinct().ToList());
            UniqueStorageItems = new ObservableCollection<double?>(
                ProductDetails.Select(p => p.BoNhoTrong).Distinct().ToList());


            foreach (var productDetail in ProductDetails)
            {
                productDetail.IdSanPhamNavigation = Products.Where(p => p.Id == productDetail.IdSanPham).First();
                productDetail.IdMauSacNavigation = Colors.Where(c => c.Id == productDetail.IdMauSac).First();
            }

            Ma = GenerateInvoiceNumber();
            IdNv = GetCurrentEmployeeId(); // Implement this method based on your authentication
        }

        [RelayCommand]
        private void AddProduct()
        {
            // Implement product selection dialog
            // Example: Open a dialog to select a product from ProductDetails collection
            // For demonstration, let's assume a product is selected and added
            if (string.IsNullOrEmpty(SearchProductText) && SelectedRam == null && SelectedStorage == null &&
                SelectedColor == null)
            {
                OnOpenSnackBar("Thông tin", "Vui lòng nhập thông tin sản phẩm.", ControlAppearance.Info);
                return;
            }

            var selectedProduct = ProductDetails
                .Where(p => p.IdSanPhamNavigation.Ten.ToLower() == SearchProductText.ToLower())
                .Where(p => p.IdMauSac == SelectedColor.Id)
                .Where(p => p.Ram.ToString() == SelectedRam)
                .Where(p => p.BoNhoTrong.ToString() == SelectedStorage)
                .FirstOrDefault();
            if (selectedProduct != null)
            {
                var existingDetail = InvoiceDetails.FirstOrDefault(d => d.IdSanPham == selectedProduct.Id);
                if (existingDetail != null)
                {
                    existingDetail.SoLuong += 1;
                    
                    
                }
                else
                {
                    InvoiceDetails.Add(new HoaDonChiTiet
                    {
                        Id = Guid.NewGuid().ToString(),
                        IdSanPham = selectedProduct.Id,
                        IdSanPhamNavigation = selectedProduct,
                        SoLuong = 1,
                        DonGia = selectedProduct.Gia ?? 0
                    });
                }
               
                OnPropertyChanged(nameof(InvoiceDetails));
                IsHaveValue = 1;
                CalculateTotals();
            }
            else
            {
                OnOpenSnackBar("Thông tin", "Không tìm thấy sản phẩm.", ControlAppearance.Info);
            }
        }

        [RelayCommand]
        private void RemoveProduct(HoaDonChiTiet selectedDetail)
        {
            if (selectedDetail != null)
            {
                InvoiceDetails.Remove(selectedDetail);
                CalculateTotals();
            }
            if(InvoiceDetails.Count == 0)
            {
                IsHaveValue = 0;
            }
        }

        [RelayCommand]
        private void ApplyDiscount()
        {
            DiscountAmount = TotalAmount * (PhanTramGiamGia / 100);
            FinalAmount = TotalAmount - DiscountAmount;
            CalculateChangeDue();
        }

        [RelayCommand]
        private async Task ProcessPaymentAsync()
        {
            if (!ValidateInput()) return;

            try
            {
                var invoice = new HoaDon
                {
                    Id = Guid.NewGuid().ToString(),
                    Ma = Ma,
                    IdKh = SelectedCustomer.Id,
                    IdNv = IdNv,
                    NgayTao = NgayTao,
                    NgayThanhToan = DateOnly.FromDateTime(DateTime.Now),
                    PhanTramGiamGia = PhanTramGiamGia.ToString(),
                    TienKhachDua = TienKhachDua.ToString(),
                    HinhThucThanhToan = HinhThucThanhToan,
                    TrangThai = "Completed",
                    CreateDate = DateOnly.FromDateTime(DateTime.Now),
                    LastModifiedDate = DateOnly.FromDateTime(DateTime.Now),
                    StatusDeleted = false
                };

                bool isInvoiceAdded = await _repositoryInvoice.AddAsync(invoice);
                if (isInvoiceAdded)
                {
                    foreach (var detail in InvoiceDetails)
                    {
                        detail.IdHoaDon = invoice.Id;
                        detail.CreateDate = DateOnly.FromDateTime(DateTime.Now);
                        detail.LastModifiedDate = DateOnly.FromDateTime(DateTime.Now);
                        detail.StatusDeleted = false;
                        await _repositoryInvoiceDetail.AddAsync(detail);
                    }

                    OnOpenSnackBar("Thành công", "Đã tạo hóa đơn thành công.", ControlAppearance.Success);
                    ClearData();
                }
                else
                {
                    OnOpenSnackBar("Lỗi", "Tạo hóa đơn không thành công.", ControlAppearance.Danger);
                }
            }
            catch (Exception)
            {
                OnOpenSnackBar("Lỗi", "Đã xảy ra lỗi không mong muốn.", ControlAppearance.Danger);
            }
        }

        [RelayCommand]
        private void CancelInvoice()
        {
            IsHaveValue = 0;
            ClearData();
            OnOpenSnackBar("Đã hủy", "Việc tạo hóa đơn đã bị hủy.", ControlAppearance.Caution);
        }

        #endregion

        #region Private Methods

        private static string GenerateInvoiceNumber()
        {
            // Implement logic to generate unique invoice number
            return $"HD-{DateTime.Now:yyyyMMddHHmmss}";
        }

        private string GetCurrentEmployeeId()
        {
            // Implement logic to retrieve the current logged-in employee's ID

            return _sessionService.GetSession()!.Id;
            ; // Placeholder
        }

        private void CalculateTotals()
        {
            TotalAmount = (decimal)InvoiceDetails.Sum(d => d.DonGia * 1000 * d.SoLuong);
            ApplyDiscount();
        }

        private void CalculateChangeDue()
        {
            ChangeDue = TienKhachDua - FinalAmount;
        }

        private bool ValidateInput()
        {
            if (SelectedCustomer == null)
            {
                OnOpenSnackBar("Lỗi xác thực", "Vui lòng chọn khách hàng.", ControlAppearance.Danger);
                return false;
            }

            if (InvoiceDetails.Count == 0)
            {
                OnOpenSnackBar("Lỗi xác thực", "Vui lòng thêm ít nhất một sản phẩm.", ControlAppearance.Danger);
                return false;
            }

            if (string.IsNullOrWhiteSpace(SelectedPaymentMethod))
            {
                OnOpenSnackBar("Lỗi xác thực", "Vui lòng chọn phương thức thanh toán.", ControlAppearance.Danger);
                return false;
            }

            if (TienKhachDua < FinalAmount)
            {
                OnOpenSnackBar("Lỗi xác thực", "Số tiền khách đưa không đủ.", ControlAppearance.Danger);
                return false;
            }

            return true;
        }

        private void ClearData()
        {
            Ma = GenerateInvoiceNumber();
            SelectedCustomer = null;
            InvoiceDetails.Clear();
            PhanTramGiamGia = 0;
            TienKhachDua = 0;
            HinhThucThanhToan = string.Empty;
            TrangThai = "Pending";
            TotalAmount = 0;
            DiscountAmount = 0;
            FinalAmount = 0;
            ChangeDue = 0;
            SearchProductText = string.Empty;
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