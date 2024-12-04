using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLDotNET1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hang",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ma = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ten = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date = table.Column<DateOnly>(type: "date", nullable: true),
                    last_modified_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status_Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Hang__3213E83F65373C7C", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Khuyen_mai",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ma = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ten_loai_km = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ngay_bat_dau = table.Column<DateOnly>(type: "date", nullable: true),
                    ngay_ket_thuc = table.Column<DateOnly>(type: "date", nullable: true),
                    trang_thai = table.Column<bool>(type: "bit", nullable: true),
                    create_date = table.Column<DateOnly>(type: "date", nullable: true),
                    last_modified_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status_Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Khuyen_m__3213E83FE5853BEF", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Mau_sac",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ma = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ten = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date = table.Column<DateOnly>(type: "date", nullable: true),
                    last_modified_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status_Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mau_sac__3213E83F61FA53CB", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Phu_kien",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ma = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    mo_ta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date = table.Column<DateOnly>(type: "date", nullable: true),
                    last_modified_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status_Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Phu_kien__3213E83FCFA8671F", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tinh_tp",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ten = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    create_date = table.Column<DateOnly>(type: "date", nullable: true),
                    last_modified_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status_Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tinh_tp__3213E83F2E64224E", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "San_pham",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ma = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ten = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date = table.Column<DateOnly>(type: "date", nullable: true),
                    last_modified_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status_Deleted = table.Column<bool>(type: "bit", nullable: true),
                    id_hang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__San_pham__3213E83F245289FB", x => x.id);
                    table.ForeignKey(
                        name: "FK_San_pham_Hang",
                        column: x => x.id_hang,
                        principalTable: "Hang",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CTSP_khuyen_mai",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_khuyen_mai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    trang_thai = table.Column<bool>(type: "bit", nullable: true),
                    create_date = table.Column<DateOnly>(type: "date", nullable: true),
                    last_modified_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status_Deleted = table.Column<bool>(type: "bit", nullable: true),
                    gia_giam = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CTSP_khu__3213E83FA712FB91", x => x.id);
                    table.ForeignKey(
                        name: "FK_CTSP_khuyen_mai_Khuyen_mai",
                        column: x => x.id_khuyen_mai,
                        principalTable: "Khuyen_mai",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Huyen_quan",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_tinh_tp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ten = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    create_date = table.Column<DateOnly>(type: "date", nullable: true),
                    last_modified_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status_Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Huyen_qu__3213E83F2F6404DB", x => x.id);
                    table.ForeignKey(
                        name: "FK_Huyen_quan_Tinh_tp",
                        column: x => x.id_tinh_tp,
                        principalTable: "Tinh_tp",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Chi_tiet_san_pham",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_san_pham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_mau_sac = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_ctsp_khuyen_mai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_phu_kien = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    bo_nho_trong = table.Column<double>(type: "float", nullable: true),
                    ram = table.Column<double>(type: "float", nullable: true),
                    mo_ta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date = table.Column<DateOnly>(type: "date", nullable: true),
                    last_modified_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status_Deleted = table.Column<bool>(type: "bit", nullable: true),
                    gia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    so_luong = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Chi_tiet__3213E83FADEBA4C8", x => x.id);
                    table.ForeignKey(
                        name: "FK_Chi_tiet_san_pham_CTSP_khuyen_mai",
                        column: x => x.id_ctsp_khuyen_mai,
                        principalTable: "CTSP_khuyen_mai",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Chi_tiet_san_pham_Mau_sac",
                        column: x => x.id_mau_sac,
                        principalTable: "Mau_sac",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Chi_tiet_san_pham_Phu_kien",
                        column: x => x.id_phu_kien,
                        principalTable: "Phu_kien",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Chi_tiet_san_pham_San_pham",
                        column: x => x.id_san_pham,
                        principalTable: "San_pham",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Xa_phuong",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_huyen_quan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ten = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    create_date = table.Column<DateOnly>(type: "date", nullable: true),
                    last_modified_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status_Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Xa_phuon__3213E83F113F27D4", x => x.id);
                    table.ForeignKey(
                        name: "FK_Xa_phuong_Huyen_quan",
                        column: x => x.id_huyen_quan,
                        principalTable: "Huyen_quan",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Chi_tiet_dia_chi",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_tinh_tp = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_huyen_quan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_xa_phuong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    mo_ta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date = table.Column<DateOnly>(type: "date", nullable: true),
                    last_modified_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status_Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Chi_tiet__3213E83F723F5DBC", x => x.id);
                    table.ForeignKey(
                        name: "FK_Chi_tiet_dia_chi_Huyen_quan",
                        column: x => x.id_huyen_quan,
                        principalTable: "Huyen_quan",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Chi_tiet_dia_chi_Tinh_tp",
                        column: x => x.id_tinh_tp,
                        principalTable: "Tinh_tp",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Chi_tiet_dia_chi_Xa_phuong",
                        column: x => x.id_xa_phuong,
                        principalTable: "Xa_phuong",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Khach_hang",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ma_kh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ho_ten = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    gioi_tinh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ngay_sinh = table.Column<DateOnly>(type: "date", nullable: true),
                    id_dia_chi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    sdt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date = table.Column<DateOnly>(type: "date", nullable: true),
                    last_modified_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status_Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Khach_ha__3213E83FF98762DB", x => x.id);
                    table.ForeignKey(
                        name: "FK_Khach_hang_Chi_tiet_dia_chi",
                        column: x => x.id_dia_chi,
                        principalTable: "Chi_tiet_dia_chi",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Nhan_vien",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ma_nv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ho_ten = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    vai_tro = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    gioi_tinh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ngay_sinh = table.Column<DateOnly>(type: "date", nullable: true),
                    id_dia_chi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    mat_khau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date = table.Column<DateOnly>(type: "date", nullable: true),
                    last_modified_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status_Deleted = table.Column<bool>(type: "bit", nullable: true),
                    sdt = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Nhan_vie__3213E83FAD164412", x => x.id);
                    table.ForeignKey(
                        name: "FK_Nhan_vien_Chi_tiet_dia_chi",
                        column: x => x.id_dia_chi,
                        principalTable: "Chi_tiet_dia_chi",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Hoa_don",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ma = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_kh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_nv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ngay_tao = table.Column<DateOnly>(type: "date", nullable: true),
                    ngay_thanh_toan = table.Column<DateOnly>(type: "date", nullable: true),
                    phan_tram_giam_gia = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    tien_khach_dua = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    hinh_thuc_thanh_toan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    trang_thai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date = table.Column<DateOnly>(type: "date", nullable: true),
                    last_modified_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status_Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Hoa_don__3213E83F6EC3E8FE", x => x.id);
                    table.ForeignKey(
                        name: "FK_Hoa_don_Khach_hang",
                        column: x => x.id_kh,
                        principalTable: "Khach_hang",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Hoa_don_Nhan_vien",
                        column: x => x.id_nv,
                        principalTable: "Nhan_vien",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Hoa_don_chi_tiet",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_hoa_don = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_san_pham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    kich_thuoc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    mau_sac = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    so_luong = table.Column<int>(type: "int", nullable: true),
                    don_gia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    create_date = table.Column<DateOnly>(type: "date", nullable: true),
                    last_modified_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status_Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Hoa_don___3213E83F9A56894B", x => x.id);
                    table.ForeignKey(
                        name: "FK_Hoa_don_chi_tiet_Chi_tiet_san_pham",
                        column: x => x.id_san_pham,
                        principalTable: "Chi_tiet_san_pham",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Hoa_don_chi_tiet_Hoa_don",
                        column: x => x.id_hoa_don,
                        principalTable: "Hoa_don",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Hoa_don_tra_hang",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ma = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_chi_tiet_hoa_don = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_nv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_kh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ghi_chu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ngay_tra = table.Column<DateOnly>(type: "date", nullable: true),
                    tien_hoan_tra_khach = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date = table.Column<DateOnly>(type: "date", nullable: true),
                    last_modified_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status_Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Hoa_don___3213E83F0D8F9B16", x => x.id);
                    table.ForeignKey(
                        name: "FK_Hoa_don_tra_hang_Hoa_don_chi_tiet",
                        column: x => x.id_chi_tiet_hoa_don,
                        principalTable: "Hoa_don_chi_tiet",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Hoa_don_tra_hang_Khach_hang",
                        column: x => x.id_kh,
                        principalTable: "Khach_hang",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Hoa_don_tra_hang_Nhan_vien",
                        column: x => x.id_nv,
                        principalTable: "Nhan_vien",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Imei",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    imei_1 = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    imei_2 = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    id_chi_tiet_san_pham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_chi_tiet_hoa_don = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imei", x => x.id);
                    table.ForeignKey(
                        name: "FK_Imei_Chi_tiet_san_pham",
                        column: x => x.id_chi_tiet_san_pham,
                        principalTable: "Chi_tiet_san_pham",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Imei_Hoa_don_chi_tiet",
                        column: x => x.id_chi_tiet_hoa_don,
                        principalTable: "Hoa_don_chi_tiet",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Hoa_don_tra_hang_chi_tiet",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_hoa_don_tra_hang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    id_san_pham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    so_luong = table.Column<int>(type: "int", nullable: true),
                    gia_ban = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date = table.Column<DateOnly>(type: "date", nullable: true),
                    last_modified_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status_Deleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Hoa_don___3213E83FC2816FC7", x => x.id);
                    table.ForeignKey(
                        name: "FK_Hoa_don_tra_hang_chi_tiet_Hoa_don_tra_hang",
                        column: x => x.id_hoa_don_tra_hang,
                        principalTable: "Hoa_don_tra_hang",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Bao_hanh",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Thoi_gian_bao_hanh = table.Column<int>(type: "int", nullable: false),
                    Ngay_bat_dau = table.Column<DateOnly>(type: "date", nullable: false),
                    Ngay_ket_thuc = table.Column<DateOnly>(type: "date", nullable: false),
                    create_date = table.Column<DateOnly>(type: "date", nullable: true),
                    last_modified_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status_Deleted = table.Column<bool>(type: "bit", nullable: true),
                    id_imei = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bao_hanh__3213E83F301DD7EF", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bao_hanh_Imei",
                        column: x => x.id_imei,
                        principalTable: "Imei",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bao_hanh_id_imei",
                table: "Bao_hanh",
                column: "id_imei");

            migrationBuilder.CreateIndex(
                name: "IX_Chi_tiet_dia_chi_id_huyen_quan",
                table: "Chi_tiet_dia_chi",
                column: "id_huyen_quan");

            migrationBuilder.CreateIndex(
                name: "IX_Chi_tiet_dia_chi_id_tinh_tp",
                table: "Chi_tiet_dia_chi",
                column: "id_tinh_tp");

            migrationBuilder.CreateIndex(
                name: "IX_Chi_tiet_dia_chi_id_xa_phuong",
                table: "Chi_tiet_dia_chi",
                column: "id_xa_phuong");

            migrationBuilder.CreateIndex(
                name: "IX_Chi_tiet_san_pham_id_ctsp_khuyen_mai",
                table: "Chi_tiet_san_pham",
                column: "id_ctsp_khuyen_mai");

            migrationBuilder.CreateIndex(
                name: "IX_Chi_tiet_san_pham_id_mau_sac",
                table: "Chi_tiet_san_pham",
                column: "id_mau_sac");

            migrationBuilder.CreateIndex(
                name: "IX_Chi_tiet_san_pham_id_phu_kien",
                table: "Chi_tiet_san_pham",
                column: "id_phu_kien");

            migrationBuilder.CreateIndex(
                name: "IX_Chi_tiet_san_pham_id_san_pham",
                table: "Chi_tiet_san_pham",
                column: "id_san_pham");

            migrationBuilder.CreateIndex(
                name: "IX_CTSP_khuyen_mai_id_khuyen_mai",
                table: "CTSP_khuyen_mai",
                column: "id_khuyen_mai");

            migrationBuilder.CreateIndex(
                name: "IX_Hoa_don_id_kh",
                table: "Hoa_don",
                column: "id_kh");

            migrationBuilder.CreateIndex(
                name: "IX_Hoa_don_id_nv",
                table: "Hoa_don",
                column: "id_nv");

            migrationBuilder.CreateIndex(
                name: "IX_Hoa_don_chi_tiet_id_hoa_don",
                table: "Hoa_don_chi_tiet",
                column: "id_hoa_don");

            migrationBuilder.CreateIndex(
                name: "IX_Hoa_don_chi_tiet_id_san_pham",
                table: "Hoa_don_chi_tiet",
                column: "id_san_pham");

            migrationBuilder.CreateIndex(
                name: "IX_Hoa_don_tra_hang_id_chi_tiet_hoa_don",
                table: "Hoa_don_tra_hang",
                column: "id_chi_tiet_hoa_don");

            migrationBuilder.CreateIndex(
                name: "IX_Hoa_don_tra_hang_id_kh",
                table: "Hoa_don_tra_hang",
                column: "id_kh");

            migrationBuilder.CreateIndex(
                name: "IX_Hoa_don_tra_hang_id_nv",
                table: "Hoa_don_tra_hang",
                column: "id_nv");

            migrationBuilder.CreateIndex(
                name: "IX_Hoa_don_tra_hang_chi_tiet_id_hoa_don_tra_hang",
                table: "Hoa_don_tra_hang_chi_tiet",
                column: "id_hoa_don_tra_hang");

            migrationBuilder.CreateIndex(
                name: "IX_Huyen_quan_id_tinh_tp",
                table: "Huyen_quan",
                column: "id_tinh_tp");

            migrationBuilder.CreateIndex(
                name: "IX_Imei_id_chi_tiet_hoa_don",
                table: "Imei",
                column: "id_chi_tiet_hoa_don");

            migrationBuilder.CreateIndex(
                name: "IX_Imei_id_chi_tiet_san_pham",
                table: "Imei",
                column: "id_chi_tiet_san_pham");

            migrationBuilder.CreateIndex(
                name: "IX_Khach_hang_id_dia_chi",
                table: "Khach_hang",
                column: "id_dia_chi");

            migrationBuilder.CreateIndex(
                name: "IX_Nhan_vien_id_dia_chi",
                table: "Nhan_vien",
                column: "id_dia_chi");

            migrationBuilder.CreateIndex(
                name: "IX_San_pham_id_hang",
                table: "San_pham",
                column: "id_hang");

            migrationBuilder.CreateIndex(
                name: "IX_Xa_phuong_id_huyen_quan",
                table: "Xa_phuong",
                column: "id_huyen_quan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bao_hanh");

            migrationBuilder.DropTable(
                name: "Hoa_don_tra_hang_chi_tiet");

            migrationBuilder.DropTable(
                name: "Imei");

            migrationBuilder.DropTable(
                name: "Hoa_don_tra_hang");

            migrationBuilder.DropTable(
                name: "Hoa_don_chi_tiet");

            migrationBuilder.DropTable(
                name: "Chi_tiet_san_pham");

            migrationBuilder.DropTable(
                name: "Hoa_don");

            migrationBuilder.DropTable(
                name: "CTSP_khuyen_mai");

            migrationBuilder.DropTable(
                name: "Mau_sac");

            migrationBuilder.DropTable(
                name: "Phu_kien");

            migrationBuilder.DropTable(
                name: "San_pham");

            migrationBuilder.DropTable(
                name: "Khach_hang");

            migrationBuilder.DropTable(
                name: "Nhan_vien");

            migrationBuilder.DropTable(
                name: "Khuyen_mai");

            migrationBuilder.DropTable(
                name: "Hang");

            migrationBuilder.DropTable(
                name: "Chi_tiet_dia_chi");

            migrationBuilder.DropTable(
                name: "Xa_phuong");

            migrationBuilder.DropTable(
                name: "Huyen_quan");

            migrationBuilder.DropTable(
                name: "Tinh_tp");
        }
    }
}
