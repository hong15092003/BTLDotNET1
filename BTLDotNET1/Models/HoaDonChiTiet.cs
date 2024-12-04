namespace BTLDotNET1.Models;

public partial class HoaDonChiTiet
{
    public string Id { get; set; }

    public string IdHoaDon { get; set; }

    public string IdSanPham { get; set; }

    public int? SoLuong { get; set; }

    public decimal? DonGia { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual ICollection<HoaDonTraHang> HoaDonTraHangs { get; set; } = new List<HoaDonTraHang>();

    public virtual HoaDon IdHoaDonNavigation { get; set; }

    public virtual ChiTietSanPham IdSanPhamNavigation { get; set; }

    public virtual ICollection<Imei> Imeis { get; set; } = new List<Imei>();
}
