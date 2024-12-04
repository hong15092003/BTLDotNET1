namespace BTLDotNET1.Models;

public partial class HoaDonTraHang
{
    public string Id { get; set; }

    public string Ma { get; set; }

    public string IdChiTietHoaDon { get; set; }

    public string IdNv { get; set; }

    public string IdKh { get; set; }

    public string GhiChu { get; set; }

    public DateOnly? NgayTra { get; set; }

    public string TienHoanTraKhach { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual ICollection<HoaDonTraHangChiTiet> HoaDonTraHangChiTiets { get; set; } = new List<HoaDonTraHangChiTiet>();

    public virtual HoaDonChiTiet IdChiTietHoaDonNavigation { get; set; }

    public virtual KhachHang IdKhNavigation { get; set; }

    public virtual NhanVien IdNvNavigation { get; set; }
}
