using BTLDotNET1.Models;
using BTLDotNET1.Services;
using System.Collections.ObjectModel;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace BTLDotNET1.ViewModels.Pages.Employee;

public partial class EmployeeViewModel : ViewModel
{
    private readonly IGenericRepository<NhanVien> _repositoryEmployee;
    private readonly ISnackbarService _snackBarService;
    private readonly INavigationService _navigationService;

    public EmployeeViewModel(
        IGenericRepository<NhanVien> repositoryEmployee,
        ISnackbarService snackBarService,
        INavigationService navigationService
    )
    {
        _snackBarService = snackBarService;
        _repositoryEmployee = repositoryEmployee;
        _navigationService = navigationService;
        _ = LoadData();
    }

    [ObservableProperty] private ObservableCollection<NhanVien> employeesList;

    [ObservableProperty] private ObservableCollection<NhanVien> suggesEmployeesList;

    [ObservableProperty] private string inputSuggesEmployee;


    partial void OnInputSuggesEmployeeChanging(string value)
    {
        _ = Filter(value);
    }

    [RelayCommand]
    public async Task LoadData()
    {
        var danhSach = await _repositoryEmployee.GetAllAsync();
        EmployeesList = new ObservableCollection<NhanVien>(danhSach);
        SuggesEmployeesList = EmployeesList;
    }

    [RelayCommand]
    public async Task Filter(string name)
    {
        var danhSach = await _repositoryEmployee.GetByNameAsync(x => x.HoTen.Contains(name));
        EmployeesList = new ObservableCollection<NhanVien>(danhSach);
    }

    [RelayCommand]
    public Task ViewDetail(NhanVien nv)
    {
        return null;
    }

    [RelayCommand]
    public async Task Delete(NhanVien nv)
    {
        if (await _repositoryEmployee.DeleteAsync(nv.Id))
        {
            await LoadData();
            OnOpenSnackBar("Xóa thành công", "Xóa nhân viên thành công", ControlAppearance.Success);
        }
    }

    private void OnOpenSnackBar
    (
        string title,
        string message,
        ControlAppearance appearance
    )
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