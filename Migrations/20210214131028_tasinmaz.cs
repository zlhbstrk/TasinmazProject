using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasinmaz.Migrations
{
    public partial class tasinmaz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Parsel",
                table: "tblTasinmaz",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Ada",
                table: "tblTasinmaz",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "AktifMi",
                table: "tblTasinmaz",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "KullaniciId",
                table: "tblTasinmaz",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblTasinmaz_KullaniciId",
                table: "tblTasinmaz",
                column: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblTasinmaz_tblKullanici_KullaniciId",
                table: "tblTasinmaz",
                column: "KullaniciId",
                principalTable: "tblKullanici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblTasinmaz_tblKullanici_KullaniciId",
                table: "tblTasinmaz");

            migrationBuilder.DropIndex(
                name: "IX_tblTasinmaz_KullaniciId",
                table: "tblTasinmaz");

            migrationBuilder.DropColumn(
                name: "AktifMi",
                table: "tblTasinmaz");

            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "tblTasinmaz");

            migrationBuilder.AlterColumn<int>(
                name: "Parsel",
                table: "tblTasinmaz",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "Ada",
                table: "tblTasinmaz",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);
        }
    }
}
