using System;
using System.Collections.Generic;

namespace BTLDotNET1.Models;

public partial class SanPhamTrongHoaDon
{
    public string Id { get; set; } = null!;

    public string IdChiTietHoaDon { get; set; } = null!;

    public string IdSanPham { get; set; } = null!;

    public string? SoLuong { get; set; }

    public string? GiaBan { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual HoaDonChiTiet IdChiTietHoaDonNavigation { get; set; } = null!;

    public virtual SanPham IdSanPhamNavigation { get; set; } = null!;
}
