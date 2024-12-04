namespace BTLDotNET1.Models;

public partial class NhanVien
{
    public string Id { get; set; }

    public string MaNv { get; set; }

    public string HoTen { get; set; }

    public string GioiTinh { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string IdDiaChi { get; set; }

    public string Email { get; set; }

    public string MatKhau { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public string Sdt { get; set; }

    public string IdVaiTro { get; set; }

    public virtual ICollection<HoaDonTraHang> HoaDonTraHangs { get; set; } = new List<HoaDonTraHang>();

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual ChiTietDiaChi IdDiaChiNavigation { get; set; }

    public virtual VaiTro IdVaiTroNavigation { get; set; }
}
