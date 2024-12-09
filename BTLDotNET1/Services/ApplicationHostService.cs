using BTLDotNET1.Views.Windows;
using Microsoft.Extensions.Hosting;
using Wpf.Ui;

namespace BTLDotNET1.Services
{
    /// <summary>
    /// Managed host of the application.
    /// </summary>
    public class ApplicationHostService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private INavigationWindow _navigationWindow;
        private ISessionService _sessionService;

        public ApplicationHostService(IServiceProvider serviceProvider, ISessionService sessionService)
        {
            _serviceProvider = serviceProvider;
            _sessionService = sessionService;
        }


        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await HandleActivationLoginAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        public async Task HandleActivationLoginAsync()
        {
            if (!Application.Current.Windows.OfType<Login>().Any())
            {
                var loginWindow = _serviceProvider.GetService(typeof(Login)) as Login;
                if (loginWindow != null)
                {
                    loginWindow.ShowWindow();
                }
            }

            await Task.CompletedTask;
        }

        public async Task HandleActivationMainAsync()
        {
            if (!Application.Current.Windows.OfType<MainWindow>().Any())
            {
                _navigationWindow = (
                    _serviceProvider.GetService(typeof(INavigationWindow)) as INavigationWindow
                )!;
                _navigationWindow!.ShowWindow();

                _navigationWindow.Navigate(typeof(Views.Pages.SellPage));
            }

            await Task.CompletedTask;
        }
    }
}