using System;
using System.Collections.Generic;

namespace BTLDotNET1.Models;

public partial class TinhTp
{
    public string Id { get; set; } = null!;

    public string Ten { get; set; } = null!;

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual ICollection<ChiTietDiaChi> ChiTietDiaChis { get; set; } = new List<ChiTietDiaChi>();

    public virtual ICollection<HuyenQuan> HuyenQuans { get; set; } = new List<HuyenQuan>();
}
