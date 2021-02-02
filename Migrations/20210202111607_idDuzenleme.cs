using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasinmaz.Migrations
{
    public partial class idDuzenleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "tblTasinmaz",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "tblMahalle",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "tblLog",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "tblKullanici",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "tblIslemTip",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "tblIlce",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "tblDurum",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tblTasinmaz",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tblMahalle",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tblLog",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tblKullanici",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tblIslemTip",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tblIlce",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tblDurum",
                newName: "ID");
        }
    }
}
