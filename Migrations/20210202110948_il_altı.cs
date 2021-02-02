using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasinmaz.Migrations
{
    public partial class il_altı : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "tblIl",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tblIl",
                newName: "ID");
        }
    }
}
