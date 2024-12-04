using System;
using System.Collections.Generic;

namespace BTLDotNET1.Models;

public partial class HuyenQuan
{
    public string Id { get; set; } = null!;

    public string IdTinhTp { get; set; } = null!;

    public string Ten { get; set; } = null!;

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual ICollection<ChiTietDiaChi> ChiTietDiaChis { get; set; } = new List<ChiTietDiaChi>();

    public virtual TinhTp IdTinhTpNavigation { get; set; } = null!;

    public virtual ICollection<XaPhuong> XaPhuongs { get; set; } = new List<XaPhuong>();
}
