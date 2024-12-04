using Wpf.Ui;
using Wpf.Ui.Controls;

namespace BTLDotNET1.ViewModels.Windows
{
    public partial class LoginViewModel : ViewModel
    {

        #region Variables
        [ObservableProperty]
        private string username;
        [ObservableProperty]
        private string password;
        [ObservableProperty]
        private string loginMessage;

        public IPageService PageService;
        public INavigationService NavigationService;
        public Window LoginView;



        #endregion

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
        public void Login()
        {

            //var mainWindowViewModel = new MainWindowViewModel();
            //var mainWindow = new MainWindow(mainWindowViewModel, PageService, NavigationService);
            //mainWindow.ShowWindow();
            //LoginView.Hide();


            //using (var context = new QLSBDTContext())
            //{
            //    var CheckUser = context.NhanViens.Where(u => u.MaNv == Username).FirstOrDefault();
            //    if (CheckUser == null)
            //    {
            //        LoginMessage = ("Mã của bạn không tồn tại. Vui lòng kiểm tra lại!");
            //        OpenMessageBox("Lỗi", LoginMessage, "Thử lại");
            //    }
            //    else if (CheckUser.MatKhau != Password)
            //    {
            //        LoginMessage = ("Mật khẩu không đúng. Vui lòng kiểm tra lại!");
            //        OpenMessageBox("Lỗi", LoginMessage, "Thử lại");

            //    }
            //    else
            //    {
            //        LoginMessage = "Đăng nhập thành công!";
            //        // Đăng nhập thành công, chuyển hướng đến trang chính
            //        var mainWindowViewModel = new MainWindowViewModel();
            //        var mainWindow = new MainWindow(mainWindowViewModel, _pageService, _navigationService);
            //        mainWindow.ShowWindow();
            //        LoginView.Hide();

            //    }

            //}


        }


    }
}
