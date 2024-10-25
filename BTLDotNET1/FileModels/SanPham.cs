using System;
using System.Collections.Generic;

namespace BTLDotNET1.Models;

public partial class SanPham
{
    public string Id { get; set; } = null!;

    public string Ma { get; set; } = null!;

    public string? Ten { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();

    public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();

    public virtual ICollection<SanPhamTrongHoaDonTraHang> SanPhamTrongHoaDonTraHangs { get; set; } = new List<SanPhamTrongHoaDonTraHang>();

    public virtual ICollection<SanPhamTrongHoaDon> SanPhamTrongHoaDons { get; set; } = new List<SanPhamTrongHoaDon>();
}
