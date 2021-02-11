using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasinmaz.Migrations
{
    public partial class unique4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblIl_Ad",
                table: "tblIl");

            migrationBuilder.CreateIndex(
                name: "IX_tblIl_Ad_Plaka",
                table: "tblIl",
                columns: new[] { "Ad", "Plaka" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblIl_Ad_Plaka",
                table: "tblIl");

            migrationBuilder.CreateIndex(
                name: "IX_tblIl_Ad",
                table: "tblIl",
                column: "Ad",
                unique: true);
        }
    }
}
