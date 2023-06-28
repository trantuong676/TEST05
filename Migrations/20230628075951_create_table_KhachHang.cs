using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TEST05.Migrations
{
    /// <inheritdoc />
    public partial class create_table_KhachHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKhach = table.Column<string>(type: "TEXT", nullable: false),
                    TenKhachHang = table.Column<string>(type: "TEXT", nullable: false),
                    GioiTinh = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKhach);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhachHang");
        }
    }
}
