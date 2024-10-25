using System;
using System.Collections.Generic;

namespace BTLDotNET1.Models;

public partial class HoaDonTraHang
{
    public string Id { get; set; } = null!;

    public string Ma { get; set; } = null!;

    public string IdHoaDon { get; set; } = null!;

    public string IdNv { get; set; } = null!;

    public string IdKh { get; set; } = null!;

    public string? GhiChu { get; set; }

    public DateOnly? NgayTra { get; set; }

    public string? TienHoanTraKhach { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual ICollection<HoaDonTraHangChiTiet> HoaDonTraHangChiTiets { get; set; } = new List<HoaDonTraHangChiTiet>();

    public virtual HoaDon IdHoaDonNavigation { get; set; } = null!;

    public virtual KhachHang IdKhNavigation { get; set; } = null!;

    public virtual NhanVien IdNvNavigation { get; set; } = null!;
}
