using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Wpf.Ui.Controls;
using BTLDotNET1.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BTLDotNET1.ViewModels.Windows
{
    public partial class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _loginMessage;
        private bool _isLoginSuccess;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string LoginMessage
        {
            get => _loginMessage;
            set
            {
                _loginMessage = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoginSuccess { 
            get => _isLoginSuccess;
            private set 
            {
                _isLoginSuccess = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        public void Login()
        {
            using (var context = new QlsbdtContext())
            {
                var CheckUser = context.NhanViens.Where(u => u.MaNv == Username).FirstOrDefault();
                if (CheckUser == null)
                {
                    LoginMessage = ("Mã của bạn không tồn tại. Vui lòng kiểm tra lại!");
                    IsLoginSuccess = false;
                }
                else if (CheckUser.MatKhau != Password)
                {
                    LoginMessage = ("Mật khẩu không đúng. Vui lòng kiểm tra lại!");
                    IsLoginSuccess = false;
                }
                else
                {
                    LoginMessage = "Đăng nhập thành công!";
                    IsLoginSuccess = true;
                }
              
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();

        public void Execute(object parameter) => _execute();

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
