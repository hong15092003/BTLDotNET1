using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BTLDotNET1.Models;

public partial class QlsbdtContext : DbContext
{
    public QlsbdtContext()
    {
    }

    public QlsbdtContext(DbContextOptions<QlsbdtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietDiaChi> ChiTietDiaChis { get; set; }

    public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }

    public virtual DbSet<CtspKhuyenMai> CtspKhuyenMais { get; set; }

    public virtual DbSet<Hang> Hangs { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }

    public virtual DbSet<HoaDonTraHang> HoaDonTraHangs { get; set; }

    public virtual DbSet<HoaDonTraHangChiTiet> HoaDonTraHangChiTiets { get; set; }

    public virtual DbSet<HuyenQuan> HuyenQuans { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }

    public virtual DbSet<MauSac> MauSacs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhuKien> PhuKiens { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<SanPhamTrongHoaDon> SanPhamTrongHoaDons { get; set; }

    public virtual DbSet<SanPhamTrongHoaDonTraHang> SanPhamTrongHoaDonTraHangs { get; set; }

    public virtual DbSet<TinhTp> TinhTps { get; set; }

    public virtual DbSet<XaPhuong> XaPhuongs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

       
        => optionsBuilder.UseSqlServer("Server=PINK;Database=QLSBDT;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietDiaChi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Chi_tiet__3213E83FA2CC714D");

            entity.ToTable("Chi_tiet_dia_chi");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.IdHuyenQuan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_huyen_quan");
            entity.Property(e => e.IdTinhTp)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_tinh_tp");
            entity.Property(e => e.IdXaPhuong)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_xa_phuong");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.MoTa)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("mo_ta");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");

