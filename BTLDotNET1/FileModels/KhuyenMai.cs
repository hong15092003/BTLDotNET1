using System;
using System.Collections.Generic;

namespace BTLDotNET1.Models;

public partial class KhuyenMai
{
    public string Id { get; set; } = null!;

    public string Ma { get; set; } = null!;

    public string IdKhuyenMai { get; set; } = null!;

    public string? TenLoaiKm { get; set; }

    public DateOnly? NgayBatDau { get; set; }

    public DateOnly? NgayKetThuc { get; set; }

    public bool? TrangThai { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();

    public virtual CtspKhuyenMai IdKhuyenMaiNavigation { get; set; } = null!;
}
