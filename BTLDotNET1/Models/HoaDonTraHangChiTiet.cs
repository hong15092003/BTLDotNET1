using System;
using System.Collections.Generic;

namespace BTLDotNET1.Models;

public partial class HoaDonTraHangChiTiet
{
    public string Id { get; set; } = null!;

    public string IdHoaDonTraHang { get; set; } = null!;

    public string IdSanPham { get; set; } = null!;

    public int? SoLuong { get; set; }

    public string? GiaBan { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual HoaDonTraHang IdHoaDonTraHangNavigation { get; set; } = null!;
}
