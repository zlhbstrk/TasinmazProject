using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasinmaz.Migrations
{
    public partial class foreignDort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AlternatifEmail",
                table: "tblKullanici");

            migrationBuilder.CreateIndex(
                name: "IX_tblKullanici_Email",
                table: "tblKullanici",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblKullanici_Email",
                table: "tblKullanici");

            migrationBuilder.AddUniqueConstraint(
                name: "AlternatifEmail",
                table: "tblKullanici",
                column: "Email");
        }
    }
}
