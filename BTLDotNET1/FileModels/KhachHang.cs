﻿using System;
using System.Collections.Generic;

namespace BTLDotNET1.Models;

public partial class KhachHang
{
    public string Id { get; set; } = null!;

    public string MaKh { get; set; } = null!;

    public string? HoTen { get; set; }

    public string? GioiTinh { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string IdDiaChi { get; set; } = null!;

    public string? Email { get; set; }

    public string? Sdt { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public bool? StatusDeleted { get; set; }

    public virtual ICollection<HoaDonTraHang> HoaDonTraHangs { get; set; } = new List<HoaDonTraHang>();

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual ChiTietDiaChi IdDiaChiNavigation { get; set; } = null!;
}