using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasinmaz.Migrations
{
    public partial class unique5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblIlce_Ad",
                table: "tblIlce");

            migrationBuilder.CreateIndex(
                name: "IX_tblIlce_Ad_IlId",
                table: "tblIlce",
                columns: new[] { "Ad", "IlId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblIlce_Ad_IlId",
                table: "tblIlce");

            migrationBuilder.CreateIndex(
                name: "IX_tblIlce_Ad",
                table: "tblIlce",
                column: "Ad",
                unique: true);
        }
    }
}
