using System;
using System.Collections.Generic;

namespace BTLDotNET1.Models;

public partial class HoaDonChiTiet
{
    public string Id { get; set; } = null!;

    public string IdHoaDon { get; set; } = null!;

    public string IdSanPham { get; set; } = null!;

    public string? KichThuoc { get; set; }

    public string? MauSac { get; set; }

    public int? SoLuong { get; set; }

    public string? GiaBan { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual HoaDon IdHoaDonNavigation { get; set; } = null!;

    public virtual SanPham IdSanPhamNavigation { get; set; } = null!;

    public virtual ICollection<SanPhamTrongHoaDon> SanPhamTrongHoaDons { get; set; } = new List<SanPhamTrongHoaDon>();
}
