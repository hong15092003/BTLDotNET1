using BTLDotNET1.ViewModels.Windows;
using Wpf.Ui;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;
using System.Windows;
using BTLDotNET1.Services;
using System.Windows.Navigation;
using Microsoft.Extensions.Hosting;

namespace BTLDotNET1.Views.Windows
{
    public partial class Login : INavigationWindow
    {
        public LoginViewModel ViewModel { get; set; }


        private IPageService _pageService;
        private INavigationService _navigationService;

        public Login(IPageService pageService, INavigationService navigationService)
        {
            ViewModel = new LoginViewModel();
            DataContext = ViewModel;
            SystemThemeWatcher.Watch(this);

            InitializeComponent();
            Username.Icon = new SymbolIcon { Symbol = SymbolRegular.Person12 };
            Password.Icon = new SymbolIcon { Symbol = SymbolRegular.Password24 };

            // Gán các dịch vụ được truyền vào
            _pageService = pageService;
            _navigationService = navigationService;
        }

        private void OpenMessageBox(string title, string content, string buttonContent)
        {
            var uiMessageBox = new Wpf.Ui.Controls.MessageBox
            {
                Title = title,
                Content = content,
                CloseButtonAppearance = ControlAppearance.Primary,
                CloseButtonText = buttonContent,

            };

            uiMessageBox.ShowDialogAsync();
        }


        // Thêm phương thức xử lý đăng nhập
        private void OnLoginButtonClick(object sender, RoutedEventArgs e)
        {
            // Giả sử bạn có một phương thức trong ViewModel để kiểm tra thông tin đăng nhập
            ViewModel.Login();
            if (!ViewModel.IsLoginSuccess)
            {
              
                // Đăng nhập thành công, chuyển hướng đến trang chính
                var mainWindowViewModel = new MainWindowViewModel();
                var mainWindow = new MainWindow(mainWindowViewModel, _pageService, _navigationService);
                mainWindow.ShowWindow();
                this.Hide();

            }
            else
            {

                OpenMessageBox("Lỗi", ViewModel.LoginMessage, "Thử lại");

            }
        }
        #region INavigationWindow methods



        public void ShowWindow() => Show();

        public void CloseWindow() => Close();

        #endregion INavigationWindow methods

        /// <summary>
        /// Raises the closed event.
        /// </summary>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Make sure that closing this window will begin the process of closing the application.
            Application.Current.Shutdown();
        }

        public INavigationView GetNavigation()
        {
            throw new NotImplementedException();
        }

        public bool Navigate(Type pageType)
        {
            throw new NotImplementedException();
        }

        public void SetServiceProvider(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }

        public void SetPageService(IPageService pageService)
        {
            throw new NotImplementedException();
        }
    }
}
