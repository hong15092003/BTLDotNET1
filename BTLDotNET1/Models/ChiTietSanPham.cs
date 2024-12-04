namespace BTLDotNET1.Models;

public partial class ChiTietSanPham
{
    public string Id { get; set; }

    public string IdSanPham { get; set; }

    public string IdMauSac { get; set; }

    public string IdCtspKhuyenMai { get; set; }

    public string IdPhuKien { get; set; }

    public double? BoNhoTrong { get; set; }

    public double? Ram { get; set; }

    public string MoTa { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public decimal? Gia { get; set; }

    public int? SoLuong { get; set; }

    public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();

    public virtual CtspKhuyenMai IdCtspKhuyenMaiNavigation { get; set; }

    public virtual MauSac IdMauSacNavigation { get; set; }

    public virtual PhuKien IdPhuKienNavigation { get; set; }

    public virtual SanPham IdSanPhamNavigation { get; set; }

    public virtual ICollection<Imei> Imeis { get; set; } = new List<Imei>();
}
