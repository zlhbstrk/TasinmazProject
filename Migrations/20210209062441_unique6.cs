using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasinmaz.Migrations
{
    public partial class unique6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblMahalle_Ad",
                table: "tblMahalle");

            migrationBuilder.DropUniqueConstraint(
                name: "AlternatifEmail",
                table: "tblKullanici");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_tblKullanici_Email",
                table: "tblKullanici",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_tblMahalle_Ad_IlceId",
                table: "tblMahalle",
                columns: new[] { "Ad", "IlceId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblMahalle_Ad_IlceId",
                table: "tblMahalle");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_tblKullanici_Email",
                table: "tblKullanici");

            migrationBuilder.AddUniqueConstraint(
                name: "AlternatifEmail",
                table: "tblKullanici",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_tblMahalle_Ad",
                table: "tblMahalle",
                column: "Ad",
                unique: true);
        }
    }
}
