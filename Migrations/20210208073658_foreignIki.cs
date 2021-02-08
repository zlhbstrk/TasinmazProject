using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasinmaz.Migrations
{
    public partial class foreignIki : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblKullanici_Email",
                table: "tblKullanici");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tblKullanici_Email",
                table: "tblKullanici",
                column: "Email",
                unique: true);
        }
    }
}
