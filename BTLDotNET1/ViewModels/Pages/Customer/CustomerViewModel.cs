using BTLDotNET1.Models;
using BTLDotNET1.Services;
using System.Collections.ObjectModel;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace BTLDotNET1.ViewModels.Pages.Customer;

public partial class CustomerViewModel : ViewModel
{
    private readonly IGenericRepository<KhachHang> _repositoryCustomer;
    private readonly ISnackbarService _snackBarService;
    private readonly INavigationService _navigationService;

    public CustomerViewModel(
        IGenericRepository<KhachHang> repositoryCustomer,
        ISnackbarService snackBarService,
        INavigationService navigationService
    )
    {
        _snackBarService = snackBarService;
        _repositoryCustomer = repositoryCustomer;
        _navigationService = navigationService;
        _ = LoadData();
    }

    [ObservableProperty] private ObservableCollection<KhachHang> customersList;

    [ObservableProperty] private ObservableCollection<KhachHang> suggesCustomersList;

    [ObservableProperty] private string inputSuggesCustomer;

    partial void OnInputSuggesCustomerChanging(string value)
    {
        _ = Filter(value);
    }

    [RelayCommand]
    public async Task LoadData()
    {
        var danhSach = await _repositoryCustomer.GetAllAsync();
        CustomersList = new ObservableCollection<KhachHang>(danhSach);
        SuggesCustomersList = CustomersList;
    }

    [RelayCommand]
    public async Task Filter(string name)
    {
        var danhSach = await _repositoryCustomer.GetByNameAsync(x => x.HoTen.Contains(name));
        CustomersList = new ObservableCollection<KhachHang>(danhSach);
    }

    [RelayCommand]
    public Task ViewDetail(KhachHang kh)
    {
        return null;
    }

    [RelayCommand]
    public async Task Delete(KhachHang kh)
    {
        if (await _repositoryCustomer.DeleteAsync(kh.Id))
        {
            await LoadData();
            OnOpenSnackBar("Xóa thành công", "Xóa khách hàng thành công", ControlAppearance.Success);
        }
    }

    private void OnOpenSnackBar(string title, string message, ControlAppearance appearance)
    {
        _snackBarService.Show(
            title,
            message,
            appearance,
            new SymbolIcon(SymbolRegular.DocumentError24),
            TimeSpan.FromSeconds(2)
        );
    }
}
