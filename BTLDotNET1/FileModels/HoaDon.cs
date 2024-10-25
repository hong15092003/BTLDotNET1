using System;
using System.Collections.Generic;

namespace BTLDotNET1.Models;

public partial class HoaDon
{
    public string Id { get; set; } = null!;

    public string Ma { get; set; } = null!;

    public string IdKh { get; set; } = null!;

    public string IdNv { get; set; } = null!;

    public string? TenNguoiNhan { get; set; }

    public string? DiaChiNguoiNhan { get; set; }

    public string? SdtNguoiNhan { get; set; }

    public DateOnly? NgayTao { get; set; }

    public DateOnly? NgayThanhToan { get; set; }

    public string? PhanTramGiamGia { get; set; }

    public string? SdtKhach { get; set; }

    public string? TenKhach { get; set; }

    public string? TienShip { get; set; }

    public string? TienKhach { get; set; }

    public string? HinhThucThanhToan { get; set; }

    public string? TrangThai { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; } = new List<HoaDonChiTiet>();

    public virtual ICollection<HoaDonTraHang> HoaDonTraHangs { get; set; } = new List<HoaDonTraHang>();

    public virtual KhachHang IdKhNavigation { get; set; } = null!;

    public virtual NhanVien IdNvNavigation { get; set; } = null!;
}
