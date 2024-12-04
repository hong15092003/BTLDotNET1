//using BTLDotNET1.Models;
//using System.Collections.ObjectModel;
//using System.Threading.Tasks;

//namespace BTLDotNET1.Services
//{
//    public class AddressService
//    {
//        private readonly IGenericRepository<TinhTp> _cityRepository;
//        private readonly IGenericRepository<HuyenQuan> _districtRepository;
//        private readonly IGenericRepository<XaPhuong> _wardRepository;
//        private readonly IGenericRepository<ChiTietDiaChi> _addressDetailRepository;

//        public ObservableCollection<TinhTp> CityList { get; private set; }
//        public ObservableCollection<HuyenQuan> DistrictList { get; private set; }
//        public ObservableCollection<XaPhuong> WardList { get; private set; }

//        public TinhTp _selectedCity;
//        public HuyenQuan _selectedDistrict;
//        public XaPhuong _selectedWard;

//        public TinhTp SelectedCity { get => _selectedCity ; private set; }
//        public HuyenQuan SelectedDistrict { get; private set; }
//        public XaPhuong SelectedWard { get; private set; }

//        public AddressService(
//            IGenericRepository<TinhTp> cityRepository,
//            IGenericRepository<HuyenQuan> districtRepository,
//            IGenericRepository<XaPhuong> wardRepository,
//            IGenericRepository<ChiTietDiaChi> addressDetailRepository)
//        {
//            _cityRepository = cityRepository;
//            _districtRepository = districtRepository;
//            _wardRepository = wardRepository;
//            _addressDetailRepository = addressDetailRepository;

//            CityList = new ObservableCollection<TinhTp>();
//            DistrictList = new ObservableCollection<HuyenQuan>();
//            WardList = new ObservableCollection<XaPhuong>();
//        }



//        public async Task LoadCityListAsync()
//        {
//            var cities = await _cityRepository.GetAllAsync();
//            CityList = new ObservableCollection<TinhTp>(cities);
//        }

//        public async Task LoadDistrictListAsync(string cityId)
//        {
//            var districts = await _districtRepository.GetByNameAsync(d => d.IdTinhTp == cityId);
//            DistrictList = new ObservableCollection<HuyenQuan>(districts);
//        }

//        public async Task LoadWardListAsync(string districtId)
//        {
//            var wards = await _wardRepository.GetByNameAsync(w => w.IdHuyenQuan == districtId);
//            WardList = new ObservableCollection<XaPhuong>(wards);
//        }
//        public async Task HandleCreateOrUpdateChiTietDiaChiAsync(ChiTietDiaChi addressDetail)
//        {
//            var chiTietDiaChi = await _addressDetailRepository.GetByIdAsync(addressDetail.Id) ?? new ChiTietDiaChi();

//            chiTietDiaChi.IdTinhTp = addressDetail.IdTinhTp;
//            chiTietDiaChi.IdHuyenQuan = addressDetail.IdHuyenQuan;
//            chiTietDiaChi.IdXaPhuong = addressDetail.IdXaPhuong;
//            chiTietDiaChi.MoTa = addressDetail.MoTa;
//            chiTietDiaChi.CreateDate = createDate;

//            if (isCustomerChange)
//            {
//                // Handle customer-specific logic
//            }
//            else
//            {
//                // Handle employee-specific logic
//            }

//            await _addressDetailRepository.AddOrUpdateAsync(chiTietDiaChi);
//        }



//    }
//}
