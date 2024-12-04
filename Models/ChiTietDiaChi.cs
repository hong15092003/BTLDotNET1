using System;
using System.Collections.Generic;

namespace BTLDotNET1.Models;

public partial class ChiTietDiaChi
{
    public string Id { get; set; } = null!;

    public string IdTinhTp { get; set; } = null!;

    public string IdHuyenQuan { get; set; } = null!;

    public string IdXaPhuong { get; set; } = null!;

    public string? MoTa { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual HuyenQuan IdHuyenQuanNavigation { get; set; } = null!;

    public virtual TinhTp IdTinhTpNavigation { get; set; } = null!;

    public virtual XaPhuong IdXaPhuongNavigation { get; set; } = null!;

    public virtual ICollection<KhachHang> KhachHangs { get; set; } = new List<KhachHang>();

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
