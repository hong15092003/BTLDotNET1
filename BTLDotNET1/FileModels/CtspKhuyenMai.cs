using System;
using System.Collections.Generic;

namespace BTLDotNET1.Models;

public partial class CtspKhuyenMai
{
    public string Id { get; set; } = null!;

    public string MaKhuyenMai { get; set; } = null!;

    public int? DonGiaMai { get; set; }

    public int? DonGiaConLai { get; set; }

    public bool? TrangThai { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual ICollection<KhuyenMai> KhuyenMais { get; set; } = new List<KhuyenMai>();
}
