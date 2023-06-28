using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TEST05.Migrations
{
    /// <inheritdoc />
    public partial class create_foreignkey_DonHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    MaKhach = table.Column<string>(type: "TEXT", nullable: false),
                    MaDonHang = table.Column<string>(type: "TEXT", nullable: false),
                    SoLuong = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.MaKhach);
                    table.ForeignKey(
                        name: "FK_DonHang_KhachHang_MaKhach",
                        column: x => x.MaKhach,
                        principalTable: "KhachHang",
                        principalColumn: "MaKhach",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonHang");
        }
    }
}
