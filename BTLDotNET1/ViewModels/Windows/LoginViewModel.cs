using BTLDotNET1.Models;
using BTLDotNET1.Services;
using Microsoft.Extensions.Hosting;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace BTLDotNET1.ViewModels.Windows
{
    public partial class LoginViewModel : ViewModel
    {
        #region Variables

        [ObservableProperty] private string username;
        [ObservableProperty] private string password;
        [ObservableProperty] private string loginMessage;

        public IPageService PageService;
        public INavigationService NavigationService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IGenericRepository<NhanVien> _employeeRepository;
        private readonly ISessionService _sessionService;
        public Window LoginView;

        public LoginViewModel(IGenericRepository<NhanVien> employeeRepository, IServiceProvider serviceProvider,
            ISessionService sessionService)
        {
            _sessionService = sessionService;
            _employeeRepository = employeeRepository;
            _serviceProvider = serviceProvider;
        }

        #endregion

        partial void OnPasswordChanging(string value)
        {
            password = value;
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


        [RelayCommand]
        public async Task Login()
        {
            NhanVien? CheckUser;
            if (Username.Contains('@'))
            {
                CheckUser = (await _employeeRepository.GetByNameAsync(x => x.Email == Username)).FirstOrDefault();
            }
            else
            {
                CheckUser = (await _employeeRepository.GetByNameAsync(x => x.MaNv == Username)).FirstOrDefault();
            }
            if (CheckUser == null)
            {
                LoginMessage = ("Mã của bạn không tồn tại. Vui lòng kiểm tra lại!");
                OpenMessageBox("Lỗi", LoginMessage, "Thử lại");
                return;
            }
            else if (CheckUser.MatKhau != Password)
            {
                LoginMessage = ("Mật khẩu không đúng. Vui lòng kiểm tra lại!");
                OpenMessageBox("Lỗi", LoginMessage, "Thử lại");
            }
            else
            {
                LoginMessage = "Đăng nhập thành công!";
                _sessionService.SaveSession(CheckUser);
                var host = new ApplicationHostService(_serviceProvider, _sessionService);
                await host.HandleActivationMainAsync();
                LoginView.Hide();
            }
        }
    }
}