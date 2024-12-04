namespace BTLDotNET1.Models;

public partial class HoaDonTraHangChiTiet
{
    public string Id { get; set; }

    public string IdHoaDonTraHang { get; set; }

    public string IdSanPham { get; set; }

    public int? SoLuong { get; set; }

    public string GiaBan { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual HoaDonTraHang IdHoaDonTraHangNavigation { get; set; }
}
