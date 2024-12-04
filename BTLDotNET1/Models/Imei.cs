namespace BTLDotNET1.Models;

public partial class Imei
{
    public string Id { get; set; }

    public string Imei1 { get; set; }

    public string Imei2 { get; set; }

    public string IdChiTietSanPham { get; set; }

    public string IdChiTietHoaDon { get; set; }

    public virtual ICollection<BaoHanh> BaoHanhs { get; set; } = new List<BaoHanh>();

    public virtual HoaDonChiTiet IdChiTietHoaDonNavigation { get; set; }

    public virtual ChiTietSanPham IdChiTietSanPhamNavigation { get; set; }
}
