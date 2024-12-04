using BTLDotNET1.ViewModels.Windows;
using Wpf.Ui;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace BTLDotNET1.Views.Windows
{
    public partial class Login : INavigationWindow
    {
        public LoginViewModel ViewModel { get; set; }




        public Login(IPageService pageService, INavigationService navigationService)
        {
            ViewModel = new LoginViewModel();
            DataContext = ViewModel;
            SystemThemeWatcher.Watch(this);

            InitializeComponent();
            Username.Icon = new SymbolIcon { Symbol = SymbolRegular.Person12 };
            Password.Icon = new SymbolIcon { Symbol = SymbolRegular.Password24 };

            // Gán các dịch vụ được truyền vào
            ViewModel.PageService = pageService;
            ViewModel.NavigationService = navigationService;
            ViewModel.LoginView = this;

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
