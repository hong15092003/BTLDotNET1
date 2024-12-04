using System;
using System.Collections.Generic;

namespace BTLDotNET1.Models;

public partial class CtspKhuyenMai
{
    public string Id { get; set; } = null!;

    public string IdKhuyenMai { get; set; } = null!;

    public bool? TrangThai { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public decimal? GiaGiam { get; set; }

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();

    public virtual KhuyenMai IdKhuyenMaiNavigation { get; set; } = null!;
}