            entity.HasOne(d => d.IdHuyenQuanNavigation).WithMany(p => p.ChiTietDiaChis)
                .HasForeignKey(d => d.IdHuyenQuan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chi_tiet_dia_chi_Huyen_quan");

            entity.HasOne(d => d.IdTinhTpNavigation).WithMany(p => p.ChiTietDiaChis)
                .HasForeignKey(d => d.IdTinhTp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chi_tiet_dia_chi_Tinh_tp");

            entity.HasOne(d => d.IdXaPhuongNavigation).WithMany(p => p.ChiTietDiaChis)
                .HasForeignKey(d => d.IdXaPhuong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chi_tiet_dia_chi_Xa_phuong");
        });

        modelBuilder.Entity<ChiTietSanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Chi_tiet__3213E83F9D852682");

            entity.ToTable("Chi_tiet_san_pham");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.BoNhoTrong).HasColumnName("bo_nho_trong");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.GiaBan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("gia_ban");
            entity.Property(e => e.IdHang)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_hang");
            entity.Property(e => e.IdKhuyenMai)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_khuyen_mai");
            entity.Property(e => e.IdMauSac)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_mau_sac");
            entity.Property(e => e.IdPhuKien)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_phu_kien");
            entity.Property(e => e.IdSanPham)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_san_pham");
            entity.Property(e => e.Imei1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imei1");
            entity.Property(e => e.Imei2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imei2");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.MaVach)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ma_vach");
            entity.Property(e => e.MoTa)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("mo_ta");
            entity.Property(e => e.Ram).HasColumnName("ram");
            entity.Property(e => e.SoLuong)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("so_luong");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");

            entity.HasOne(d => d.IdHangNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.IdHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chi_tiet_san_pham_Hang");

            entity.HasOne(d => d.IdKhuyenMaiNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.IdKhuyenMai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chi_tiet_san_pham_Khuyen_mai");

            entity.HasOne(d => d.IdMauSacNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.IdMauSac)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chi_tiet_san_pham_Mau_sac");

            entity.HasOne(d => d.IdPhuKienNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.IdPhuKien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chi_tiet_san_pham_Phu_kien");

            entity.HasOne(d => d.IdSanPhamNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.IdSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chi_tiet_san_pham_San_pham");
        });

        modelBuilder.Entity<CtspKhuyenMai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CTSP_khu__3213E83F6AB1213F");

            entity.ToTable("CTSP_khuyen_mai");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.DonGiaConLai).HasColumnName("don_gia_con_lai");
            entity.Property(e => e.DonGiaMai).HasColumnName("don_gia_mai");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.MaKhuyenMai)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ma_khuyen_mai");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.TrangThai).HasColumnName("trang_thai");
        });

        modelBuilder.Entity<Hang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hang__3213E83F7F038158");

            entity.ToTable("Hang");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Ma)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ma");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.Ten)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hoa_don__3213E83FC8FBCE6E");

            entity.ToTable("Hoa_don");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.DiaChiNguoiNhan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("dia_chi_nguoi_nhan");
            entity.Property(e => e.HinhThucThanhToan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("hinh_thuc_thanh_toan");
            entity.Property(e => e.IdKh)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_kh");
            entity.Property(e => e.IdNv)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_nv");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Ma)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ma");
            entity.Property(e => e.NgayTao).HasColumnName("ngay_tao");
            entity.Property(e => e.NgayThanhToan).HasColumnName("ngay_thanh_toan");
            entity.Property(e => e.PhanTramGiamGia)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phan_tram_giam_gia");
            entity.Property(e => e.SdtKhach)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SDT_khach");
            entity.Property(e => e.SdtNguoiNhan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SDT_nguoi_nhan");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.TenKhach)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ten_khach");
            entity.Property(e => e.TenNguoiNhan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ten_nguoi_nhan");
            entity.Property(e => e.TienKhach)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tien_khach");
            entity.Property(e => e.TienShip)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tien_ship");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.IdKhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.IdKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hoa_don_Khach_hang");

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.IdNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hoa_don_Nhan_vien");
        });

        modelBuilder.Entity<HoaDonChiTiet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hoa_don___3213E83FBB955F8A");

            entity.ToTable("Hoa_don_chi_tiet");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.GiaBan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("gia_ban");
            entity.Property(e => e.IdHoaDon)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_hoa_don");
            entity.Property(e => e.IdSanPham)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_san_pham");
            entity.Property(e => e.KichThuoc)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("kich_thuoc");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.MauSac)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("mau_sac");
            entity.Property(e => e.SoLuong).HasColumnName("so_luong");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");

            entity.HasOne(d => d.IdHoaDonNavigation).WithMany(p => p.HoaDonChiTiets)
                .HasForeignKey(d => d.IdHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hoa_don_chi_tiet_Hoa_don");

            entity.HasOne(d => d.IdSanPhamNavigation).WithMany(p => p.HoaDonChiTiets)
                .HasForeignKey(d => d.IdSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hoa_don_chi_tiet_San_pham");
        });

        modelBuilder.Entity<HoaDonTraHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hoa_don___3213E83FB26F286D");

            entity.ToTable("Hoa_don_tra_hang");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.IdHoaDon)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_hoa_don");
            entity.Property(e => e.IdKh)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_kh");
            entity.Property(e => e.IdNv)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_nv");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Ma)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ma");
            entity.Property(e => e.NgayTra).HasColumnName("ngay_tra");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.TienHoanTraKhach)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tien_hoan_tra_khach");

            entity.HasOne(d => d.IdHoaDonNavigation).WithMany(p => p.HoaDonTraHangs)
                .HasForeignKey(d => d.IdHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hoa_don_tra_hang_Hoa_don");

            entity.HasOne(d => d.IdKhNavigation).WithMany(p => p.HoaDonTraHangs)
                .HasForeignKey(d => d.IdKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hoa_don_tra_hang_Khach_hang");

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.HoaDonTraHangs)
                .HasForeignKey(d => d.IdNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hoa_don_tra_hang_Nhan_vien");
        });

        modelBuilder.Entity<HoaDonTraHangChiTiet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hoa_don___3213E83F705AA2E0");

            entity.ToTable("Hoa_don_tra_hang_chi_tiet");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.GiaBan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("gia_ban");
            entity.Property(e => e.IdHoaDonTraHang)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_hoa_don_tra_hang");
            entity.Property(e => e.IdSanPham)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_san_pham");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.SoLuong).HasColumnName("so_luong");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");

            entity.HasOne(d => d.IdHoaDonTraHangNavigation).WithMany(p => p.HoaDonTraHangChiTiets)
                .HasForeignKey(d => d.IdHoaDonTraHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hoa_don_tra_hang_chi_tiet_Hoa_don_tra_hang");
        });

        modelBuilder.Entity<HuyenQuan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Huyen_qu__3213E83F0DD5819E");

            entity.ToTable("Huyen_quan");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.IdTinhTp)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_tinh_tp");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.Ten)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ten");

            entity.HasOne(d => d.IdTinhTpNavigation).WithMany(p => p.HuyenQuans)
                .HasForeignKey(d => d.IdTinhTp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Huyen_quan_Tinh_tp");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Khach_ha__3213E83FC60086F4");

            entity.ToTable("Khach_hang");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("gioi_tinh");
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ho_ten");
            entity.Property(e => e.IdDiaChi)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_dia_chi");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.MaKh)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ma_kh");
            entity.Property(e => e.NgaySinh).HasColumnName("ngay_sinh");
            entity.Property(e => e.Sdt)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sdt");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");

            entity.HasOne(d => d.IdDiaChiNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.IdDiaChi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Khach_hang_Chi_tiet_dia_chi");
        });

        modelBuilder.Entity<KhuyenMai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Khuyen_m__3213E83FAFF0E269");

            entity.ToTable("Khuyen_mai");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.IdKhuyenMai)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_khuyen_mai");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Ma)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ma");
            entity.Property(e => e.NgayBatDau).HasColumnName("ngay_bat_dau");
            entity.Property(e => e.NgayKetThuc).HasColumnName("ngay_ket_thuc");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.TenLoaiKm)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ten_loai_km");
            entity.Property(e => e.TrangThai).HasColumnName("trang_thai");

            entity.HasOne(d => d.IdKhuyenMaiNavigation).WithMany(p => p.KhuyenMais)
                .HasForeignKey(d => d.IdKhuyenMai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CTSP_khuyen_mai_Khuyen_mai");
        });

        modelBuilder.Entity<MauSac>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Mau_sac__3213E83FC3C211E4");

            entity.ToTable("Mau_sac");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Ma)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ma");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.Ten)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Nhan_vie__3213E83FF7B13C1A");

            entity.ToTable("Nhan_vien");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("gioi_tinh");
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ho_ten");
            entity.Property(e => e.IdDiaChi)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_dia_chi");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.MaNv)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ma_nv");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("mat_khau");
            entity.Property(e => e.NgaySinh).HasColumnName("ngay_sinh");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.VaiTro)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("vai_tro");

            entity.HasOne(d => d.IdDiaChiNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.IdDiaChi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nhan_vien_Chi_tiet_dia_chi");
        });

        modelBuilder.Entity<PhuKien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Phu_kien__3213E83F23EE1636");

            entity.ToTable("Phu_kien");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Ma)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ma");
            entity.Property(e => e.MoTa)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("mo_ta");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__San_pham__3213E83FC23D5724");

            entity.ToTable("San_pham");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Ma)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ma");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.Ten)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<SanPhamTrongHoaDon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__San_pham__3213E83FC2FBD142");

            entity.ToTable("San_pham_trong_hoa_don");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.GiaBan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("gia_ban");
            entity.Property(e => e.IdChiTietHoaDon)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_chi_tiet_hoa_don");
            entity.Property(e => e.IdSanPham)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_san_pham");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.SoLuong)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("so_luong");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");

            entity.HasOne(d => d.IdChiTietHoaDonNavigation).WithMany(p => p.SanPhamTrongHoaDons)
                .HasForeignKey(d => d.IdChiTietHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_San_pham_trong_hoa_don_Chi_tiet_hoa_don");

            entity.HasOne(d => d.IdSanPhamNavigation).WithMany(p => p.SanPhamTrongHoaDons)
                .HasForeignKey(d => d.IdSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_San_pham_trong_hoa_don_San_pham");
        });

        modelBuilder.Entity<SanPhamTrongHoaDonTraHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__San_pham__3213E83F8F704AD5");

            entity.ToTable("San_pham_trong_hoa_don_tra_hang");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.GiaBan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("gia_ban");
            entity.Property(e => e.IdChiTietHoaDon)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_chi_tiet_hoa_don");
            entity.Property(e => e.IdSanPham)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_san_pham");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.SoLuong)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("so_luong");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");

            entity.HasOne(d => d.IdChiTietHoaDonNavigation).WithMany(p => p.SanPhamTrongHoaDonTraHangs)
                .HasForeignKey(d => d.IdChiTietHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_San_pham_trong_hoa_don_tra_hang_Chi_tiet_hoa_don");

            entity.HasOne(d => d.IdSanPhamNavigation).WithMany(p => p.SanPhamTrongHoaDonTraHangs)
                .HasForeignKey(d => d.IdSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_San_pham_trong_hoa_don_tra_hang_San_pham");
        });

        modelBuilder.Entity<TinhTp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tinh_tp__3213E83F93A29A3F");

            entity.ToTable("Tinh_tp");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.Ten)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<XaPhuong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Xa_phuon__3213E83FB3FBC4A0");

            entity.ToTable("Xa_phuong");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.IdHuyenQuan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("id_huyen_quan");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.Ten)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ten");

            entity.HasOne(d => d.IdHuyenQuanNavigation).WithMany(p => p.XaPhuongs)
                .HasForeignKey(d => d.IdHuyenQuan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Xa_phuong_Huyen_quan");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
