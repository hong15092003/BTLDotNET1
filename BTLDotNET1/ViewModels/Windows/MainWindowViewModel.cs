using System.Collections.ObjectModel;
using BTLDotNET1.Models;
using BTLDotNET1.Services;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace BTLDotNET1.ViewModels.Windows
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private readonly ISessionService _sessionService;
        private IGenericRepository<VaiTro> _roleRepository;

        public MainWindowViewModel(ISessionService sessionService, IGenericRepository<VaiTro> roleRepository)
        {
            _roleRepository = roleRepository;
            _sessionService = sessionService;
            CheckRole();
        }

        [ObservableProperty] private string _applicationTitle = "Quản lí shop bán điện thoại";


        [ObservableProperty]
        private ObservableCollection<object> _menuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Bán Hàng",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                TargetPageType = typeof(Views.Pages.SellPage)
            },
            new NavigationViewItem()
            {
                Content = "Hóa Đơn",
                Icon = new SymbolIcon { Symbol = SymbolRegular.DocumentOnePage24 },
                TargetPageType = typeof(Views.Pages.DataPage)
            },
            new NavigationViewItem()
            {
                Content = "Sản Phẩm",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Archive24 },

                MenuItemsSource = new object[]
                {
                    new NavigationViewItem("Xem Sản Phẩm", SymbolRegular.Box24,
                        typeof(Views.Pages.Product.ProductPage)),
                    new NavigationViewItem("Thêm Sản Phẩm", SymbolRegular.Add24,
                        typeof(Views.Pages.Product.AddProductPage)),
                    new NavigationViewItem("Hãng", SymbolRegular.Building24, typeof(Views.Pages.Product.BrandPage)),
                    new NavigationViewItem("Phụ Kiện", SymbolRegular.List24, typeof(Views.Pages.Product.AccessoryPage)),
                    new NavigationViewItem("Màu Sắc", SymbolRegular.Color24, typeof(Views.Pages.Product.ColorPage)),
                }
            },
            new NavigationViewItem()
            {
                Content = "Trả Hàng",
                Icon = new SymbolIcon { Symbol = SymbolRegular.ArchiveArrowBack24 },
                TargetPageType = typeof(Views.Pages.DataPage)
            },
            new NavigationViewItem()
            {
                Content = "Khuyến Mãi",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Flash24 },
                TargetPageType = typeof(Views.Pages.DataPage)
            },
            new NavigationViewItem()
            {
                Content = "Khách Hàng",
                Icon = new SymbolIcon { Symbol = SymbolRegular.PersonTag24 },
                MenuItemsSource = new object[]
                {
                    new NavigationViewItem("Xem Khách Hàng", SymbolRegular.Box24,
                        typeof(Views.Pages.Customer.CustomerPage)),
                    new NavigationViewItem("Thêm Khách Hàng", SymbolRegular.Add24,
                        typeof(Views.Pages.Customer.AddCustomerPage)),
                }
            },

        };

        [ObservableProperty]
        private ObservableCollection<object> _footerMenuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Cài Đặt",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                TargetPageType = typeof(Views.Pages.SettingsPage)
            }
        };

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new()
        {
            new MenuItem
            {
                Header = "Home", Tag =
                    "tray_home"
            }
        };

        private void CheckRole()
        {
            if (_sessionService.GetSession()!.IdVaiTro == "ql")
            {
                MenuItems.Add(new NavigationViewItem()
                {
                    Content = "Nhân Viên",
                    Icon = new SymbolIcon { Symbol = SymbolRegular.People24 },
                    MenuItemsSource = new object[]
                    {
                        new NavigationViewItem("Xem Nhân Viên", SymbolRegular.People24,
                            typeof(Views.Pages.Employee.EmployeePage)),
                        new NavigationViewItem("Thêm Nhân Viên", SymbolRegular.Add24,
                            typeof(Views.Pages.Employee.AddEmployeePage)),
                    }
                });
                MenuItems.Add(new NavigationViewItem()
                {
                    Content = "Thống Kê",
                    Icon = new SymbolIcon { Symbol = SymbolRegular.DataHistogram24 },
                    TargetPageType = typeof(Views.Pages.DataPage)
                });
            }
        }
    }
}