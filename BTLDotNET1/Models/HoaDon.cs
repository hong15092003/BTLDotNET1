namespace BTLDotNET1.Models;

public partial class HoaDon
{
    public string Id { get; set; }

    public string Ma { get; set; }

    public string IdKh { get; set; }

    public string IdNv { get; set; }

    public DateOnly? NgayTao { get; set; }

    public DateOnly? NgayThanhToan { get; set; }

    public string PhanTramGiamGia { get; set; }

    public string TienKhachDua { get; set; }

    public string HinhThucThanhToan { get; set; }

    public string TrangThai { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();

    public virtual KhachHang IdKhNavigation { get; set; }

    public virtual NhanVien IdNvNavigation { get; set; }
}
