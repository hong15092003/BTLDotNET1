using System.Collections.ObjectModel;
using Wpf.Ui.Controls;

namespace BTLDotNET1.ViewModels.Windows
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _applicationTitle = "Quản lí shop bán điện thoại";

        

        [ObservableProperty]
        private ObservableCollection<object> _menuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Bán Hàng",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                TargetPageType = typeof(Views.Pages.DashboardPage)
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
                new NavigationViewItem("Xem Sản Phẩm", SymbolRegular.Box24, typeof(Views.Pages.Product.ProductPage)),
                new NavigationViewItem("Thêm Sản Phẩm", SymbolRegular.Add24, typeof(Views.Pages.Product.AddProductPage)),
                new NavigationViewItem("Danh Mục", SymbolRegular.List24, typeof(Views.Pages.Product.ProductPage)),
                new NavigationViewItem("Màu Sắc", SymbolRegular.Color24, typeof(Views.Pages.Product.ProductPage)),
                new NavigationViewItem("Hãng", SymbolRegular.Building24, typeof(Views.Pages.Product.ProductPage)), 
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
                Content = "Nhân Viên",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Person24 },
                TargetPageType = typeof(Views.Pages.DataPage)
            },
            new NavigationViewItem()
            {
                Content = "Khách Hàng",
                Icon = new SymbolIcon { Symbol = SymbolRegular.PersonTag24 },
                TargetPageType = typeof(Views.Pages.DataPage)
            },
            new NavigationViewItem()
            {
                Content = "Thống Kê",
                Icon = new SymbolIcon { Symbol = SymbolRegular.DataHistogram24 },
                TargetPageType = typeof(Views.Pages.DataPage)
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
            new MenuItem { Header = "Home", Tag = "tray_home" }
        };
    }
}
