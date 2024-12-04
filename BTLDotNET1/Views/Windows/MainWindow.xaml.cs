﻿using BTLDotNET1.ViewModels.Windows;
using Wpf.Ui;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace BTLDotNET1.Views.Windows
{
    public partial class MainWindow : INavigationWindow
    {
        public MainWindowViewModel ViewModel { get; }

        public MainWindow(
            MainWindowViewModel viewModel,
            IPageService pageService,
            INavigationService navigationService,
            ISnackbarService snackbarService,
            IContentDialogService contentDialogService
        )
        {
            InitializeComponent();

            ViewModel = viewModel;
            DataContext = this;

            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;

            SystemThemeWatcher.Watch(this);

            SetPageService(pageService);
            contentDialogService.SetDialogHost(RootContentDialog);
            snackbarService.SetSnackbarPresenter(SnackbarPresenter);
            navigationService.SetNavigationControl(RootNavigation);
        }

        public void SelectNavigationItem(NavigationViewItem item)
        {
            RootContentDialog.Content = item;
        }


        #region INavigationWindow methods

        public INavigationView GetNavigation() => RootNavigation;

        public bool Navigate(Type pageType) => RootNavigation.Navigate(pageType);

        public void SetPageService(IPageService pageService) => RootNavigation.SetPageService(pageService);

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

        INavigationView INavigationWindow.GetNavigation()
        {
            throw new NotImplementedException();
        }

        public void SetServiceProvider(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }
    }
}
