using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLN3.Migrations
{
    /// <inheritdoc />
    public partial class Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    MaChucVu = table.Column<string>(type: "TEXT", nullable: false),
                    TenChucVu = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.MaChucVu);
                });

            migrationBuilder.CreateTable(
                name: "GoiTap",
                columns: table => new
                {
                    MaGoiTap = table.Column<string>(type: "TEXT", nullable: false),
                    TenGoi = table.Column<string>(type: "TEXT", nullable: true),
                    GiaGoi = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoiTap", x => x.MaGoiTap);
                });

            migrationBuilder.CreateTable(
                name: "TinhTrang",
                columns: table => new
                {
                    MaTinhTrang = table.Column<string>(type: "TEXT", nullable: false),
                    TenND = table.Column<string>(type: "TEXT", nullable: true),
                    NoidungTT = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhTrang", x => x.MaTinhTrang);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaID = table.Column<string>(type: "TEXT", nullable: false),
                    TenNV = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    SĐT = table.Column<string>(type: "TEXT", nullable: false),
                    EmailNV = table.Column<string>(type: "TEXT", nullable: false),
                    MaChucVu = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MaID);
                    table.ForeignKey(
                        name: "FK_NhanVien_ChucVu_MaChucVu",
                        column: x => x.MaChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "MaChucVu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoiVien",
                columns: table => new
                {
                    HoiVienID = table.Column<string>(type: "TEXT", nullable: false),
                    TenHV = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    SĐT = table.Column<string>(type: "TEXT", nullable: false),
                    EmailHV = table.Column<string>(type: "TEXT", nullable: false),
                    MaGoiTap = table.Column<string>(type: "TEXT", nullable: false),
                    Ngaybatdau = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Ngayketthuc = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoiVien", x => x.HoiVienID);
                    table.ForeignKey(
                        name: "FK_HoiVien_GoiTap_MaGoiTap",
                        column: x => x.MaGoiTap,
                        principalTable: "GoiTap",
                        principalColumn: "MaGoiTap",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThietBi",
                columns: table => new
                {
                    MaTB = table.Column<string>(type: "TEXT", nullable: false),
                    TenTB = table.Column<string>(type: "TEXT", nullable: false),
                    size = table.Column<string>(type: "TEXT", nullable: false),
                    Soluong = table.Column<int>(type: "INTEGER", nullable: false),
                    MaTinhTrang = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThietBi", x => x.MaTB);
                    table.ForeignKey(
                        name: "FK_ThietBi_TinhTrang_MaTinhTrang",
                        column: x => x.MaTinhTrang,
                        principalTable: "TinhTrang",
                        principalColumn: "MaTinhTrang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThanhToan",
                columns: table => new
                {
                    MaHD = table.Column<string>(type: "TEXT", nullable: false),
                    HoiVienID = table.Column<string>(type: "TEXT", nullable: false),
                    MaGoiTap = table.Column<string>(type: "TEXT", nullable: false),
                    Ngayban = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MaTinhTrang = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhToan", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_ThanhToan_GoiTap_MaGoiTap",
                        column: x => x.MaGoiTap,
                        principalTable: "GoiTap",
                        principalColumn: "MaGoiTap",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThanhToan_HoiVien_HoiVienID",
                        column: x => x.HoiVienID,
                        principalTable: "HoiVien",
                        principalColumn: "HoiVienID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThanhToan_TinhTrang_MaTinhTrang",
                        column: x => x.MaTinhTrang,
                        principalTable: "TinhTrang",
                        principalColumn: "MaTinhTrang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoiVien_MaGoiTap",
                table: "HoiVien",
                column: "MaGoiTap");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_MaChucVu",
                table: "NhanVien",
                column: "MaChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToan_HoiVienID",
                table: "ThanhToan",
                column: "HoiVienID");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToan_MaGoiTap",
                table: "ThanhToan",
                column: "MaGoiTap");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToan_MaTinhTrang",
                table: "ThanhToan",
                column: "MaTinhTrang");

            migrationBuilder.CreateIndex(
                name: "IX_ThietBi_MaTinhTrang",
                table: "ThietBi",
                column: "MaTinhTrang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "ThanhToan");

            migrationBuilder.DropTable(
                name: "ThietBi");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "HoiVien");

            migrationBuilder.DropTable(
                name: "TinhTrang");

            migrationBuilder.DropTable(
                name: "GoiTap");
        }
    }
}
