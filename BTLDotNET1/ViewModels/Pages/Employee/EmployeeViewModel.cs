using BTLDotNET1.Models;
using BTLDotNET1.Services;
using BTLDotNET1.ViewModels.Dialogs;
using BTLDotNET1.Views.Components.Dialog;
using BTLDotNET1.Views.Pages.Employee;
using System.Collections.ObjectModel;
using Wpf.Ui;
using Wpf.Ui.Controls;
using Wpf.Ui.Extensions;

namespace BTLDotNET1.ViewModels.Pages.Employee;

public partial class EmployeeViewModel : ViewModel
{
    private readonly IGenericRepository<NhanVien> _repositoryEmployee;
    private readonly ISnackbarService _snackBarService;
    private readonly INavigationService _navigationService;
    private readonly IServiceProvider _serviceProvider;
    private readonly IContentDialogService _contentDialogService;

    public EmployeeViewModel(
        IContentDialogService contentDialogService,
        IGenericRepository<NhanVien> repositoryEmployee,
        ISnackbarService snackBarService,
        INavigationService navigationService,
        IServiceProvider serviceProvider

    )
    {
        _repositoryEmployee = repositoryEmployee;
        _snackBarService = snackBarService;
        _repositoryEmployee = repositoryEmployee;
        _navigationService = navigationService;
        _ = LoadData();
        _serviceProvider = serviceProvider;
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
    private async Task ViewDetail(NhanVien nv)
    {
        var employeeDialogViewModel = _serviceProvider.GetService(typeof(EmployeeDialogViewModel)) as EmployeeDialogViewModel;
        employeeDialogViewModel!.SelectedEmployee = nv;

        _navigationService.NavigateWithHierarchy(typeof(EmployeeDialog), employeeDialogViewModel);
    }
    [RelayCommand]
    private void EditUser(NhanVien nv)
    {
        var viewModel = _serviceProvider.GetService(typeof(AddEmployeeViewModel)) as AddEmployeeViewModel;
        viewModel!.EmployeeCode = nv.MaNv;
        _navigationService.Navigate(typeof(AddEmployeePage), viewModel);

    }

    [RelayCommand]
    private async Task Delete(NhanVien nv)
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