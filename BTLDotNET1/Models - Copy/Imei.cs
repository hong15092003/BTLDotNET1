using System;
using System.Collections.Generic;

namespace BTLDotNET1.Models;

public partial class Imei
{
    public string Id { get; set; } = null!;

    public string Imei1 { get; set; } = null!;

    public string? Imei2 { get; set; }

    public string IdChiTietSanPham { get; set; } = null!;

    public string IdChiTietHoaDon { get; set; } = null!;

    public virtual ICollection<BaoHanh> BaoHanhs { get; set; } = new List<BaoHanh>();

    public virtual HoaDonChiTiet IdChiTietHoaDonNavigation { get; set; } = null!;

    public virtual ChiTietSanPham IdChiTietSanPhamNavigation { get; set; } = null!;
}
