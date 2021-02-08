using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasinmaz.Migrations
{
    public partial class foreign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Yetki",
                table: "tblKullanici",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.CreateIndex(
                name: "IX_tblTasinmaz_Ada_Parsel",
                table: "tblTasinmaz",
                columns: new[] { "Ada", "Parsel" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblMahalle_Ad",
                table: "tblMahalle",
                column: "Ad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblKullanici_Email",
                table: "tblKullanici",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblTasinmaz_Ada_Parsel",
                table: "tblTasinmaz");

            migrationBuilder.DropIndex(
                name: "IX_tblMahalle_Ad",
                table: "tblMahalle");

            migrationBuilder.DropIndex(
                name: "IX_tblKullanici_Email",
                table: "tblKullanici");

            migrationBuilder.AlterColumn<byte>(
                name: "Yetki",
                table: "tblKullanici",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
