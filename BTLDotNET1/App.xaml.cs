using BTLDotNET1.Models;
using BTLDotNET1.Services;
using BTLDotNET1.ViewModels.Pages;
using BTLDotNET1.ViewModels.Pages.Customer;
using BTLDotNET1.ViewModels.Pages.Employee;
using BTLDotNET1.ViewModels.Pages.Product;
using BTLDotNET1.ViewModels.Pages.Sell;
using BTLDotNET1.ViewModels.Windows;
using BTLDotNET1.Views.Pages;
using BTLDotNET1.Views.Pages.Customer;
using BTLDotNET1.Views.Pages.Employee;
using BTLDotNET1.Views.Pages.Product;
using BTLDotNET1.Views.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;
using System.Windows.Threading;
using Wpf.Ui;

namespace BTLDotNET1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        // Khởi tạo đối tượng IHost để cung cấp các dịch vụ như dependency injection, configuration, logging, và các dịch vụ khác.
        private static readonly IHost _host = Host
            .CreateDefaultBuilder()
            // Cấu hình ứng dụng bằng cách thiết lập đường dẫn cơ sở cho cấu hình.
            .ConfigureAppConfiguration(c => { c.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)); })
            // Đăng ký các dịch vụ cho ứng dụng.
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<QLSBDTContext>(options =>
    options.UseSqlServer("Server=PINK;Database=QLSBDT;Trusted_Connection=True;TrustServerCertificate=True;"));


                // Đăng ký dịch vụ ApplicationHostService như một dịch vụ được host.
                services.AddHostedService<ApplicationHostService>();

                //
                services.AddSingleton<IContentDialogService, ContentDialogService>();
                services.AddSingleton<ISnackbarService, SnackbarService>();


                // Đăng ký dịch vụ IPageService để quản lý các trang trong ứng dụng.
                services.AddSingleton<IPageService, PageService>();

                // Đăng ký dịch vụ IThemeService để thay đổi giao diện của ứng dụng.
                services.AddSingleton<IThemeService, ThemeService>();

                // Đăng ký dịch vụ ITaskBarService để thay đổi thanh tác vụ của hệ điều hành.
                services.AddSingleton<ITaskBarService, TaskBarService>();

                // Đăng ký dịch vụ INavigationService để chứa các phương thức điều hướng trong ứng dụng.
                services.AddSingleton<INavigationService, NavigationService>();
                services.AddTransient<ProductDetailPage>();


                // Register generic repository
                services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

                // Đăng ký cửa sổ chính của ứng dụng và cửa sổ đăng nhập.
                services.AddSingleton<INavigationWindow, Login>();
                services.AddSingleton<INavigationWindow, MainWindow>();


                // Đăng ký các ViewModel cho các cửa sổ và trang.
                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<LoginViewModel>();

                // Đăng ký các trang và ViewModel tương ứng.
                services.AddSingleton<DashboardPage>();
                services.AddSingleton<DashboardViewModel>();
                services.AddSingleton<DataPage>();
                services.AddSingleton<DataViewModel>();
                services.AddSingleton<SettingsPage>();
                services.AddSingleton<SettingsViewModel>();
                services.AddSingleton<ProductPage>();
                services.AddSingleton<ProductViewModel>();
                services.AddSingleton<AddProductPage>();
                services.AddSingleton<AddProductViewModel>();
                services.AddSingleton<ProductDetailPage>();
                services.AddSingleton<ProductDetailViewModel>();
                services.AddSingleton<BrandPage>();
                services.AddSingleton<BrandViewModel>();
                services.AddSingleton<ColorPage>();
                services.AddSingleton<ColorViewModel>();
                services.AddSingleton<AccessoryPage>();
                services.AddSingleton<AccessoryViewModel>();
                services.AddSingleton<CustomerPage>();
                services.AddSingleton<CustomerViewModel>();
                services.AddSingleton<AddCustomerPage>();
                services.AddSingleton<AddCustomerViewModel>();
                services.AddSingleton<EmployeePage>();
                services.AddSingleton<EmployeeViewModel>();
                services.AddSingleton<AddEmployeePage>();
                services.AddSingleton<AddEmployeeViewModel>();
                services.AddSingleton<LoginViewModel>();
                services.AddSingleton<Login>();
                services.AddSingleton<SellPage>();
                services.AddSingleton<SellViewModel>();

            }).Build();

        /// <summary>
        /// Lấy dịch vụ đã đăng ký.
        /// </summary>
        /// <typeparam name="T">Kiểu của dịch vụ cần lấy.</typeparam>
        /// <returns>Đối tượng của dịch vụ hoặc <see langword="null"/>.</returns>
        public static T? GetService<T>()
            where T : class
        {
            // Lấy dịch vụ từ host và ép kiểu về kiểu T.
            return _host.Services.GetService(typeof(T)) as T;
        }

        /// <summary>
        /// Xảy ra khi ứng dụng đang tải.
        /// </summary>
        private void OnStartup(object sender, StartupEventArgs e)
        {
            // Bắt đầu host khi ứng dụng khởi động.
            _host.Start();
        }

        /// <summary>
        /// Xảy ra khi ứng dụng đang đóng.
        /// </summary>
        private async void OnExit(object sender, ExitEventArgs e)
        {
            // Dừng host một cách bất đồng bộ khi ứng dụng đóng.
            await _host.StopAsync();

            // Giải phóng tài nguyên của host.
            _host.Dispose();
        }

        /// <summary>
        /// Xảy ra khi một ngoại lệ được ném ra bởi ứng dụng nhưng không được xử lý.
        /// </summary>
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // Thêm logic xử lý ngoại lệ không được xử lý tại đây.
            // Tham khảo thêm tại https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
        }
    }
}
