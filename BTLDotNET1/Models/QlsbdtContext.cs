using Microsoft.EntityFrameworkCore;

namespace BTLDotNET1.Models;

public partial class QLSBDTContext : DbContext
{
    public QLSBDTContext(DbContextOptions<QLSBDTContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaoHanh> BaoHanhs { get; set; }

    public virtual DbSet<ChiTietDiaChi> ChiTietDiaChis { get; set; }

    public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }

    public virtual DbSet<CtspKhuyenMai> CtspKhuyenMais { get; set; }

    public virtual DbSet<Hang> Hangs { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }

    public virtual DbSet<HoaDonTraHang> HoaDonTraHangs { get; set; }

    public virtual DbSet<HoaDonTraHangChiTiet> HoaDonTraHangChiTiets { get; set; }

    public virtual DbSet<HuyenQuan> HuyenQuans { get; set; }

    public virtual DbSet<Imei> Imeis { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }

    public virtual DbSet<MauSac> MauSacs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhuKien> PhuKiens { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<TinhTp> TinhTps { get; set; }

    public virtual DbSet<VaiTro> VaiTros { get; set; }

    public virtual DbSet<XaPhuong> XaPhuongs { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PINK;Database=QLSBDT;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaoHanh>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bao_hanh__3213E83F301DD7EF");

            entity.ToTable("Bao_hanh");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.IdImei)
                .HasMaxLength(255)
                .HasColumnName("id_imei");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.NgayBatDau).HasColumnName("Ngay_bat_dau");
            entity.Property(e => e.NgayKetThuc).HasColumnName("Ngay_ket_thuc");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.ThoiGianBaoHanh).HasColumnName("Thoi_gian_bao_hanh");

            entity.HasOne(d => d.IdImeiNavigation).WithMany(p => p.BaoHanhs)
                .HasForeignKey(d => d.IdImei)
                .HasConstraintName("FK_Bao_hanh_Imei");
        });

        modelBuilder.Entity<ChiTietDiaChi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Chi_tiet__3213E83F723F5DBC");

            entity.ToTable("Chi_tiet_dia_chi");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.IdHuyenQuan)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_huyen_quan");
            entity.Property(e => e.IdTinhTp)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_tinh_tp");
            entity.Property(e => e.IdXaPhuong)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_xa_phuong");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.MoTa)
                .HasMaxLength(255)
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
            entity.HasKey(e => e.Id).HasName("PK__Chi_tiet__3213E83FADEBA4C8");

            entity.ToTable("Chi_tiet_san_pham");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.BoNhoTrong).HasColumnName("bo_nho_trong");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.Gia)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("gia");
            entity.Property(e => e.IdCtspKhuyenMai)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_ctsp_khuyen_mai");
            entity.Property(e => e.IdMauSac)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_mau_sac");
            entity.Property(e => e.IdPhuKien)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_phu_kien");
            entity.Property(e => e.IdSanPham)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_san_pham");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.MoTa)
                .HasMaxLength(255)
                .HasColumnName("mo_ta");
            entity.Property(e => e.Ram).HasColumnName("ram");
            entity.Property(e => e.SoLuong).HasColumnName("so_luong");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");

            entity.HasOne(d => d.IdCtspKhuyenMaiNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.IdCtspKhuyenMai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Chi_tiet_san_pham_CTSP_khuyen_mai");

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
            entity.HasKey(e => e.Id).HasName("PK__CTSP_khu__3213E83FA712FB91");

            entity.ToTable("CTSP_khuyen_mai");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.GiaGiam)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("gia_giam");
            entity.Property(e => e.IdKhuyenMai)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_khuyen_mai");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.TrangThai).HasColumnName("trang_thai");

            entity.HasOne(d => d.IdKhuyenMaiNavigation).WithMany(p => p.CtspKhuyenMais)
                .HasForeignKey(d => d.IdKhuyenMai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CTSP_khuyen_mai_Khuyen_mai");
        });

        modelBuilder.Entity<Hang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hang__3213E83F65373C7C");

            entity.ToTable("Hang");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Ma)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("ma");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.Ten)
                .HasMaxLength(255)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hoa_don__3213E83F6EC3E8FE");

            entity.ToTable("Hoa_don");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.HinhThucThanhToan)
                .HasMaxLength(255)
                .HasColumnName("hinh_thuc_thanh_toan");
            entity.Property(e => e.IdKh)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_kh");
            entity.Property(e => e.IdNv)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_nv");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Ma)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("ma");
            entity.Property(e => e.NgayTao).HasColumnName("ngay_tao");
            entity.Property(e => e.NgayThanhToan).HasColumnName("ngay_thanh_toan");
            entity.Property(e => e.PhanTramGiamGia)
                .HasMaxLength(255)
                .HasColumnName("phan_tram_giam_gia");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.TienKhachDua)
                .HasMaxLength(255)
                .HasColumnName("tien_khach_dua");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(255)
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
            entity.HasKey(e => e.Id).HasName("PK__Hoa_don___3213E83F9A56894B");

            entity.ToTable("Hoa_don_chi_tiet");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.DonGia)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("don_gia");
            entity.Property(e => e.IdHoaDon)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_hoa_don");
            entity.Property(e => e.IdSanPham)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_san_pham");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.SoLuong).HasColumnName("so_luong");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");

            entity.HasOne(d => d.IdHoaDonNavigation).WithMany(p => p.HoaDonChiTiets)
                .HasForeignKey(d => d.IdHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hoa_don_chi_tiet_Hoa_don");

            entity.HasOne(d => d.IdSanPhamNavigation).WithMany(p => p.HoaDonChiTiets)
                .HasForeignKey(d => d.IdSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hoa_don_chi_tiet_Chi_tiet_san_pham");
        });

        modelBuilder.Entity<HoaDonTraHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hoa_don___3213E83F0D8F9B16");

            entity.ToTable("Hoa_don_tra_hang");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(255)
                .HasColumnName("ghi_chu");
            entity.Property(e => e.IdChiTietHoaDon)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_chi_tiet_hoa_don");
            entity.Property(e => e.IdKh)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_kh");
            entity.Property(e => e.IdNv)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_nv");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Ma)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("ma");
            entity.Property(e => e.NgayTra).HasColumnName("ngay_tra");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.TienHoanTraKhach)
                .HasMaxLength(255)
                .HasColumnName("tien_hoan_tra_khach");

            entity.HasOne(d => d.IdChiTietHoaDonNavigation).WithMany(p => p.HoaDonTraHangs)
                .HasForeignKey(d => d.IdChiTietHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Hoa_don_tra_hang_Hoa_don_chi_tiet");

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
            entity.HasKey(e => e.Id).HasName("PK__Hoa_don___3213E83FC2816FC7");

            entity.ToTable("Hoa_don_tra_hang_chi_tiet");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.GiaBan)
                .HasMaxLength(255)
                .HasColumnName("gia_ban");
            entity.Property(e => e.IdHoaDonTraHang)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_hoa_don_tra_hang");
            entity.Property(e => e.IdSanPham)
                .IsRequired()
                .HasMaxLength(255)
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
            entity.HasKey(e => e.Id).HasName("PK__Huyen_qu__3213E83F2F6404DB");

            entity.ToTable("Huyen_quan");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.IdTinhTp)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_tinh_tp");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.Ten)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("ten");

            entity.HasOne(d => d.IdTinhTpNavigation).WithMany(p => p.HuyenQuans)
                .HasForeignKey(d => d.IdTinhTp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Huyen_quan_Tinh_tp");
        });

        modelBuilder.Entity<Imei>(entity =>
        {
            entity.ToTable("Imei");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.IdChiTietHoaDon)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_chi_tiet_hoa_don");
            entity.Property(e => e.IdChiTietSanPham)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_chi_tiet_san_pham");
            entity.Property(e => e.Imei1)
                .IsRequired()
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("imei_1");
            entity.Property(e => e.Imei2)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("imei_2");

            entity.HasOne(d => d.IdChiTietHoaDonNavigation).WithMany(p => p.Imeis)
                .HasForeignKey(d => d.IdChiTietHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Imei_Hoa_don_chi_tiet");

            entity.HasOne(d => d.IdChiTietSanPhamNavigation).WithMany(p => p.Imeis)
                .HasForeignKey(d => d.IdChiTietSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Imei_Chi_tiet_san_pham");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Khach_ha__3213E83FF98762DB");

            entity.ToTable("Khach_hang");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(255)
                .HasColumnName("gioi_tinh");
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .HasColumnName("ho_ten");
            entity.Property(e => e.IdDiaChi)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_dia_chi");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.MaKh)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("ma_kh");
            entity.Property(e => e.NgaySinh).HasColumnName("ngay_sinh");
            entity.Property(e => e.Sdt)
                .HasMaxLength(255)
                .HasColumnName("sdt");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");

            entity.HasOne(d => d.IdDiaChiNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.IdDiaChi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Khach_hang_Chi_tiet_dia_chi");
        });

        modelBuilder.Entity<KhuyenMai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Khuyen_m__3213E83FE5853BEF");

            entity.ToTable("Khuyen_mai");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Ma)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("ma");
            entity.Property(e => e.NgayBatDau).HasColumnName("ngay_bat_dau");
            entity.Property(e => e.NgayKetThuc).HasColumnName("ngay_ket_thuc");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.TenLoaiKm)
                .HasMaxLength(255)
                .HasColumnName("ten_loai_km");
            entity.Property(e => e.TrangThai).HasColumnName("trang_thai");
        });

        modelBuilder.Entity<MauSac>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Mau_sac__3213E83F61FA53CB");

            entity.ToTable("Mau_sac");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Ma)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("ma");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.Ten)
                .HasMaxLength(255)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Nhan_vie__3213E83FAD164412");

            entity.ToTable("Nhan_vien");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(255)
                .HasColumnName("gioi_tinh");
            entity.Property(e => e.HoTen)
                .HasMaxLength(255)
                .HasColumnName("ho_ten");
            entity.Property(e => e.IdDiaChi)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_dia_chi");
            entity.Property(e => e.IdVaiTro)
                .HasMaxLength(50)
                .HasColumnName("id_vai_tro");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.MaNv)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("ma_nv");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .HasColumnName("mat_khau");
            entity.Property(e => e.NgaySinh).HasColumnName("ngay_sinh");
            entity.Property(e => e.Sdt)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sdt");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");

            entity.HasOne(d => d.IdDiaChiNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.IdDiaChi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nhan_vien_Chi_tiet_dia_chi");

            entity.HasOne(d => d.IdVaiTroNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.IdVaiTro)
                .HasConstraintName("FK_Nhan_vien_Vai_Tro");
        });

        modelBuilder.Entity<PhuKien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Phu_kien__3213E83FCFA8671F");

            entity.ToTable("Phu_kien");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Ma)
                .HasMaxLength(255)
                .HasColumnName("ma");
            entity.Property(e => e.MoTa)
                .HasMaxLength(255)
                .HasColumnName("mo_ta");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__San_pham__3213E83F245289FB");

            entity.ToTable("San_pham");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.IdHang)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_hang");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.Ma)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("ma");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.Ten)
                .HasMaxLength(255)
                .HasColumnName("ten");

            entity.HasOne(d => d.IdHangNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.IdHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_San_pham_Hang");
        });

        modelBuilder.Entity<TinhTp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tinh_tp__3213E83F2E64224E");

            entity.ToTable("Tinh_tp");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.Ten)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<VaiTro>(entity =>
        {
            entity.ToTable("Vai_Tro");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            entity.Property(e => e.Ten)
                .HasMaxLength(50)
                .HasColumnName("ten");
        });

        modelBuilder.Entity<XaPhuong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Xa_phuon__3213E83F113F27D4");

            entity.ToTable("Xa_phuong");

            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.IdHuyenQuan)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("id_huyen_quan");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.StatusDeleted).HasColumnName("status_Deleted");
            entity.Property(e => e.Ten)
                .IsRequired()
                .HasMaxLength(255)
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
