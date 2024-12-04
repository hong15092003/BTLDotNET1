using BTLDotNET1.ViewModels.Pages.Employee;
using BTLDotNET1.ViewModels.Pages.Sell;
using System;
using System.Collections.Generic;
using Wpf.Ui.Controls;

namespace BTLDotNET1.Views.Pages
{
    /// <summary>
    /// Interaction logic for SellPage.xaml
    /// </summary>
    public partial class SellPage : INavigableView<SellViewModel>
    {
        public SellViewModel ViewModel { get; }
        public SellPage(SellViewModel viewModel)
        {
            DataContext = viewModel;
            ViewModel = viewModel;
            InitializeComponent();
        }

    }
}
