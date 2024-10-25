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

    public virtual ICollection<HoaDonTraHang> HoaDonTraHangs { get; set; } = new List<HoaDonTraHang>();

    public virtual HoaDon IdHoaDonNavigation { get; set; } = null!;

    public virtual ChiTietSanPham IdSanPhamNavigation { get; set; } = null!;

    public virtual ICollection<Imei> Imeis { get; set; } = new List<Imei>();
}
