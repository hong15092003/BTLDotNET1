using BTLDotNET1.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Windows.Media;
using Wpf.Ui.Controls;
using System.ComponentModel;
using System.Windows.Input;
using Wpf.Ui;
using Wpf.Ui.Extensions;

namespace BTLDotNET1.ViewModels.Pages.Product
{
    public partial class ProductViewModel() : ViewModel
    {



        [ObservableProperty]
        private ObservableCollection<XemSanPham> _sanPham = GetSanPham();
        private bool _isAllChecked;
        private bool _isChecked;

        #region Variables Dialog
        private string _id;
        private string _ma;
        private string _ten;
        private string _mauSac;
        private string _hang;
        private int _ram;
        private int _boNho;
        


        #endregion




        public IContentDialogService contentDialogService = new ContentDialogService();

        public ObservableCollection<XemSanPham> sanPham
        {
            get => _sanPham;
            set
            {
                _sanPham = value;
                OnPropertyChanged(nameof(sanPham));
            }
        }



        public bool IsAllChecked
        {
            get { return _isAllChecked; }
            set
            {
                if (_isAllChecked != value)
                {
                    _isAllChecked = value;
                    OnPropertyChanged();
                    CheckAllItems(_isAllChecked);
                }
            }
        }

        [RelayCommand]
        private async Task OnShowDialog(object content)
        {
            ContentDialogResult result = await contentDialogService.ShowSimpleDialogAsync(
                new SimpleContentDialogCreateOptions()
                {
                    Title = "Thêm sản phẩm",
                    Content = content,
                    PrimaryButtonText = "Lưu",
                    CloseButtonText = "Thoát",
                }
            );

            dynamic DialogResultText = result switch
            {
                ContentDialogResult.Primary => "User saved their work",
                ContentDialogResult.Secondary => "User did not save their work",
                _ => "User cancelled the dialog"
            };
        }

        private static ObservableCollection<XemSanPham> GetSanPham()
        {
            return new ObservableCollection<XemSanPham>
                {
                    new XemSanPham
                    {
                        Id = "0001",
                        Ma="IP12PRM",
                        Ten = "iPhone 12 Pro Max",
                        MauSac = "Blue",
                        Hang = "Apple",
                        Ram = 4,
                        BoNho = 128,
                    },

                    new XemSanPham
                    {
                        Id = "0002",
                        Ma="IP12PR",
                        Ten = "iPhone 12 Pro",
                        MauSac = "White",
                        Hang = "Apple",
                        Ram = 4,
                        BoNho = 128,
                    },
                    new XemSanPham
                    {
                        Id = "0003",
                        Ma="IP12",
                        Ten = "iPhone 12",
                        MauSac = "Black",
                        Hang = "Apple",
                        Ram = 4,
                        BoNho = 128,
                    },
                    new XemSanPham
                    {
                        Id = "0004",
                        Ma="IP11",
                        Ten = "iPhone 11",
                        MauSac = "Red",
                        Hang = "Apple",
                        Ram = 4,
                        BoNho = 128,
                    },
                    new XemSanPham
                    {
                        Id = "0005",
                        Ma="IP11PR",
                        Ten = "iPhone 11 Pro",
                        MauSac = "Green",
                        Hang = "Apple",
                        Ram = 4,
                        BoNho = 128,
                    },
                    new XemSanPham
                    {
                        Id = "0006",
                        Ma="IP11PRM",
                        Ten = "iPhone 11 Pro Max",
                        MauSac = "Yellow",
                        Hang = "Apple",
                        Ram = 4,
                        BoNho = 128,
                    },
                    new XemSanPham
                    {
                        Id = "0007",
                        Ma="IPXS",
                        Ten = "iPhone XS",
                        MauSac = "Blue",
                        Hang = "Apple",
                        Ram = 4,
                        BoNho = 128,
                    },
                    new XemSanPham
                    {
                        Id = "0008",
                        Ma="IPXSM",
                        Ten = "iPhone XS Max",
                        MauSac = "White",
                        Hang = "Apple",
                        Ram = 4,
                        BoNho = 128,
                    },
                    new XemSanPham
                    {
                        Id = "0009",
                        Ma="IPXR",
                        Ten = "iPhone XR",
                        MauSac = "Black",
                        Hang = "Apple",
                        Ram = 4,
                        BoNho = 128,
                    },
                };
        }


        private void CheckAllItems(object parameter)
        {
            bool isChecked = (bool)parameter;
            foreach (var item in sanPham)
            {
                item.IsChecked = isChecked;
            }
        }


        public new event PropertyChangedEventHandler PropertyChanged;



        protected new void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public record XemSanPham
        {
            public bool IsChecked { get; set; }
            public string Id { get; set; }
            public string Ten { get; set; }
            public string Ma { get; set; }
            public string MauSac { get; set; }
            public string Hang { get; set; }
            public int Ram { get; set; }
            public int BoNho { get; set; }

        }


    }
}
