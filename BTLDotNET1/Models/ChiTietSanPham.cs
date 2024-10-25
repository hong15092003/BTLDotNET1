using System;
using System.Collections.Generic;

namespace BTLDotNET1.Models;

public partial class ChiTietSanPham
{
    public string Id { get; set; } = null!;

    public string IdSanPham { get; set; } = null!;

    public string IdMauSac { get; set; } = null!;

    public string IdHang { get; set; } = null!;

    public string IdCtspKhuyenMai { get; set; } = null!;

    public string IdPhuKien { get; set; } = null!;

    public double? BoNhoTrong { get; set; }

    public double? Ram { get; set; }

    public string? MoTa { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();

    public virtual CtspKhuyenMai IdCtspKhuyenMaiNavigation { get; set; } = null!;

    public virtual MauSac IdMauSacNavigation { get; set; } = null!;

    public virtual PhuKien IdPhuKienNavigation { get; set; } = null!;

    public virtual SanPham IdSanPhamNavigation { get; set; } = null!;

    public virtual ICollection<Imei> Imeis { get; set; } = new List<Imei>();
}
